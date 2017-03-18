using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunction {
    public abstract class FourierTransformation {
        // doAnalysis returns FourierCoeffs using input values of function
        public abstract double[] doAnalysis(double[] values);
        // doSynthesis returns Values of function using input values of function
        public abstract double[] doSynthesis(double[] coeff);
        // private method of calculation
        
        protected double[] createXValues(int n) {
            if(n <= 0) {
                throw new ArgumentException("inserted values of n must be > 0 found " + n);
            }
            var x_values = new double[n];
            for(int k = 0; k < n; k++) {
                x_values[k] = ( 2.0 * k + 1.0 ) / ( 2.0 * n );
            }
            return x_values;
        }
    }
}
