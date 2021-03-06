﻿using System;
using System.Drawing;

namespace ImageProcessingForm {
    public class BitmapEventArgs : EventArgs {
        private Bitmap bitmap;

        public BitmapEventArgs(Bitmap bitmap) {
            if(bitmap != null) {
                this.bitmap = bitmap;
            }
        }

        public Bitmap Bitmap {
            get { return bitmap; }
        }
    }
}
