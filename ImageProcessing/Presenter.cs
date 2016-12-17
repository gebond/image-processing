using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessingForm;

namespace ImageProcessingModel {
    public class Presenter : IPresenter {

        public Presenter() {
            model = new MathModel();
            Console.WriteLine("Presenter was initialized successfully");
        }

        #region IModel implemenation
        public void initView(IView view) {
            if(view != null) {
                this.view = view;
            }
        }

        public void process() {
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
