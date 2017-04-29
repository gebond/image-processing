using System;
using System.Threading.Tasks;

namespace LinearAlgebra {
    /*public class Matrix : IMatrix {

        #region matrix constructors
        public Matrix(int rows, int cols) {
            if(rows <= 0 || cols <= 0) {
                throw new ArgumentException("dimension <= 0");
            }
            this.rows = rows;
            this.cols = cols;
            coord = new double[rows, cols];
        }
        public Matrix(int rows, int cols, bool random) {
            if(rows <= 0 || cols <= 0) {
                throw new ArgumentException("dimension <= 0");
            }
            this.rows = rows;
            this.cols = cols;
            coord = new double[rows, cols];
            if(random) {
                randomize();
            }
        }
        public Matrix(double[,] mass) {
            rows = mass.GetUpperBound(0);
            cols = mass.GetUpperBound(1);
            coord = new double[rows, cols];
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    coord[i, j] = mass[i, j];
                }
            }
        }
        public Matrix(Matrix m) {
            rows = m.Rows;
            cols = m.Cols;
            coord = new double[rows, cols];
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    coord[i, j] = m[i, j];
                }
            }
        }
        public Matrix(DoubleVector[] vmass) {
            rows = (short)vmass.Length;
            cols = vmass[0].length;
            coord = new double[rows, cols];
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    coord[i, j] = vmass[i][j];
                }
            }
        }
        #endregion

        #region IMatrix override

        public override double this[int i, int j] {
            get {
                if(i < 0 || i >= rows) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= cols) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                return coord[i, j];
            }
            set {
                if(i < 0 || i >= rows) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= cols) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                coord[i, j] = value;
            }

        }
        public override int Rows {
            get {
                return rows;
            }
        }
        public override int Cols {
            get {
                return cols;
            }
        }
        public override void print() {

            for(int i = 0; i < rows; i++) {
                if(i == 0) {
                    System.Console.WriteLine("Matrix:");
                }
                for(int j = 0; j < cols; j++) {
                    if(j == 0) {
                        System.Console.Write("\t");
                    }
                    Console.Write("\t {0}", coord[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
        public override AbstractVector getRow(int row) {
            DoubleVector vectorRow = new DoubleVector(cols);
            for(int j = 0; j < cols; j++) {
                vectorRow[j] = coord[row, j];
            }
            return vectorRow;
        }
        public override AbstractVector getCol(int col) {
            DoubleVector colVector = new DoubleVector(rows);
            for(int i = 0; i < rows; i++) {
                colVector[i] = this[i, col];
            }
            return colVector;
        }
        public override IMatrix summa(IMatrix summand1, IMatrix summand2) {
            if(summand1.Rows != summand2.Rows || summand1.Cols != summand2.Cols) {
                throw new InvalidOperationException("length 1 != length 2");
            }
            var summ = new Matrix(summand1.Rows, summand1.Cols);

            for(int i = 0; i < summand1.Rows; i++) {
                for(int j = 0; j < summand1.Cols; j++) {
                    summ[i, j] = summand1[i, j] + summand2[i, j];
                }
            }
            return summ;
        }
        public override IMatrix substract(IMatrix obj1, IMatrix obj2) {
            if(obj1.Rows != obj2.Rows || obj1.Cols != obj2.Cols) {
                throw new InvalidOperationException("length 1 != length 2");
            }
            Matrix summ = new Matrix(obj1.Rows, obj1.Cols);
            for(int i = 0; i < obj1.Rows; i++) {
                for(int j = 0; j < obj1.Cols; j++) {
                    summ[i, j] = obj1[i, j] - obj2[i, j];
                }
            }
            return summ;
        }
        public override IMatrix product(double a, IMatrix matrix) {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            for(int i = 0; i < result.Rows; i++) {
                for(int j = 0; j < result.Cols; j++) {
                    result[i, j] = a * matrix[i, j];
                }
            }
            return result;
        }
        public override IMatrix product(int a, IMatrix matrix) {
            return product((double)a, matrix);
        }
        public override AbstractVector product(IMatrix matrix, AbstractVector vector) {
            DoubleVector result = new DoubleVector(vector.length);

            if(vector.length != matrix.Cols) {
                Console.WriteLine("matrix's cols != vector's length");
            }
            for(int i = 0; i < matrix.Rows; i++) {
                double summ = 0;
                for(int j = 0; j < vector.length; j++) {
                    summ += matrix[i, j] * vector[j];
                }
                result[i] = summ;
            }
            return result;
        }
        public override IMatrix product(IMatrix obj1, IMatrix obj2) {
            if(obj1.Rows != obj2.Rows || obj1.Cols != obj2.Cols) {
                throw new InvalidOperationException("cols/rows 1 != cols/rows 2");
            }
            Matrix result = new Matrix(obj1.Rows, obj1.Cols);
            for(int i = 0; i < obj1.Rows; i++) {
                for(int j = 0; j < obj1.Cols; j++) {
                    for(int k = 0; k < obj1.Rows; k++) {
                        result[i, j] += obj1[i, k] * obj2[k, j];
                    }
                }
            }
            return result;
        }
        #endregion

        #region Matrix operators
        public static Matrix operator +(Matrix obj1, Matrix obj2) {
            return (Matrix)obj1.summa(obj1, obj2);
        }
        public static Matrix operator *(double a, Matrix obj) {
            Matrix result = new Matrix(obj.Rows, obj.Cols);
            for(int i = 0; i < obj.Rows; i++) {
                for(int j = 0; j < obj.Cols; j++) {
                    result[i, j] = a * obj[i, j];
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix obj1, Matrix obj2) {
            return (Matrix)obj1.substract(obj1, obj2);
        }
        public static Matrix operator *(Matrix obj1, Matrix obj2) {
            if(obj1.Rows != obj2.Rows || obj1.Cols != obj2.Cols) {
                throw new InvalidOperationException("length 1 != length 2");
            }
            Matrix result = new Matrix(obj1.Rows, obj1.Cols);
            for(int i = 0; i < obj1.Rows; i++) {
                for(int j = 0; j < obj1.Cols; j++) {
                    for(int k = 0; k < obj1.Rows; k++) {
                        result[i, j] += obj1[i, k] * obj2[k, j];
                    }
                }
            }
            return result;
        }
        public static DoubleVector operator *(Matrix mat, DoubleVector vec) {
            DoubleVector result = new DoubleVector(vec.length);

            if(vec.length != mat.cols) {
                Console.WriteLine("допускается перемножение только квадратных матриц на вектор одной размерности");
                System.Environment.Exit(0);
            }
            for(int i = 0; i < vec.length; i++) {
                double summ = 0;
                for(int j = 0; j < vec.length; j++) {
                    summ += mat[i, j] * vec[j];
                }
                result[i] = summ;
            }
            return result;
        }
        #endregion

        #region square matrix
        public bool notNoolDiag() {
            if(cols != rows) {
                throw new ArgumentException("Not aplicable for non square matrix");
            }
            for(int i = 0; i < rows; i++) {
                if(coord[i, i] == 0) {
                    return false;
                }
            }
            return true;
        }
        public double getMaxElementAboveDiagonal() {
            double max = 0;
            for(int i = 0; i < rows; i++) {
                for(int j = i + 1; j < cols; j++) {
                    if(Math.Abs(coord[i, j]) > max) {
                        max = Math.Abs(coord[i, j]);
                    }
                }
            }
            return max;
        }
        public double getDeterminant() {
            Matrix chg = new Matrix(rows, cols);
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    chg[i, j] = coord[i, j];
                }
            }

            double det = 1;
            for(int k = 0; k < cols; k++) {
                for(int i = k + 1; i < rows; i++) {
                    for(int j = k + 1; j < cols; j++) {
                        chg[i, j] = chg[i, j] + chg[k, j] * (-chg[i, k] / chg[k, k]);
                    }
                    chg[i, k] = 0;
                }
            }
            for(int i = 0; i < rows; i++) {
                det *= chg[i, i];
            }
            return det;
        }
        #endregion square matrix

        #region private fields
        private int rows, cols;
        private double[,] coord;
        private static Random rand = new Random();
        #endregion

    }*/
}
