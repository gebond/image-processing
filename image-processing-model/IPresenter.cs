using ImageProcessingForm;
using System;

namespace ImageProcessingModel {
    public interface IPresenter {
        void initView(IView view);

        void onImageSelected(object sender, BitmapEventArgs args);
        void onResultImageRequest(object sender, EventArgs args);

        //void onParamInserted(object sender, ColorParameterNumberEventArgs args);
    }
}
