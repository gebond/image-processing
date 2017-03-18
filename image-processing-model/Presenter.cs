using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessingForm;
using ImageProcessingConstants;

namespace ImageProcessingModel {
    public class Presenter : IPresenter, IDisposable {

        public Presenter() {
            model = new Model();
            Console.WriteLine("[Presenter] was initialized successfully");
        }

        #region IPresenter implemenation
        public void initView(IView view) {
            if(view != null) {
                this.view = view;
            }
            view.imageSelected += onImageSelected;
            view.resultImageRequest += onResultImageRequest;
            Console.WriteLine("[View] was initialized - all events are handled");
        }

        public void process() {
            if(!tryGetAllParams()) {
                return;
            }
            if(model.validate()) {
                var resultImage = model.getResultImage();
                if(resultImage != null) {
                    view.setResultImage(resultImage);
                }
                else {
                    view.error("ERROR! result image was null");
                }
            }
            else {
                view.error("ERROR! source image was null");
            }
        }
        public void onImageSelected(object sender, BitmapEventArgs args) {
            var image = args.Bitmap;
            if(image != null && model.setSourceImage(image)) {
                Console.WriteLine("[Presenter] image was send");
            }
            else { Console.WriteLine("[Presenter] image was incorrect - skip"); }
        }
        public void onResultImageRequest(object sender, EventArgs args) {
            process();
        }
        public void onParamInserted(object sender, ParameterNumberEventArgs args) {
            var value = args.Number;
            var parameter = args.Parameter;
            if(parameter.Equals(ImageConstants.RED_PERCENTAGE)) {
                if(model.setRPercentage(value)) {
                    Console.WriteLine("[Presenter] r_percantage is set to {0}%", value);
                }
                else {
                    Console.WriteLine("[Presenter] r_percantage was not set");
                    view.error(ImageConstants.RED_PERCENTAGE + " must be from 0 to 100!");
                }
            }
            if(parameter.Equals(ImageConstants.GREEN_PERCENTAGE)) {
                if(model.setGPercentage(value)) {
                    Console.WriteLine("[Presenter] g_percantage is set to {0}%", value);
                }
                else {
                    Console.WriteLine("[Presenter] g_percantage was not set");
                    view.error(ImageConstants.GREEN_PERCENTAGE + " must be from 0 to 100!");
                }
            }
            if(parameter.Equals(ImageConstants.BLUE_PERCENTAGE)) {
                if(model.setRPercentage(value)) {
                    Console.WriteLine("[Presenter] b_percantage is set to {0}%", value);
                }
                else {
                    Console.WriteLine("[Presenter] b_percantage was not set");
                    view.error(ImageConstants.BLUE_PERCENTAGE + " must be from 0 to 100!");
                }
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
        IModel model;
        #endregion

        #region privateMethods
        private bool tryGetAllParams() {
            if(view == null) {
                return false;
            }
            if(!setParams()) {
                view.error("ERROR! can not get param");
                return false;
            }
            if(!setSelectedMethod()) {
                view.error("ERROR! can not get selected method");
                return false;
            }
            return true;
        }
        bool setParams() {
            var R_percentage = view.getParameterValue(ImageConstants.RED_PERCENTAGE);
            if(!model.setRPercentage(R_percentage)) {
                view.error(ImageConstants.RED_PERCENTAGE + "is incorrect");
                return false;
            }
            var G_percentage = view.getParameterValue(ImageConstants.GREEN_PERCENTAGE);
            if(!model.setGPercentage(G_percentage)) {
                view.error(ImageConstants.GREEN_PERCENTAGE + "is incorrect");
                return false;
            }
            var B_percentage = view.getParameterValue(ImageConstants.BLUE_PERCENTAGE);
            if(!model.setBPercentage(B_percentage)) {
                view.error(ImageConstants.BLUE_PERCENTAGE + "is incorrect");
                return false;
            }
            var size = view.getParameterValue(ImageConstants.ELEMENT_SIZE);
            if(!model.setElementSize((int)size)) {
                view.error(ImageConstants.ELEMENT_SIZE + "is incorrect");
                return false;
            }
            return true;
        } 
        bool setSelectedMethod() {
            var selected_method = view.getSelectedFourierMethod();
            if(selected_method == null) {
                return false;
            }
            if(selected_method.Equals(ImageConstants.FOURIER_BY_MATRIX)) {
                model.setFourierByMatrix();
                return true;
            }
            if(selected_method.Equals(ImageConstants.FOURIER_BY_WALSH)) {
                model.setFourierByWalsh();
                return true;
            }
            if(selected_method.Equals(ImageConstants.FOURIER_BY_HAART)) {
                model.setFourierByHaart();
                return true;
            }
            return false;
        }
        #endregion
    }
}
