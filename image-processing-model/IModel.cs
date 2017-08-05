using System.Drawing;

namespace ImageProcessingModel {
    public interface IModel {
        
        // image methods
        bool validate();
        bool setSourceImage(Bitmap bitMap);
        Bitmap getResultImage();

        //params methods
        bool setPercentage1(double percentage_1);
        bool setPercentage2(double percentage_2);
        bool setPercentage3(double percentag_3);
        bool setYCrCbEnabled(bool yCrCbEnabled);

        bool setFourierByLocal();
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
