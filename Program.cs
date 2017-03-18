using ImageProcessingModel;
using System;
using System.Windows.Forms;

namespace ImageProcessing_v1 {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Console.WriteLine("[STAThread] started");
            IPresenter presenter = new Presenter();
            var view = new ImageProcessingForm.View();

            presenter.initView(view);

            Application.EnableVisualStyles();
            Application.Run(view);
            Console.WriteLine("View was Run");
        }
    }
}
