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

        public void onImageSelected(object sender, BitmapEventArgs args) {
            var image = args.Bitmap;
            if(image != null && model.setSourceImage(image)) {
                Console.WriteLine("[Presenter] image was send");
            }
            else { Console.WriteLine("[Presenter] image was incorrect - skip"); }
        }
        public void onResultImageRequest(object sender, EventArgs args) {
            processImage();
            getAndSetParams();
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
        private void processImage() {
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
        private void getAndSetParams() {
            if(view.getParameterValue(ImageConstants.MSE_PSNR_CALCULATE) == 0) {
                return;
            }
            view.setColorParameterValue(ImageColor.RED, ImageConstants.PARAM_MSE, model.getRMSE());
            view.setColorParameterValue(ImageColor.RED, ImageConstants.PARAM_PSNR, model.getRPSNR());
            view.setColorParameterValue(ImageColor.BLUE, ImageConstants.PARAM_MSE, model.getBMSE());
            view.setColorParameterValue(ImageColor.BLUE, ImageConstants.PARAM_PSNR, model.getBPSNR());
            view.setColorParameterValue(ImageColor.GREEN, ImageConstants.PARAM_MSE, model.getGMSE());
            view.setColorParameterValue(ImageColor.GREEN, ImageConstants.PARAM_PSNR, model.getGPSNR());
        }
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
        private bool setParams() {
            model.setYCrCbEnabled(view.getParameterValue(ImageConstants.YCRCB_ENABLED) == 1);
            if(view.getParameterValue(ImageConstants.YCRCB_ENABLED) != 1) {
                var R_percentage = view.getColorParameterValue(ImageColor.RED, ImageConstants.PERCENTAGE);
                if(!model.setPercentage1(R_percentage)) {
                    view.error(ImageConstants.PERCENTAGE + " is incorrect");
                    return false;
                }
                var G_percentage = view.getColorParameterValue(ImageColor.GREEN, ImageConstants.PERCENTAGE);
                if(!model.setPercentage2(G_percentage)) {
                    view.error(ImageConstants.PERCENTAGE + " is incorrect");
                    return false;
                }
                var B_percentage = view.getColorParameterValue(ImageColor.BLUE, ImageConstants.PERCENTAGE);
                if(!model.setPercentage3(B_percentage)) {
                    view.error(ImageConstants.PERCENTAGE + " is incorrect");
                    return false;
                }
            }
            else {
                var Y_percentage = view.getColorParameterValue(ImageColor.Y, ImageConstants.PERCENTAGE);
                if(!model.setPercentage1(Y_percentage)) {
                    view.error(ImageConstants.PERCENTAGE + " is incorrect");
                    return false;
                }
                var Cr_percentage = view.getColorParameterValue(ImageColor.CR, ImageConstants.PERCENTAGE);
                if(!model.setPercentage2(Cr_percentage)) {
                    view.error(ImageConstants.PERCENTAGE + " is incorrect");
                    return false;
                }
                var Cb_percentage = view.getColorParameterValue(ImageColor.CB, ImageConstants.PERCENTAGE);
                if(!model.setPercentage3(Cb_percentage)) {
                    view.error(ImageConstants.PERCENTAGE + " is incorrect");
                    return false;
                }
            }
            var size = view.getParameterValue(ImageConstants.ELEMENT_SIZE);
            if(!model.setElementSize((int)size)) {
                view.error(ImageConstants.ELEMENT_SIZE + " is incorrect");
                return false;
            }
            return true;
        } 
        private bool setSelectedMethod() {
            var selected_method = view.getSelectedFourierMethod();
            if(selected_method == null) {
                return false;
            }
            if(selected_method.Equals(ImageConstants.FOURIER_BY_LOCAL)) {
                model.setFourierByLocal();
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
