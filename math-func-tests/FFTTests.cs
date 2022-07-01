using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathFunction;

namespace MathModuleTests {
    [TestClass]
    public class FFTTests {

        FourierTransformation transformation;

        [TestInitialize]
        public void initTests() {
            transformation = new FastFourierTransformationByFrequency();
        }

        [TestMethod]
        public void fft_init() {

        }

        [TestMethod]
        public void fft_analysis() {
            var values = new double[] { 10, -2, 3, -40 };
            var coeffs = transformation.doAnalysis(values);
            Console.WriteLine("12");
        }

        [TestMethod]
        public void fft_synthesis() {
            var coeffs = new double[] { 10, -2, 3, -40};
            var values = transformation.doSynthesis(coeffs);
            Console.WriteLine("12");
        }

        [TestMethod]
        public void fft_algorithm() {
            var values = new double[] { 10, -2, 3, -40 };
            var coeffs = transformation.doAnalysis(values);
            var result = transformation.doSynthesis(coeffs);
            Console.WriteLine("12");
        }
    }
}
