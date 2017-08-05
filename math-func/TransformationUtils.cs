using System;
using System.Threading.Tasks;

namespace MathFunction {
    public static class TransformationUtils {
        public static double[,] get2DCoeffs(double[,] funcValues, FourierTransformation transformation) {
            if(transformation is FourierTransformation2D) {
                return ((FourierTransformation2D) transformation).doAnalysis(funcValues);
            }
            // other cases
            var rows = funcValues.GetLength(0);
            var cols = funcValues.GetLength(1);
            var coeffs2d = new double[rows, cols];
            // 1st step: applying transformation to rows
            Parallel.For(0, rows, i => {
                var row = new double[cols];
                for(int j = 0; j < cols; j++) {
                    row[j] = funcValues[i, j];
                }
                var coeffs = transformation.doAnalysis(row);
                for(int j = 0; j < cols; j++) {
                    coeffs2d[i, j] = coeffs[j];
                }
            });
            // 2nd step: applying transformation to cols
            Parallel.For(0, cols, j => {
                var col = new double[rows];
                for(int i = 0; i < rows; i++) {
                    col[i] = coeffs2d[i, j];
                }
                var coeffs = transformation.doAnalysis(col);
                for(int i = 0; i < cols; i++) {
                    coeffs2d[i, j] = coeffs[i];
                }
            });
            return coeffs2d;
        }
        public static double[,] get2DValues(double[,] coeffs, FourierTransformation transformation) {
            if(transformation is FourierTransformation2D) {
                return ( (FourierTransformation2D) transformation ).doSynthesis(coeffs);
            }
            // other cases
            var rows = coeffs.GetLength(0);
            var cols = coeffs.GetLength(1);
            var values2d = new double[rows, cols];
            // 1st step: applying Walsh to cols
            for(int j = 0; j < cols; j++) {
                var col = new double[rows];
                for(int i = 0; i < rows; i++) {
                    col[i] = coeffs[i, j];
                }
                var funValues = transformation.doSynthesis(col);
                for(int i = 0; i < cols; i++) {
                    values2d[i, j] = funValues[i];
                }
            }
            // 2nd step: applying Walsh to rows
            for(int i = 0; i < rows; i++) {
                var row = new double[cols];
                for(int j = 0; j < cols; j++) {
                    row[j] = values2d[i, j];
                }
                var funValues = transformation.doSynthesis(row);
                for(int j = 0; j < cols; j++) {
                    values2d[i, j] = funValues[j];
                }
            }
            return values2d;
        }
    }
}
