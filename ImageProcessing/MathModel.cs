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
            resultImage = new Bitmap(sourceImage);
            int width = resultImage.Width;
            int height = resultImage.Height;
            Color newColor = Color.Red;
            for(int x = 0; x < width; x++) {
                for(int y = 0; y < height; y++) {
                    Color oldColor = resultImage.GetPixel(x, y);
                    if(oldColor.R <= 100)
                        resultImage.SetPixel(x, y, newColor);
                }
            }
            return true;
        }
        #endregion
    }
}
