using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessingForm;

namespace ImageProcessingModel {
    public class Presenter : IPresenter, IDisposable {

        public Presenter() {
            model = new MathModel();
            Console.WriteLine("[Presenter] was initialized successfully");
        }

        #region IModel implemenation
        public void initView(IView view) {
            if(view != null) {
                this.view = view;
            }
            view.imageSelected += onImageSelected;
            view.resultImageRequest += onResultImageRequest;
            Console.WriteLine("[View] was initialized - all events are handled");
        }

        public void process() {
        }
        public void onImageSelected(object sender, BitmapEventArgs args) {
            var image = args.Bitmap;
            if(image != null && model.setSourceImage(image)) {
                Console.WriteLine("[Presenter] image was send");
            }
            else { Console.WriteLine("[Presenter] image was incorrect - skip"); }
        }
        public void onResultImageRequest(object sender, EventArgs args) {
            var resultImage = model.getResultImage();
            if(resultImage != null) {
                view.setResultImage(resultImage);
            }
            else {
                view.error("ERROR! result image was null");
            }
        }
        public void Dispose() {
            if(view != null) {
                view.imageSelected += onImageSelected;
            }
        }

        #endregion

        #region privateFields
        IView view;
        IMathModel model;
        #endregion

        #region privateMethods

        #endregion
    }
}
