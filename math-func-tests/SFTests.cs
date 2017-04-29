using System;
using MathFunction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LinearAlgebra;

namespace MathModuleTests {
    [TestClass]
    public class SFTests {
        private GField gfield;
        FourierTransformation transformation;
        [TestInitialize]
        public void initTests() {
            transformation = new FourierDescreteTransformation();
        }

        [TestMethod]
        public void sf_isprime() {
            Assert.IsTrue(FunctionUtils.isPrime(7));

            Assert.IsFalse(FunctionUtils.isPrime(4));
        }

        [TestMethod]
        public void sf_gfield_create() {
            gfield = new GField(3, 2);
            var found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 0, 0 })));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 1, 2 })));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 0, 2 })));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 2, 2 })));
            Assert.IsTrue(found != null);
        }

        [TestMethod]
        public void sf_number_create() {
            var s = 2;
            var p = 2;
            var N = 2;
            var a_mass = new IntVector[N];

            a_mass[0] = new IntVector(s);
            a_mass[1] = new IntVector(s);
            var a_vector = new Vector<IntVector>(a_mass);
            var n = FunctionUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 0);

            a_mass[0] = (IntVector) a_mass[0].ones;
            a_mass[1] = (IntVector) a_mass[1].ones;
            a_vector = new Vector<IntVector>(a_mass);
            n = FunctionUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 15);

            a_mass[0] = new IntVector(new int[] { 1, 0 });
            a_mass[1] = new IntVector(new int[] { 0, 1 });
            a_vector = new Vector<IntVector>(a_mass);
            n = FunctionUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 6);

            a_mass[0] = new IntVector(new int[] { 0, 1 });
            a_mass[1] = new IntVector(new int[] { 1, 0 });
            a_vector = new Vector<IntVector>(a_mass);
            n = FunctionUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 9);
        }

        [TestMethod]
        public void sf_vector_create() {
            var s = 2;
            var p = 2;
            var N = 2;
            var a_mass = new IntVector[N];
            var gfield = new GField(p, s);
            a_mass[0] = new IntVector(s);
            a_mass[1] = new IntVector(s);
            var a_vector = new Vector<IntVector>(a_mass);

            var res_vector = FunctionUtils.getVectorByNumber(gfield, N, p, s, 0);
            Assert.IsTrue(a_vector == res_vector);


            a_mass[0] = (IntVector) a_mass[0].ones;
            a_mass[1] = (IntVector) a_mass[1].ones;
            a_vector = new Vector<IntVector>(a_mass);
            res_vector = FunctionUtils.getVectorByNumber(gfield, N, p, s, 15);
            Assert.IsTrue(a_vector == res_vector);

        }

        [TestMethod]
        public void sf_P_create() {
            var s = 2;
            var N = 2;
            var a_mass = new int[16];
            int res = FunctionUtils.getPParameter(a_mass.Length, s, N);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void sf_product_vector() {
            var v1 = new IntVector(new int[] { 1, 2 });
            var v2 = new IntVector(new int[] { 3, -10 });
            var res = v1 * v2;
            Assert.IsTrue(res == -17);
        }

        [TestMethod]
        public void sf_analysis() {
            //var funArray = new double[] { 10.0, 20.0, 30.0, 40.0 };
            var funArray = new double[] {   10.0, 20.0, 30.0, 40.0,
                                            11.0, 21.0, 31.0, 41.0,
                                            12.0, 22.0, 32.0, 42.0,
                                            13.0, 23.0, 33.0, 43.0};
            var random = new DoubleVector(32*32);
            random.randomize(0, 255);
            var coeffs = transformation.doAnalysis(random.ToArray());
            var result = transformation.doSynthesis(coeffs);
            CollectionAssert.AreEquivalent(random.ToArray(), result);
        }
        [TestMethod]
        public void sf_analysis_2d() {
            var source = new double[,] {
                { 10.0, 220.0, 360.0, 40.0, 11.0, 21.0, 31.0, 41.0,},
                { 123.0, -20.0, 30.0, 40.0, 11.0, 21.0, 31.0, 41.0,},
                { 321.0, 20.0, 30.0, 401.0, -11.0, 21.0, 31.0, 41.0,},
                { 170.0, 201.0, 30.0, 540.0, 11.0, 216.0, 31.0, 41.0,},
                { 10.0, -20.0, -30.0, 40.0, 11.0, 211.0, 31.0, 41.0,},
                { 10.0, 20.0, 302.0, 40.0, -11.0, 21.0, 31.0, 41.0,},
                { 101.0, 201.0, 350.0, 40.0, 11.0, 21.0, 731.0, 41.0,},
                { 10.0, 20.0, 360.0, 40.0, 121.0, 21.0, 31.0, 41.0,},
            };
            var coeffs = transformation.doAnalysis(Utils.get1dFromArray(source));
            var coeffs2d = Utils.get2dFromArray(coeffs);
            var result = transformation.doSynthesis(coeffs);
            var result2d = Utils.get2dFromArray(result);
            CollectionAssert.AreEquivalent(source, result2d);
        }
        [TestMethod]
        public void sf_1d_2d() {
            var source = new double[,] {
                { 10.0, 220.0, 330},
                { 333.0, 666.0, 999},
                { -10.0, -220.0, -330},
            };
            var source1d = Utils.get1dFromArray(source);
            var result = Utils.get2dFromArray(source1d);
            CollectionAssert.AreEquivalent(source, result);

        }
    }
}
