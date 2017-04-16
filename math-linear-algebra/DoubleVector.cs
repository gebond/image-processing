using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    public class DoubleVector : NumVector<double> {

        #region constructors
        public DoubleVector(int len) : base(len) {
        }
        public DoubleVector(double[] initArray) : base(initArray) {
        }
        public DoubleVector(Vector<double> vector) : base(vector) {
        }
        #endregion

        #region general methods
        public override void randomize(double lower, double upper) {
            for(int i = 0; i < length; i++) {
                this[i] = random.Next((int)lower, (int)upper);
            }
        }
        public override double norm {
            get {
                double result = 0.0;
                for(int i = 0; i < this.length; i++) {
                    try {
                        result += this[i] * this[i];
                    }
                    catch(Exception) {
                        throw new IndexOutOfRangeException("norm can not be calculated!");
                    }
                }
                return Math.Sqrt(result);
            }
        }
        public override NumVector<double> ones {
            get {
                var onesVector = new DoubleVector(length);
                for(int i = 0; i < length; i++) {
                    onesVector[i] = 1.0;
                }
                return onesVector;
            }
        }
        public override NumVector<double> zeros {
            get {
                return new DoubleVector(length);
            }
        }
        public override NumVector<double> minus(NumVector<double> vect1, NumVector<double> vect2) {
            return (DoubleVector) vect1 - ( DoubleVector) vect2;
        }

        public override NumVector<double> plus(NumVector<double> vect1, NumVector<double> vect2) {
            return (DoubleVector) vect1 + (DoubleVector) vect2;
        }

        public override double product(NumVector<double> vect1, NumVector<double> vect2) {
            return (DoubleVector) vect1 * (DoubleVector) vect2;
        }
        #endregion 

        /*#region 
        public override AbstractVector<double> summa(AbstractVector<double> vector1, AbstractVector<double> vector2) {
            if(vector1.length != vector2.length) {
                throw new ArgumentException("not similar dim");
            }
            var summa = new DoubleVector(vector1.length);
            for(int i = 0; i < vector1.length; i++) {
                summa[i] = vector1[i] + vector2[i];
            }
            return summa;
        }
        public override AbstractVector substract(AbstractVector vector1, AbstractVector vector2) {
            if(vector1.length != vector2.length) {
                throw new ArgumentException("not similar dim");
            }
            var subVector = new DoubleVector(vector1.length);
            for(int i = 0; i < vector1.length; i++) {
                subVector[i] = vector1[i] - vector2[i];
            }
            return subVector;
        }
        public override AbstractVector product(double a, AbstractVector vector) {
            var multVector = new DoubleVector(vector.length);
            for(int i = 0; i < vector.length; i++) {
                multVector[i] = a * vector[i];
            }
            return multVector;
        }
        public override AbstractVector product(int a, AbstractVector vector) {
            return this.product((double)a, vector);
        }
        public override double product(AbstractVector<double> vector1, AbstractVector<double> vector2) {
            if(vector1.length != vector2.length) {
                throw new ArgumentException("not similar dim");
            }
            double product = 0;
            for(int i = 0; i < vector1.length; i++) {
                product += vector1[i] * vector2[i];
            }
            return product;
        }
        #endregion*/

        #region operations
        public static DoubleVector operator +(DoubleVector v1, DoubleVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            var summa = new DoubleVector(v1.length);
            for(int i = 0; i < v1.length; i++) {
                summa[i] = v1[i] + v2[i];
            }
            return summa;
        }
        public static DoubleVector operator -(DoubleVector v1, DoubleVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            var diff = new DoubleVector(v1.length);
            for(int i = 0; i < v1.length; i++) {
                diff[i] = v1[i] - v2[i];
            }
            return diff;
        }
        public static double operator *(DoubleVector v1, DoubleVector v2) {
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

        #region private methods
        protected override bool fieldsMatch(Vector<double> vector) {
            var numVector = (DoubleVector) vector;
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
        public override void normalize() {
            throw new NotImplementedException();
        }
        #endregion

        #region private fields
        private static readonly Random random = new Random();
        #endregion
    }
}