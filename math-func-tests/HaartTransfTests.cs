using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathFunction;

namespace MathModuleTests {
    [TestClass]
    public class HaartTransfTests {
        FourierHaartTransformation transformation;

        [TestInitialize]
        public void initTests() {
            transformation = new FourierHaartTransformation();
        }

        [TestMethod]
        public void haart_transf_init_args() {
            var mass = new double[] { 1.0, 1.5 };
            transformation.doAnalysis(mass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void haart_transf_init_fail_args() {
            var wrongmass = new double[] { 1.0, 2.0, 3.0 };
            transformation.doAnalysis(wrongmass);
            Assert.IsNull(transformation.doAnalysis(null));
        }

        [TestMethod]
        public void haart_transf_init_analysis() {
            var func_values = new double[] { 1.0, 2.0, 3.0, 4.0 };
            var answer = transformation.doAnalysis(func_values);
        }

        [TestMethod]
        public void haart_transf_init_synthesis() {
            var coeffs = new double[] { 1.0, 2.0, 3.0, 4.0 };
            var answer = transformation.doSynthesis(coeffs);
        }

        [TestMethod]
        public void haart_transf_full() {
            var func_values = new double[] { 10.0, 20.0 };
            var coeffs = transformation.doAnalysis(func_values);
            var func_values_transformed = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);

            func_values = new double[] { 150.0, 250.0, 0.0, 15.0 };
            coeffs = transformation.doAnalysis(func_values);
            func_values_transformed = transformation.doSynthesis(coeffs);
            //CollectionAssert.AreEquivalent(func_values, func_values_transformed);

            func_values = new double[] { 150.0, -250.0, 0.0, 15.0, -150.0, 250.0, 35.0, 15.0 };
            coeffs = transformation.doAnalysis(func_values);
            func_values_transformed = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);
        }
    }
}
