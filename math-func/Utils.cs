using System;
using System.Threading.Tasks;

namespace MathFunction {
    public static class Utils {

        public static double[,] createDouble(int[,] intValues) {
            var result = new double[intValues.GetLength(0), intValues.GetLength(1)];
            Parallel.For(0, intValues.GetLength(0), i => {
                for(int j = 0; j < intValues.GetLength(1); j++) {
                    result[i, j] = (double) intValues[i, j];
                }
            });
            return result;
        }
        public static int[,] createInt(double[,] doubleValues) {
            var result = new int[doubleValues.GetLength(0), doubleValues.GetLength(1)];
            Parallel.For(0, doubleValues.GetLength(0), i => {
                for(int j = 0; j < doubleValues.GetLength(1); j++) {
                    result[i, j] = (int) doubleValues[i, j];
                }
            });
            return result;
        }
    }
}
