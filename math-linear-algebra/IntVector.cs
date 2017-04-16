using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    public class IntVector : NumVector<int> {

        #region constructors
        public IntVector(int len) : base(len){
        }
        public IntVector(int[] initArray) : base(initArray) {
        }
        public IntVector(Vector<int> vector) : base(vector) {
        }
        #endregion

        #region general methods
        public override double norm {
            get {
                double result = 0;
                for(int i = 0; i < this.length; i++) {
                    try {
                        result += this[i] * this[i];
                    }
                    catch(Exception) {
                        throw new IndexOutOfRangeException("norm can not be calculated!");
                    }
                }
                return result;
            }
        }
        public override void randomize(int lower, int upper) {
            for(int i = 0; i < length; i++) {
                this[i] = random.Next(lower, upper);
            }
        }
        public override NumVector<int> ones {
            get {
                var onesVector = new IntVector(length);
                for(int i = 0; i < length; i++) {
                    onesVector[i] = 1;
                }
                return onesVector;
            }
        }
        public override NumVector<int> zeros {
            get {
                return new IntVector(length);
            }
        }
        public override void normalize() {
            throw new NotImplementedException("Unsupported operation for IntVector");
        }
        public override NumVector<int> minus(NumVector<int> vect1, NumVector<int> vect2) {
            return (IntVector) vect1 - (IntVector) vect2;
        }

        public override NumVector<int> plus(NumVector<int> vect1, NumVector<int> vect2) {
            return (IntVector) vect1 + (IntVector) vect2;
        }

        public override double product(NumVector<int> vect1, NumVector<int> vect2) {
            return (IntVector) vect1 * (IntVector) vect2;
        }
        #endregion

        #region private methods
        protected override bool fieldsMatch(Vector<int> vector) {
            var numVector = (IntVector) vector;
            if(vector == null) {
                return false;
            }
            for(int i = 0; i < length; i++) {
                if(coord[i] != numVector[i]) {
                    return false;
                }
            }
            return true;
        }
        
        #endregion

        #region operations
        public static IntVector operator +(IntVector v1, IntVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            var summa = new IntVector(v1.length);
            for(int i = 0; i < v1.length; i++) {
                summa[i] = v1[i] + v2[i];
            }
            return summa;
        }
        public static IntVector operator -(IntVector v1, IntVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            var diff = new IntVector(v1.length);
            for(int i = 0; i < v1.length; i++) {
                diff[i] = v1[i] - v2[i];
            }
            return diff;
        }
        public static double operator *(IntVector v1, IntVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            double product = 0;
            for(int i = 0; i < v1.length; i++) {
                product += v1[i] * v2[i];
            }
            return product;
        }
        #endregion

        #region private fields
        private static readonly Random random = new Random();
        #endregion
    }
}
