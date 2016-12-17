using System;
using System.Drawing;

namespace ImageProcessingForm {
    public interface IView {
        event EventHandler<BitmapEventArgs> imageSelected;
        event EventHandler resultImageRequest;

        void error(string message);
        void setResultImage(Bitmap image);
    }
}
