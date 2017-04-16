using System;
using MathFunction;
using LinearAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MathModuleTests {
    [TestClass]
    public class SFTests {
        private GField gfield;
        [TestInitialize]
        public void initTests() {
        }

        [TestMethod]
        public void sf_isprime() {
            Assert.IsTrue(FunUtils.isPrime(7));
            
            Assert.IsFalse(FunUtils.isPrime(4));
        }

        [TestMethod]
        public void sf_gfield_create() {
            gfield = new GField(3, 2);
            var found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 0, 0})));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 1, 2 })));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 0, 2 })));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 2, 2 })));
            Assert.IsTrue(found != null);
            found = gfield.field.Find(x => x.Equals(new IntVector(new int[] { 3, 3 })));
            Assert.IsTrue(found == null);
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
            var n = FunUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 0);

            a_mass[0] = (IntVector) a_mass[0].ones;
            a_mass[1] = (IntVector) a_mass[1].ones;
            a_vector = new Vector<IntVector>(a_mass);
            n = FunUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 15);

            a_mass[0] = new IntVector(new int[] { 1, 0 });
            a_mass[1] = new IntVector(new int[] { 0, 1 });
            a_vector = new Vector<IntVector>(a_mass);
            n = FunUtils.generateNumberByVector(p, s, a_vector);
            Assert.IsTrue(n == 6);

            a_mass[0] = new IntVector(new int[] { 0, 1 });
            a_mass[1] = new IntVector(new int[] { 1, 0 });
            a_vector = new Vector<IntVector>(a_mass);
            n = FunUtils.generateNumberByVector(p, s, a_vector);
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

            var res_vector = FunUtils.getVectorByNumber(gfield, N, p, s, 0);
            Assert.IsTrue(a_vector == res_vector);


            a_mass[0] = (IntVector) a_mass[0].ones;
            a_mass[1] = (IntVector) a_mass[1].ones;
            a_vector = new Vector<IntVector>(a_mass);
            res_vector = FunUtils.getVectorByNumber(gfield, N, p, s, 15);
            Assert.IsTrue(a_vector == res_vector);

        }

        [TestMethod]
        public void sf_P_create() {
            var s = 2;
            var N = 2;
            var a_mass = new int[16];
            int res = FunUtils.getPParameter(a_mass.Length, s, N);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void sf_1_step() {
            var s = 2;
            var p = 2;
            var N = 4;

            var fun = new DoubleVector(100);
            fun.randomize(0, 256);

            var a_mass = new IntVector[N];

            for(int i = 0; i < N; i++) {
                a_mass[i] = new IntVector(s);
                a_mass[i].randomize(0, p);
            }

            var a_vector = new Vector<IntVector>(a_mass);

            var field = new GField(p, s);
            // a_vector = [0,k,2,3]
            var k = 1;
            var result = 0.0;
            foreach(var vector in field.field) {
                a_vector[k] = vector;
                var index = FunUtils.generateNumberByVector(p, s, a_vector);
                result += fun[index];
            }

            var n = FunUtils.generateNumberByVector(p, s, a_vector);
            Assert.AreEqual(n, n);
        }

        [TestMethod]
        public void sf_product_vector() {
            var v1 = new IntVector(new int[] { 1, 2 });
            var v2 = new IntVector(new int[] { 3, -10 });
            var res = v1 * v2;
            Assert.IsTrue(res == -17);
        }

        [TestMethod]
        public void sf_algorithm() {
            var s = 2;
            var N = 2; // 2 steps
            var funValues = new DoubleVector(16);
            var p = FunUtils.getPParameter(funValues.length, s, N);

            var allField = new GField(p, s);
            var allAlphaVectors = new List<Vector<IntVector>>();

            funValues.randomize(0, 256);
            for(int k = 0; k < N; k++) {
                // k-th step of process
                for(int i = 0; i < funValues.length; i++) {
                    var alphaVector = FunUtils.getVectorByNumber(allField, N, p, s, i);
                    var summ = 0.0;
                    foreach(var kthVector in allField.field) {
                        var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                        alphaVectorCopy[k] = kthVector;
                        var num = FunUtils.generateNumberByVector(p, s, alphaVectorCopy);
                        // only real part
                        summ += Math.Cos(funValues[num]);
                    }
                }
            }
        }
    }
}
