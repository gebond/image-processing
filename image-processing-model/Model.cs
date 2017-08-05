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
            Console.WriteLine("\t[Model] params: 1_p={0}% 2_p={1}% 3_p={2}% selectedMetod:{3}",
                percentage_1, percentage_2, percentage_3, selectedTransformation);
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

        public bool setYCrCbEnabled(bool ycrcbenabled) {
            this.ycrcbenabled = ycrcbenabled;
            return true;
        }

        public bool setPercentage1(double percentage_1) {
            if(validate_percentage(percentage_1)) {
                this.percentage_1 = percentage_1;
                return true;
            }
            return false;
        }
        public bool setPercentage2(double percentage_2) {
            if(validate_percentage(percentage_2)) {
                this.percentage_2 = percentage_2;
                return true;
            }
            return false;
        }
        public bool setPercentage3(double percentage_3) {
            if(validate_percentage(percentage_3)) {
                this.percentage_3 = percentage_3;
                return true;
            }
            return false;
        }
        public bool setFourierByLocal() {
            selectedTransformation = new FourierDescreteTransformation();
            Console.WriteLine("\t[Model] selected Local");
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
        public double getRMSE() {
            return getMSE(ImageColor.RED);
        }

        public double getRPSNR() {

            return getPSNR(ImageColor.RED);
        }

        public double getBMSE() {
            return getMSE(ImageColor.BLUE);
        }

        public double getBPSNR() {

            return getPSNR(ImageColor.BLUE);
        }

        public double getGMSE() {
            return getMSE(ImageColor.GREEN);
        }

        public double getGPSNR() {

            return getPSNR(ImageColor.GREEN);
        }
        #endregion

        #region privateFields
        // image
        Bitmap sourceImage;
        Bitmap resultImage;
        // parameters
        double percentage_1;
        double percentage_2;
        double percentage_3;
        bool ycrcbenabled;
        int elementSize;
        FourierTransformation selectedTransformation;
        #endregion

        #region privateMethods
        private void init() {
            sourceImage = null;
            resultImage = null;
            percentage_1 = 100.0;
            percentage_2 = 100.0;
            percentage_3 = 100.0;
            ycrcbenabled = false;
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
            Console.WriteLine("\t[Model] Current percentages: R-{0}% G-{1}% B-{2}%", percentage_1,
                percentage_2, percentage_3);
            var colorElements = new ColorElements(elementSize, sourceImage);
            colorElements.processElements(ycrcbenabled, percentage_1, percentage_2, percentage_3, selectedTransformation);
            resultImage = colorElements.buildImage(ycrcbenabled);
            return resultImage != null;
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
        private double getMSE(ImageColor color) {
            var result = 0.0;
            for(int x = 0; x < resultImage.Width; x++) {
                for(int y = 0; y < resultImage.Height; y++) {
                    Color sourcePixel = sourceImage.GetPixel(x, y);
                    Color resultPixel = resultImage.GetPixel(x, y);
                    int sourceValue = 0;
                    int resultValue = 0;
                    switch(color) {
                        case ImageColor.RED:
                            sourceValue = sourcePixel.R;
                            resultValue = resultPixel.R;
                            break;
                        case ImageColor.GREEN:
                            sourceValue = sourcePixel.G;
                            resultValue = resultPixel.G;
                            break;
                        case ImageColor.BLUE:
                            sourceValue = sourcePixel.B;
                            resultValue = resultPixel.B;
                            break;
                        default:
                            break;
                    }
                    result += Math.Pow(Math.Abs(sourceValue - resultValue), 2);
                }
            }
            return result / (resultImage.Width * resultImage.Height);
        }
        private double getPSNR(ImageColor color) {
            var mse = getMSE(color);
            return 10 * Math.Log10(255 * 255 / mse);
        }
        #endregion
    }
}
