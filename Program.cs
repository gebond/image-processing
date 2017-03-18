using ImageProcessingModel;
using ImageProcessingForm;
using System;
using System.Windows.Forms;
using MathFunction;

namespace ImageProcessing_v1 {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Console.WriteLine("[STAThread] started");
            IPresenter presenter = new Presenter();
            var view = new ImageProcessingForm.View();


            presenter.initView(view);
            //presenter.process();


            Application.EnableVisualStyles();
            Application.Run(view);
            Console.WriteLine("View was Run");
        }
    }
}
