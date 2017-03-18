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
        public void analysisGoodArgs() {
            var mass = new double[] { 1.0, 1.5};
            transformation.doAnalysis(mass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void analysisWrongArgs() {
            var wrongmass = new double[] { 1.0, 2.0, 3.0 };
            transformation.doAnalysis(wrongmass);
            Assert.IsNull(transformation.doAnalysis(null));
        }

        [TestMethod]
        public void analysisAlgorithm() {
            var func_values = new double[] { 1.0, 2.0, 3.0, 4.0};
            var answer = transformation.doAnalysis(func_values);
        }

        [TestMethod]
        public void syntesisAlgorithm() {
            var coeffs = new double[] { 1.0, 2.0, 3.0, 4.0};
            var answer = transformation.doSynthesis(coeffs);
        }

        [TestMethod]
        public void transAlgorithm() {
            var func_values = new double[] { 1.0, 2.0, 3.0, 4.0 };
            var coeffs = transformation.doAnalysis(func_values);
            var func_values_transformed = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);
        }

        [TestMethod]
        public void transAlgorithmHaart() {
            var transHaart = new FourierHaartTransformation();
            var func_values = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 };
            var coeffs = transHaart.doAnalysis(func_values);
            var func_values_transformed = transHaart.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);
        }
    }
}
