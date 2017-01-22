using System.Drawing;

namespace ImageProcessingModel {
    public interface IMathModel {



        // image methods
        bool validate();
        bool setSourceImage(Bitmap bitMap);
        Bitmap getResultImage();

        //params methods
        bool setRPercentage(double r_percentage);
        bool setGPercentage(double g_percentage);
        bool setBPercentage(double b_percentage);
    }
}
