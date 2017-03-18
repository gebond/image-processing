using MathFunction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathModuleTests {
    [TestClass]
    public class FunctionUnitTests {

        #region Rademacher
        [TestMethod]
        public void applyingRademacherCorrect() {
            Assert.AreEqual(-1, FunctionUtils.rademacher(-0.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(0));
            Assert.AreEqual(1, FunctionUtils.rademacher(0.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(0.25));
            Assert.AreEqual(1, FunctionUtils.rademacher(0.49));
            Assert.AreEqual(1, FunctionUtils.rademacher(1.0));

            Assert.AreEqual(-1, FunctionUtils.rademacher(0.5));
            Assert.AreEqual(-1, FunctionUtils.rademacher(0.51));
            Assert.AreEqual(-1, FunctionUtils.rademacher(0.75));
            Assert.AreEqual(-1, FunctionUtils.rademacher(0.99));
            Assert.AreEqual(1, FunctionUtils.rademacher(1.0));
            Assert.AreEqual(1, FunctionUtils.rademacher(1.01));
        }
        [TestMethod]
        public void applyingRademacherKth() {

        }
        #endregion

        #region Pelly
        [TestMethod]
        public void paley_poweroftwo() {
            var res = FunctionUtils.paley(1);
            CollectionAssert.AreEqual(res, new int[] { 1 }, "paley for 1 is wrong");

            res = FunctionUtils.paley(2);
            CollectionAssert.AreEqual(res, new int[] { 0, 1 }, "paley for 2 is wrong");

            res = FunctionUtils.paley(8);
            CollectionAssert.AreEqual(res, new int[] { 0, 0, 0, 1 }, "paley for 8 is wrong");
        }
        [TestMethod]
        public void paley_no_poweroftwo() {

            var res = FunctionUtils.paley(3);
            CollectionAssert.AreEqual(res, new int[] { 1, 1 }, "paley for 3 is wrong");

            res = FunctionUtils.paley(6);
            CollectionAssert.AreEqual(res, new int[] { 0, 1, 1 }, "paley for 6 is wrong");


            res = FunctionUtils.paley(8);
            CollectionAssert.AreEqual(res, new int[] { 0, 0, 0, 1 }, "paley for 8 is wrong");

            res = FunctionUtils.paley(13);
            CollectionAssert.AreEqual(res, new int[] { 1, 0, 1, 1 }, "paley for 13 is wrong");
        }
        #endregion

        #region Walsh

        [TestMethod]
        public void applyingWalsh() {
        }
        #endregion

        #region Haart
        [TestMethod]
        public void applyingHaart() {
        }
        #endregion

        #region Compression
        [TestMethod]
        public void applyingCompression() {
            var mass = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            double coef = 50;
            mass = ComressionUtils.compress(mass, coef);
            var answer = new double[,] { { 0, 0, 3 }, { 0, 2, 3 }, { 0, 2, 3 } };
            CollectionAssert.AreEquivalent(answer, mass);
            var mass2 = new int[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            coef = 12;
            mass2 = ComressionUtils.compress(mass2, coef);
            var answer2 = new int[,] { { 0, 0, 0 }, { 0, 0, 3 }, { 0, 0, 3 } };
            CollectionAssert.AreEquivalent(answer2, mass2);
        }
        #endregion
    }
}
