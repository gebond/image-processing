using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessingModel {
    class MathModel : IMathModel {

        public MathModel() {
            Console.WriteLine("Model was initialized successfully");
        }

        #region IModel implemenation
        public bool setSourceImage(Bitmap bitMap) {
            throw new NotImplementedException();
        }
        #endregion

        #region privateFields
        
        #endregion

        #region privateMethods

        #endregion
    }
}
