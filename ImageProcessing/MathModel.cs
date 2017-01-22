using MathFunctionModule;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessingModel {
    class MathModel : IMathModel {

        public MathModel() {
            Console.WriteLine("\t[Model] was initialized successfully");
            init();
            Console.WriteLine("\t[Model] params: r_p={0}% g_p={1}% b_p={2}%",
                r_percentage, g_percentage, b_percentage);
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
        #endregion

        #region privateFields
        // image
        Bitmap sourceImage;
        Bitmap resultImage;
        // parameters
        double r_percentage;
        double g_percentage;
        double b_percentage;
        #endregion

        #region privateMethods
        private void init() {
            sourceImage = null;
            resultImage = null;
            r_percentage = 100.0;
            g_percentage = 100.0;
            b_percentage = 100.0;
        }
        private bool validate_percentage(double percentage) {
            if(percentage >= 0 && percentage <= 100) {
                return true;
            }
            Console.WriteLine("percentage {0} is incorrect", percentage);
            return false;
        }
        private bool processImage() {
            if(sourceImage == null) {
                return false;
            }
            var colorElements = new ColorElements(8, sourceImage);
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
            var reds = sourceColorElement.getRColors();
            var greens = sourceColorElement.getGColors();
            var blues = sourceColorElement.getBColors();
            ImageComressionUtils.compress(reds, this.r_percentage);
            ImageComressionUtils.compress(greens, this.g_percentage);
            ImageComressionUtils.compress(blues, this.b_percentage);
            Console.WriteLine("\t[Model] Reds, greens, blues matrixes was get from source Element");
            return new ColorElement(reds, greens, blues);
        }

        #endregion
    }
}
