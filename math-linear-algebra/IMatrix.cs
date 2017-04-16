using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    /*public abstract class IMatrix {

        #region constructors
        public IMatrix() { }
        public IMatrix(int rows, int cols) { }
        public IMatrix(int rows, int cols, bool random) { }
        public IMatrix(IMatrix matrix) { }
        public IMatrix(AbstractVector[] rows) { }
        #endregion

        #region abstract methods
        public abstract double this[int row, int col] {
            get;
            set;
        }
        public abstract void print();
        public abstract int Rows { get; }
        public abstract int Cols { get; }
        #endregion

        #region general methods
        public double norm() {
            double result = 0;
            for(int i = 0; i < this.Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    try {
                        result += this[i, j] * this[i, j];
                    }
                    catch(Exception) {
                        throw new IndexOutOfRangeException("norm can not be calculated!");
                    }
                }
            }
            return Math.Sqrt(result);
        }
        public void normalize() {
            var norm = this.norm();
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    this[i, j] = this[i, j] / norm;
                }
            }
        }
        public void randomize() {
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    this[i, j] = random.Next(-10, 10);
                }
            }
        }
        public void ones() {
            if(Rows != Cols) {
                throw new ArgumentException("can not get ones for not square matrix");
            }
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Rows; j++) {
                    if(i == j) {
                        this[i, j] = 1;
                    }
                    else {
                        this[i, j] = 0;
                    }
                }
            }
        }
        public void zeros() {
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    this[i, j] = 0;
                }
            }
        }
        #endregion

        #region general abstract operations
        public abstract AbstractVector getRow(int row);
        public abstract AbstractVector getCol(int col);
        public abstract IMatrix summa(IMatrix matrix1, IMatrix matrix2);
        /*public static IVector operator +(IVector v1, IVector v2) {
            if(summand1.length != summand2.length) {
                throw new ArgumentException("not similar dim");
            }
            var summa = new IVector(summand1.length);
            for(int i = 0; i < summand1.length; i++) {
                summa[i] = summand1[i] + summand2[i];
            }
            return summa; 
        }
        public abstract IMatrix substract(IMatrix matrix1, IMatrix matrix2);
        /*public static IVector operator -(IVector v1, IVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            var diffVector = new IVector(v1.length);
            for(int i = 0; i < v1.length; i++) {
                diffVector[i] = v1[i] - v2[i];
            }
            return diffVector;
        }
        public abstract IMatrix product(double a, IMatrix matrix);
        /*public static IVector operator *(double a, IVector v) {
            var multVector = new IVector(v.length);
            for(int i = 0; i < v.length; i++) {
                multVector[i] = a * v[i];
            }
            return multVector;
        }
        public abstract IMatrix product(int a, IMatrix matrix);
        /*public static IVector operator *(int a, IVector v) {
            return (double)a * v;
        }
        public abstract AbstractVector product(IMatrix matrix, AbstractVector vector);
        /*public static double operator *(IVector v1, IVector v2) {
            if(v1.length != v2.length) {
                throw new ArgumentException("not similar dim");
            }
            double product = 0;
            for(int i = 0; i < v1.length; i++) {
                product += v1[i] * v2[i];
            }
            return product;
        }
        public abstract IMatrix product(IMatrix matrix1, IMatrix matrix2);
        #endregion

        #region override object methods
        public static bool operator ==(IMatrix a, IMatrix b) {
            return a.Equals(b);
        }
        public static bool operator !=(IMatrix a, IMatrix b) {
            return !(a.Equals(b));
        }
        public override string ToString() {
            string result = "";
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    if(j == 0) {
                        result += "\t";
                    }
                    result += String.Format("{0,20:0.00000000}   ", this[i, j]);
                    if(j == Cols - 1) {
                        result += "\n";
                    }
                    else {
                        result += ", ";
                    }
                }
            }
            return result;
        }
        public override bool Equals(Object obj) {
            // If both are null, or both are same instance, return true.
            if(System.Object.ReferenceEquals(this, obj)) {
                return true;
            }
            // If one is null, but not both, return false.
            if(((object)this == null) || ((object)obj == null)) {
                return false;
            }
            var matrix = (IMatrix)obj;
            if(matrix == null) {
                throw new ArgumentException("Can not cast object to IMatrix type!");
            }
            if(matrix.Rows != this.Cols || matrix.Rows != this.Cols) {
                throw new ArgumentException("Matrices must have similiar length!");
            }
            // Return true if the fields match:
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    if(this[i, j] != matrix[i, j]) { return false; }
                }
            }
            return true;
        }
        public override int GetHashCode() {
            int hashcode = 0;
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Cols; j++) {
                    hashcode = 31 * hashcode + (int)this[i, j].GetHashCode();
                }
            }
            return hashcode;
        }
        #endregion

        #region private fields
        private static Random random = new Random();
        #endregion
    }*/
}
