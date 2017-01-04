using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessingModel {
    class MathModel : IMathModel {

        public MathModel() {
            Console.WriteLine("\t[Model] was initialized successfully");
        }

        #region IModel implemenation
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
                return resultImage;
            }
            else { return null; }
        }
        #endregion

        #region privateFields
        Bitmap sourceImage;
        Bitmap resultImage;
        #endregion

        #region privateMethods
        private bool processImage() {
            if(sourceImage == null) {
                return false;
            }
            var colorElements = new ColorElements(8, sourceImage);
            // do with colorElements something else
            // then try to build result colorelements
            processElements(colorElements);
            resultImage = colorElements.buildImage();
            return resultImage != null;
        }
        private void processElements(ColorElements elements) {

        }
        #endregion
    }
}
