using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunctionModule {
    class FourierWalshTransformation : FourierTransformation {

        public double[] doAnalysis(double[] values) {
            if(values == null) { return null; }
            var N = values.Length;
            if((N != 0) && ((N & (~N + 1)) == N)) { throw new ArgumentException("N is not power of 2!"); }

            return null;
        }

        public double[] doSynthesis(double[] coeffs) {
            return null;
        }
    }
}
