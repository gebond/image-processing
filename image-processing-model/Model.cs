using ImageProcessingConstants;
using MathFunction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessingModel {
    class Model : IModel {

        public Model() {
            init();
            Console.WriteLine("\t[Model] was initialized successfully");
            Console.WriteLine("\t[Model] params: r_p={0}% g_p={1}% b_p={2}% selectedMetod:{3}",
                r_percentage, g_percentage, b_percentage, selectedTransformation);
        }

        #region IModel implemenation
        public bool validate() {
            if(sourceImage == null) {
                Console.WriteLine("\t[Model] validation was failed: sourceImage = null");
                return false;
            }
            Console.WriteLine("\t[Model] validation was passed: OK");
            return true;
        }
        public bool setSourceImage(Bitmap bitMap) {
            if(bitMap != null) {
                sourceImage = bitMap;
                resultImage = null;
                Console.WriteLine("[Model] source image was set, result map was erased");
                return true;
            }
            else {
                return false;
            }
        }
        public Bitmap getResultImage() {
            if(processImage()) {
                Console.WriteLine("\t[Model] result image was created succesfully and sent");
                return resultImage;
            }
            else { return null; }
        }
        public bool setRPercentage(double r_percentage) {
            if(validate_percentage(r_percentage)) {
                this.r_percentage = r_percentage;
                return true;
            }
            return false;
        }
        public bool setGPercentage(double g_percentage) {
            if(validate_percentage(g_percentage)) {
                this.g_percentage = g_percentage;
                return true;
            }
            return false;
        }
        public bool setBPercentage(double b_percentage) {
            if(validate_percentage(b_percentage)) {
                this.b_percentage = b_percentage;
                return true;
            }
            return false;
        }
        public bool setFourierByMatrix() {
            selectedTransformation = new FourierWalshByMatrixTransformation();
            Console.WriteLine("\t[Model] selected WalshByMatrix");
            return selectedTransformation != null;
        }
        public bool setFourierByWalsh() {
            selectedTransformation = new FourierWalshTransformation();
            Console.WriteLine("\t[Model] selected Walsh");
            return selectedTransformation != null;
        }
        public bool setFourierByHaart() {
            selectedTransformation = new FourierHaartTransformation();
            Console.WriteLine("\t[Model] selected Haart");
            return selectedTransformation != null;
        }
        public bool setElementSize(int elementSize) {
            if(validate_size(elementSize)) {
                this.elementSize = elementSize;
                Console.WriteLine("\t[Model] elementSize set to {0}", elementSize);
                return true;
            }
            return false;
        }
        #endregion

        #region privateFields
        // image
        Bitmap sourceImage;
        Bitmap resultImage;
        // parameters
        double r_percentage;
        double g_percentage;
        double b_percentage;
        int elementSize;
        FourierTransformation selectedTransformation;
        #endregion

        #region privateMethods
        private void init() {
            sourceImage = null;
            resultImage = null;
            r_percentage = 100.0;
            g_percentage = 100.0;
            b_percentage = 100.0;
            selectedTransformation = null;
        }
        private bool validate_percentage(double percentage) {
            if(percentage >= 0 && percentage <= 100) {
                return true;
            }
            Console.WriteLine("percentage {0} is incorrect", percentage);
            return false;
        }
        private bool validate_size(int size) {
            if(( size & ( ~size + 1 ) ) == size) {
                return true;
            }
            Console.WriteLine("size {0} is incorrect", size);
            return false;
        }
        private bool processImage() {
            if(sourceImage == null) {
                return false;
            }
            var colorElements = new ColorElements(elementSize, sourceImage);
            Console.WriteLine("\t[Model] Current percentages: R-{0}% G-{1}% B-{2}%", r_percentage,
                g_percentage, b_percentage);
            processElements(colorElements);
            resultImage = colorElements.buildImage();
            return resultImage != null;
        }
        private void processElements(ColorElements elements) {
            var recalculatedElements = new List<ColorElement>();
            foreach(var element in elements.getElementsAsList()) {
                recalculatedElements.Add(recalculateElement(element));
            }
            elements.replaceElements(recalculatedElements);
        }

        private ColorElement recalculateElement(ColorElement sourceColorElement) {
            // getting all colors from Element
            var reds = sourceColorElement.getRColors();
            var greens = sourceColorElement.getGColors();
            var blues = sourceColorElement.getBColors();
            // calculate
            reds = processPixelsArray(reds);
            greens = processPixelsArray(greens);
            blues = processPixelsArray(blues);
            // compress result values
            reds = ComressionUtils.compress(reds, this.r_percentage);
            greens = ComressionUtils.compress(greens, this.g_percentage);
            blues = ComressionUtils.compress(blues, this.b_percentage);
            return new ColorElement(reds, greens, blues);
        }

        private int[,] processPixelsArray(int[,] inputValues) {
            var coeffsArray = new double[inputValues.GetLength(0), inputValues.GetLength(1)];
            var funArray = new int[inputValues.GetLength(0), inputValues.GetLength(1)];

            for(int i = 0; i < inputValues.GetLength(0); i++) {
                // get row 
                var row = new double[inputValues.GetLength(1)];
                for(int j = 0; j < inputValues.GetLength(1); j++) {
                    row[j] = (double) inputValues[i, j];
                }
                // call coeffs
                var coeffs = selectedTransformation.doAnalysis(row);
                // call values
                var values = selectedTransformation.doSynthesis(coeffs);
                for(int j = 0; j < inputValues.GetLength(1); j++) {
                    if(values[j] <= 0.0) {
                        funArray[i, j] = 0;
                        continue;
                    }
                    if(values[j] >= 255.0) {
                        funArray[i, j] = 255;
                        continue;
                    }
                    funArray[i, j] = (int) values[j];
                }
            }
            return funArray;
        }
        #endregion
    }
}
