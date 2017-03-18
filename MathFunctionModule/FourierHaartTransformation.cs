using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunction {
    public class FourierHaartTransformation : FourierTransformation {

        public override double[] doAnalysis(double[] functionValues) {
            if(functionValues == null) { return null; }
            var len = functionValues.Length;
            if(( len & ( ~len + 1 ) ) != len) { throw new ArgumentException("input len is not power of 2!"); }
            var fun_values = new double[len];
            Array.Copy(functionValues, fun_values, len);
            var N = Math.Log(len, 2);
            calculatingValues(fun_values);
            calculatingValues(functionValues);
            return fun_values;
        }

        public override double[] doSynthesis(double[] coeffs) {
            return null;
        }

        private void calculatingValues(double[] input) {
            var len = input.Length;
            if(len == 1) {
                return; // exit of recursion
            }
            int N = len / 2;
            for(int j = 0; j < N; j++) {
                input[j] = 0.5 * (input[2 * j] + input[2 * j + 1]);
                input[N + j] = 0.5 * (input[2 * j] - input[2 * j + 1]);
            }
            // recursive calling for both parts of input array
            calculatingValues(input.Skip(0).Take(N).ToArray()); // left part of input array
            //calculatingValues(input.Skip(N).Take(N).ToArray()); // right part missed because of haart system
        }
    }
}
