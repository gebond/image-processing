using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunction {
    public class FourierWalshTransformation : FourierTransformation {

        public override double[] doAnalysis(double[] functionValues) {
            if(functionValues == null) { return null; }
            var len = functionValues.Length;
            if(( len & ( ~len + 1 ) ) != len) { throw new ArgumentException("input len is not power of 2!"); }
            var total_values = new double[len];
            Array.Copy(functionValues, total_values, len);
            var answer = new double[len];
            calculatingValues(total_values, answer, 0);
            return answer;
        }



        public override double[] doSynthesis(double[] coeffs) {
            if(coeffs == null || coeffs.Length == 0) {
                throw new ArgumentException("input coeffs size must be larger than 0");
            }
            var n = coeffs.Length;
            var fun_values = new double[n];
            var x = createXValues(n);
            for(int i = 0; i < n; i++) {
                var fun_ith = 0.0;
                for(int j = 0; j < n; j++) {
                    var walsh = FunctionUtils.walsh(j, x[i]);
                    fun_ith += coeffs[j] * walsh;
                }
                fun_values[i] = fun_ith;
            }
            return fun_values;
        }

        private void calculatingValues(double[] input, double[] target, int current) {
            var len = input.Length;
            if(len == 1) {
                target[current] = input[0];
                return; // exit of recursion
            }
            int N = len / 2;
            for(int j = 0; j < N; j++) {
                input[j] = 0.5 * ( input[2 * j] + input[2 * j + 1] );
                input[N + j] = 0.5 * ( input[2 * j] - input[2 * j + 1] );
            }
            // recursive calling for both parts of input array
            calculatingValues(input.Skip(0).Take(N).ToArray(), target, current); // left part of input array
            calculatingValues(input.Skip(N).Take(N).ToArray(), target, current + N); // right part
        }

    }
}
