using System;
using System.Drawing;
using ImageProcessingConstants;

namespace ImageProcessingForm {
    public interface IView {
        event EventHandler<BitmapEventArgs> imageSelected;  
        event EventHandler resultImageRequest;
        //event EventHandler<ColorParameterNumberEventArgs> parameterInserted;


        void error(string message);
        void setResultImage(Bitmap image);
        double getColorParameterValue(ImageColor color, string parameter_str);
        double getParameterValue(string parameter_str);
        string getSelectedFourierMethod();
        void setColorParameterValue(ImageColor color, string parameter_str, double value);
    }
}
