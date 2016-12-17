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
                Console.WriteLine("[Model] source image was set");
                return true;
            }
            else {
                return false;
            }
        }
        #endregion

        #region privateFields
        Bitmap sourceImage;
        #endregion

        #region privateMethods

        #endregion
    }
}
