using System;
using System.Drawing;

namespace ImageProcessingForm {
    public class BitmapEventArgs : EventArgs {
        private Bitmap bitmap;

        public BitmapEventArgs(Bitmap bitmap) {
            if(bitmap != null) {
                this.bitmap = bitmap;
            }
            else {
                throw new ArgumentNullException("bimap = null");
            }
        }

        public Bitmap Bitmap {
            get { return bitmap; }
        }
    }
}
