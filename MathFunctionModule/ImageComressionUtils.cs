using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunctionModule {
    public static class ImageComressionUtils {
        public static int[,] compress(int[,] inputValues, double compression_coeff) {
            if(compression_coeff < 0 || compression_coeff > 100) {
                throw new ArgumentException("compression coeff is incorect");
            }
            if(inputValues == null || inputValues.Length == 0) {
                throw new ArgumentException("input values are null or empty");
            }

            return null;
        }
    }
}
