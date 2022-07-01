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
        public void haart_0() {
            Assert.AreEqual(1, FunctionUtils.haart(0, 0, -1.5));
            Assert.AreEqual(1, FunctionUtils.haart(0, 0, 0.25));
            Assert.AreEqual(1, FunctionUtils.haart(0, 0, 0.5));
            Assert.AreEqual(1, FunctionUtils.haart(0, 0, 0.75));
            Assert.AreEqual(1, FunctionUtils.haart(0, 0, 1.5));
        }
        [TestMethod]
        public void haart_0_1() {
            Assert.AreEqual(1, FunctionUtils.haart(0, 1, 0.00));
            Assert.AreEqual(1, FunctionUtils.haart(0, 1, 0.01));
            Assert.AreEqual(1, FunctionUtils.haart(0, 1, 0.49));
            Assert.AreEqual(-1, FunctionUtils.haart(0, 1, 0.5));
            Assert.AreEqual(-1, FunctionUtils.haart(0, 1, 0.51));
        }
        [TestMethod]
        public void haart_1_1() {
            Assert.AreEqual(1, FunctionUtils.haart(1, 1, 0.00));
            Assert.AreEqual(1, FunctionUtils.haart(1, 1, 0.01));
            Assert.AreEqual(1, FunctionUtils.haart(1, 1, 0.24));
            Assert.AreEqual(-1, FunctionUtils.haart(1, 1, 0.25));
            Assert.AreEqual(-1, FunctionUtils.haart(1, 1, 0.26));
            Assert.AreEqual(-1, FunctionUtils.haart(1, 1, 0.49));
            Assert.AreEqual(0, FunctionUtils.haart(1, 1, 0.51));
            Assert.AreEqual(0, FunctionUtils.haart(1, 1, 0.74));
            Assert.AreEqual(0, FunctionUtils.haart(1, 1, 0.99));
        }
        [TestMethod]
        public void haart_1_2() {
            Assert.AreEqual(0, FunctionUtils.haart(1, 2, 0.00));
            Assert.AreEqual(0, FunctionUtils.haart(1, 2, 0.01));
            Assert.AreEqual(0, FunctionUtils.haart(1, 2, 0.24));
            Assert.AreEqual(0, FunctionUtils.haart(1, 2, 0.25));
            Assert.AreEqual(0, FunctionUtils.haart(1, 2, 0.26));
            Assert.AreEqual(0, FunctionUtils.haart(1, 2, 0.49));
            Assert.AreEqual(1, FunctionUtils.haart(1, 2, 0.50));
            Assert.AreEqual(1, FunctionUtils.haart(1, 2, 0.51));
            Assert.AreEqual(1, FunctionUtils.haart(1, 2, 0.74));
            Assert.AreEqual(-1, FunctionUtils.haart(1, 2, 0.75));
            Assert.AreEqual(-1, FunctionUtils.haart(1, 2, 0.99));
        }
        [TestMethod]
        public void haart_2() {
            Assert.AreEqual(1, FunctionUtils.haart(2, 1, 0.00));
            Assert.AreEqual(1, FunctionUtils.haart(2, 1, 0.01));
            Assert.AreEqual(1, FunctionUtils.haart(2, 1, 0.124));
            Assert.AreEqual(-1, FunctionUtils.haart(2, 1, 0.125));
            Assert.AreEqual(-1, FunctionUtils.haart(2, 1, 0.126));
            Assert.AreEqual(-1, FunctionUtils.haart(2, 1, 0.24));
            Assert.AreEqual(0, FunctionUtils.haart(2, 1, 0.25));
            Assert.AreEqual(0, FunctionUtils.haart(2, 1, 0.51));
            Assert.AreEqual(0, FunctionUtils.haart(2, 1, 0.99));
        }

        [TestMethod]
        public void haart_n() {
            Assert.AreEqual(1, FunctionUtils.haart(0, 0.00));
            Assert.AreEqual(1, FunctionUtils.haart(1, 0.49));
            Assert.AreEqual(-1, FunctionUtils.haart(1, 0.5));

            Assert.AreEqual(1, FunctionUtils.haart(4, 0.00));
            Assert.AreEqual(1, FunctionUtils.haart(4, 0.01));
            Assert.AreEqual(1, FunctionUtils.haart(4, 0.124));
            Assert.AreEqual(-1, FunctionUtils.haart(4, 0.125));
            Assert.AreEqual(-1, FunctionUtils.haart(4, 0.126));
            Assert.AreEqual(-1, FunctionUtils.haart(4, 0.24));
            Assert.AreEqual(0, FunctionUtils.haart(4, 0.25));
            Assert.AreEqual(0, FunctionUtils.haart(4, 0.51));
            Assert.AreEqual(0, FunctionUtils.haart(4, 0.99));
        }
        [TestMethod]
        public void haart_big_n() {
            Assert.AreEqual(0, FunctionUtils.haart(7, 0.50));
            Assert.AreEqual(1, FunctionUtils.haart(7, 0.874));
            Assert.AreEqual(-1, FunctionUtils.haart(7, 0.99));
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

            func_values = new double[] { 10.0, 20.0, 30.0, 40.0 };
            coeffs = transformation.doAnalysis(func_values);
            func_values_transformed = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);

            func_values = new double[] { 10.0, 20.0, 30.0, 40.0, 50.0, 60.0, 70.0, 80.0 };
            coeffs = transformation.doAnalysis(func_values);
            func_values_transformed = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(func_values, func_values_transformed);
        }
    }
}
