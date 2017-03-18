using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathFunction;

namespace MathModuleTests {
    [TestClass]
    public class WalshTransfTests {
        FourierWalshTransformation transformation;

        [TestInitialize]
        public void initTests() {
            transformation = new FourierWalshTransformation();
        }

        [TestMethod]
        public void walsh_transf_init_args() {
            var mass = new double[] { 1.0, 1.5};
            transformation.doAnalysis(mass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void walsh_transf_init_fail_args() {
            var wrongmass = new double[] { 1.0, 2.0, 3.0 };
            transformation.doAnalysis(wrongmass);
            Assert.IsNull(transformation.doAnalysis(null));
        }

        [TestMethod]
        public void walsh_transf_init_analysis() {
            var func_values = new double[] { 1.0, 2.0, 3.0, 4.0};
            var answer = transformation.doAnalysis(func_values);
        }

        [TestMethod]
        public void walsh_transf_init_synthesis() {
            var coeffs = new double[] { 1.0, 2.0, 3.0, 4.0};
            var answer = transformation.doSynthesis(coeffs);
        }

        [TestMethod]
        public void walsh_transf_full() {
            var func_values = new double[] { 1.0, 2.0};
            var coeffs = transformation.doAnalysis(func_values);
            var func_values_transformed = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);
        }
    }
}
