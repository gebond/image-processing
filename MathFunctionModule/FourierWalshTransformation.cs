using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunctionModule {
    public class FourierWalshTransformation : FourierTransformation {

        public double[] doAnalysis(double[] functionValues) {
            if(functionValues == null) { return null; }
            var n = functionValues.Length;
            if((n & (~n + 1)) != n) { throw new ArgumentException("len is not power of 2!"); }

            //var N = Math.Log(n, 2);
            return null;
        }

        public double[] doSynthesis(double[] coeffs) {
            return null;
        }
    }
}
