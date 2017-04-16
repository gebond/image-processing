using System.Drawing;

namespace ImageProcessingModel {
    public interface IModel {
        
        // image methods
        bool validate();
        bool setSourceImage(Bitmap bitMap);
        Bitmap getResultImage();

        //params methods
        bool setRPercentage(double r_percentage);
        bool setGPercentage(double g_percentage);
        bool setBPercentage(double b_percentage);

        bool setFourierByMatrix();
        bool setFourierByWalsh();
        bool setFourierByHaart();
        bool setElementSize(int elementSize);

        double getRMSE();
        double getRPSNR();
        double getBMSE();
        double getBPSNR();
        double getGMSE();
        double getGPSNR();
    }
}
