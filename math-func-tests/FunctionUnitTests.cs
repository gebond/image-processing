using MathFunction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathModuleTests {
    [TestClass]
    public class FunctionUnitTests {

        #region Rademacher
        // x = {0 .. 1}
        [TestMethod]
        public void rademacher_0() {
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
        // x = {k .. k+1} k>=1
        [TestMethod]
        public void rademacher_0_period() {
            Assert.AreEqual(-1, FunctionUtils.rademacher(0.99));
            Assert.AreEqual(1, FunctionUtils.rademacher(1));
            Assert.AreEqual(1, FunctionUtils.rademacher(1.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(1.25));
            Assert.AreEqual(1, FunctionUtils.rademacher(1.49));
            Assert.AreEqual(1, FunctionUtils.rademacher(2.0));

            Assert.AreEqual(-1, FunctionUtils.rademacher(1.5));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1.51));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1.75));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1.99));
            Assert.AreEqual(1, FunctionUtils.rademacher(2.0));
            Assert.AreEqual(1, FunctionUtils.rademacher(2.01));
        }
        // x = {k .. k-1} k<=0
        [TestMethod]
        public void rademacher_0_neg_period() {
            Assert.AreEqual(-1, FunctionUtils.rademacher(-1.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(-1));
            Assert.AreEqual(1, FunctionUtils.rademacher(-0.99));
            Assert.AreEqual(-1, FunctionUtils.rademacher(-0.49));

            Assert.AreEqual(-1, FunctionUtils.rademacher(-0.5));
            Assert.AreEqual(1, FunctionUtils.rademacher(-0.51));
            Assert.AreEqual(1, FunctionUtils.rademacher(0));
            Assert.AreEqual(1, FunctionUtils.rademacher(0.01));
        }
        [TestMethod]
        public void rademacher_1() {
            Assert.AreEqual(1, FunctionUtils.rademacher(1, -0.5));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, -0.49));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, -0.26));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.0));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.15));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.24));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.5));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.65));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 0.74));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 1));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 1.01));

            Assert.AreEqual(-1, FunctionUtils.rademacher(1, -0.25));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, -0.24));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, -0.01));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.25));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.26));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.49));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.75));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.76));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.85));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.99));
        }
        [TestMethod]
        public void rademacher_kth() {
            Assert.AreEqual(1, FunctionUtils.rademacher(3.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, -1.49));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, -2.99));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 3.01));
            Assert.AreEqual(1, FunctionUtils.rademacher(1, 2.51));
            Assert.AreEqual(1, FunctionUtils.rademacher(2, -1.49));
            Assert.AreEqual(1, FunctionUtils.rademacher(2, -0.74));
            Assert.AreEqual(1, FunctionUtils.rademacher(2, 0.76));
            Assert.AreEqual(1, FunctionUtils.rademacher(2, 1.26));

            Assert.AreEqual(-1, FunctionUtils.rademacher(-2.01));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.25));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.26));
            Assert.AreEqual(-1, FunctionUtils.rademacher(1, 0.49));
            Assert.AreEqual(-1, FunctionUtils.rademacher(2, 1.24));
            Assert.AreEqual(-1, FunctionUtils.rademacher(2, 0.99));
            Assert.AreEqual(-1, FunctionUtils.rademacher(2, -0.51));
            Assert.AreEqual(-1, FunctionUtils.rademacher(2, -1.51));
        }
        #endregion

        #region Pelly
        [TestMethod]
        public void paley_poweroftwo() {
            var res = FunctionUtils.paley(1);
            CollectionAssert.AreEqual(res, new int[] { 1 }, "paley for 1 is wrong");

            res = FunctionUtils.paley(2);
            CollectionAssert.AreEqual(res, new int[] { 0, 1 }, "paley for 2 is wrong");

            res = FunctionUtils.paley(3);
            CollectionAssert.AreEqual(res, new int[] { 1, 1 }, "paley for 2 is wrong");

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
        public void walsh_0() {
            Assert.AreEqual(1, FunctionUtils.walsh(0, -1.5));
            Assert.AreEqual(1, FunctionUtils.walsh(0, 0.5));
            Assert.AreEqual(1, FunctionUtils.walsh(0, 1.5));
        }
        [TestMethod]
        public void walsh_1() {
            Assert.AreEqual(1, FunctionUtils.walsh(1, 0.01));
            Assert.AreEqual(1, FunctionUtils.walsh(1, 0.25));
            Assert.AreEqual(-1, FunctionUtils.walsh(1, 0.75));
            Assert.AreEqual(-1, FunctionUtils.walsh(1, 0.99));
        }
        [TestMethod]
        public void walsh_1_period() {
            Assert.AreEqual(1, FunctionUtils.walsh(1, 1.01));
            Assert.AreEqual(1, FunctionUtils.walsh(1, 1.25));
            Assert.AreEqual(1, FunctionUtils.walsh(1, -0.75));
            Assert.AreEqual(1, FunctionUtils.walsh(1, -0.99));

            Assert.AreEqual(-1, FunctionUtils.walsh(1, 1.51));
            Assert.AreEqual(-1, FunctionUtils.walsh(1, 1.99));
            Assert.AreEqual(-1, FunctionUtils.walsh(1, -0.25));
            Assert.AreEqual(-1, FunctionUtils.walsh(1, -0.01));
        }
        [TestMethod]
        public void walsh_2() {
            Assert.AreEqual(-1, FunctionUtils.walsh(2, -0.01));
            Assert.AreEqual(1, FunctionUtils.walsh(2, 0));
            Assert.AreEqual(1, FunctionUtils.walsh(2, 0.01));
            Assert.AreEqual(1, FunctionUtils.walsh(2, 0.24));
            Assert.AreEqual(-1, FunctionUtils.walsh(2, 0.25));
            Assert.AreEqual(-1, FunctionUtils.walsh(2, 0.26));
            Assert.AreEqual(-1, FunctionUtils.walsh(2, 0.49));

            Assert.AreEqual(1, FunctionUtils.walsh(2, 0.5));
            Assert.AreEqual(1, FunctionUtils.walsh(2, 0.51));
            Assert.AreEqual(1, FunctionUtils.walsh(2, 0.74));
            Assert.AreEqual(-1, FunctionUtils.walsh(2, 0.75));
            Assert.AreEqual(-1, FunctionUtils.walsh(2, 0.76));
            Assert.AreEqual(-1, FunctionUtils.walsh(2, 0.99));
        }
        [TestMethod]
        public void walsh_3() {
            Assert.AreEqual(1, FunctionUtils.walsh(3, -0.01));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 0));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 0.01));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 0.24));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 0.75));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 0.76));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 0.99));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 1));
            Assert.AreEqual(1, FunctionUtils.walsh(3, 1.01));

            Assert.AreEqual(-1, FunctionUtils.walsh(3, 0.25));
            Assert.AreEqual(-1, FunctionUtils.walsh(3, 0.26));
            Assert.AreEqual(-1, FunctionUtils.walsh(3, 0.5));
            Assert.AreEqual(-1, FunctionUtils.walsh(3, 0.51));
            Assert.AreEqual(-1, FunctionUtils.walsh(3, 0.74));
        }
        #endregion

        #region Haart
        #endregion

        #region Compression
        [TestMethod]
        public void compression() {
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
        [TestMethod]
        public void compression_all_values() {
            var mass = new double[,] { { -1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
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
