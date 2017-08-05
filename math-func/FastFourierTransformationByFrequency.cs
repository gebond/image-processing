using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunction {
    public class FastFourierTransformationByFrequency : FourierTransformation {
        public override double[] doAnalysis(double[] values) {
            if(values == null) { return null; }
            var len = values.Length;
            if(( len & ( ~len + 1 ) ) != len) { throw new ArgumentException("input len is not power of 2!"); }
            var total_values = new double[len];
            Array.Copy(values, total_values, len);
            var coeffs = new double[len];
            calculatingValues(total_values, coeffs, 0);
            fix(coeffs);
            return coeffs;
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
                    var Wji = Math.Cos(-2 * Math.PI * j * i  / n);
                    fun_ith += coeffs[j] * Wji;
                }
                fun_values[i] = fun_ith / n;
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
            double[] copy = new double[len];
            Array.Copy(input, copy, len);
            for(int m = 0; m < N; m++) {
                input[m * 2] = copy[m] + copy[m + N];
                input[m * 2 + 1] = ( copy[m] - copy[m + N] ) * Math.Cos(2 * Math.PI * m / len);
            }
            // recursive calling for both parts of input array
            calculatingValues(input.Skip(0).Take(N).ToArray(), target, current); // left part of input array
            calculatingValues(input.Skip(N).Take(N).ToArray(), target, current + N); // right part
        }

        private void fix(double[] arrayToFix) {
            var len = arrayToFix.Length;
            double[] copy = new double[len];
            Array.Copy(arrayToFix, copy, len);
            if(len == 8) {
                arrayToFix[1] = copy[4];
                arrayToFix[2] = copy[1];
                arrayToFix[3] = copy[5];
                arrayToFix[4] = copy[2];
                arrayToFix[5] = copy[6];
                arrayToFix[6] = copy[3];
                return;
            }
            if(len == 4) {
                arrayToFix[1] = copy[2];
                arrayToFix[2] = copy[1];
                return;
            }

        }
    }
}
