using System;
using System.Drawing;

namespace ImageProcessingForm {
    public interface IView {
        event EventHandler<BitmapEventArgs> imageSelected;
        event EventHandler resultImageRequest;
        event EventHandler<ParameterNumberEventArgs> parameterInserted;


        void error(string message);
        void setResultImage(Bitmap image);
        double getParameterValue(string parameter_str);
    }
}
