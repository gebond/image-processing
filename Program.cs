using ImageProcessingModel;
using System;
using System.Windows.Forms;
using MathFunction;
using LinearAlgebra;

namespace ImageProcessing_v1 {
    class Program {
        /*static void Main(string[] args) {
            var transformWalsh = new FourierWalshTransformation();
            var transformHaart = new FourierHaartTransformation();
            var transformFreq = new FastFourierTransformationByFrequency();
        
            var arrayInput = new double[] { 36, -16, 0, -8, 0, 0, 0, -4};
            //var arrayInput = new double[] { 1, 1, 1, 1};
            //var arrayInput = new double[] { 1, 1};
            //var arrayInput = new double[] { 1};


            var vectorWalsh = new DoubleVector(transformWalsh.doAnalysis(arrayInput));
            var vectorHaart = new DoubleVector(transformHaart.doAnalysis(arrayInput));
            var vectorFreq = new DoubleVector(transformFreq.doAnalysis(arrayInput));

            Console.WriteLine("\n#############################");
            Console.WriteLine("#######     INPUT    ########");
            Console.WriteLine("#############################\n");
            Console.WriteLine(((DoubleVector) new DoubleVector(arrayInput)).ToString());
            Console.WriteLine("\n#############################");
            Console.WriteLine("#######     COEFFS    #######");
            Console.WriteLine("#############################\n");
            Console.WriteLine("Walsh coeefs:" + vectorWalsh.ToString());
            Console.WriteLine("Haart coeefs:" + vectorHaart.ToString());
            Console.WriteLine("Freq coeefs:" + vectorFreq.ToString());
            Console.WriteLine("\n#############################");
            Console.WriteLine("#######   RESULTS    ########");
            Console.WriteLine("#############################\n");

            /*vectorWalsh = new DoubleVector(transformWalsh.doSynthesis(vectorWalsh.ToArray()));
            vectorHaart = new DoubleVector(transformHaart.doSynthesis(vectorHaart.ToArray()));
            vectorFreq = new DoubleVector(transformFreq.doSynthesis(vectorFreq.ToArray()));

            Console.WriteLine("Walsh values:" + vectorWalsh.ToString());
            Console.WriteLine("Haart values:" + vectorHaart.ToString());
            Console.WriteLine("Freq values:" + vectorFreq.ToString());
            Console.ReadKey();
        }*/
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
