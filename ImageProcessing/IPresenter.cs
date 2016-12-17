using ImageProcessingForm;

namespace ImageProcessingModel {
    public interface IPresenter {
        void initView(IView view);
        void process();

    }
}
