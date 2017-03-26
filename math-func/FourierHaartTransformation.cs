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
            var targetFuncValues = new double[len];
            Array.Copy(functionValues, targetFuncValues, len);
            var answer = calculatingValues(targetFuncValues);
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

        private double[] calculatingValues(double[] input) {
            var len = input.Length;

            var k = (int) Math.Log(len, 2);

            while(k > 0) {
                double[] copy = new double[len];
                Array.Copy(input, copy, len);
                for(int j = 0; j < k; j++) {
                    input[j] = 0.5 * ( copy[2 * j] + copy[2 * j + 1] );
                    input[(int) Math.Pow(2, k - 1) + j] = 0.5 * ( copy[2 * j] - copy[2 * j + 1] );
                }
                k--;
            }
            return input;
        }

        public override string ToString() {
            return "fourier-haart-transformation";
        }
    }
}
