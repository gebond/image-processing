using ImageProcessingModel;
using ImageProcessingForm;
using System;
using System.Windows.Forms;

namespace ImageProcessing_v1 {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            IPresenter presenter = new Presenter();
            var view = new ImageProcessingForm.View();

            Application.EnableVisualStyles();
            Application.Run(view);
            
            presenter.initView(view);
            presenter.process();
        }
    }
}
