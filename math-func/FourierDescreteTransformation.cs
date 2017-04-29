using System;
using LinearAlgebra;

namespace MathFunction {
    public class FourierDescreteTransformation : FourierTransformation {
        public override double[] doAnalysis(double[] values) {
            var s = 2; // 2 coord in alpha vector
            var p = 2; // 0, 1 - values of alpha coord
            var N = calculateN(p, s, values.Length); // amount of alpha vectors
            var funValues = new DoubleVector(values); // size = p^(N*s)

            var allField = new GField(p, s);

            for(int k = 0; k < N; k++) {
                // k-th step of process
                var funValuesCopy = new DoubleVector(funValues);
                for(int i = 0; i < funValues.length; i++) {
                    var alphaVector = FunctionUtils.getVectorByNumber(allField, N, p, s, i);
                    var summ = 0.0;
                    foreach(var kthVector in allField.field) {
                        var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                        alphaVectorCopy[k] = kthVector;
                        var num = FunctionUtils.generateNumberByVector(p, s, alphaVectorCopy);
                        // only real part
                        summ += Math.Cos(-2 * Math.PI * ( kthVector * alphaVector[k] ) / p) * Math.Pow(p, s / 2) * Math.Pow(p, -s / 2) * funValuesCopy[num];
                    }
                    funValues[i] = summ;
                }
            }
            return funValues.ToArray();
        }

        private int calculateN(int p, int s, int sourceLength) {
            var N = 0;
            while(Math.Pow(p, ( s * N )) < sourceLength) {
                N++;
            }
            if(Math.Pow(p, s * N) != sourceLength) {
                throw new ArgumentException("p^(Ns) must equals to array size");
            }
            return N;
        }

        public override double[] doSynthesis(double[] coeff) {
            var s = 2; // 2 coord in alpha vector
            var p = 2; // 0, 1 - values of alpha coord
            var N = calculateN(p, s, coeff.Length); // amount of alpha vectors
            var coeffs = new DoubleVector(coeff); // size = p^(N*s)
            var allField = new GField(p, s);

            for(int k = 0; k < N; k++) {
                // k-th step of process
                var funValuesCopy = new DoubleVector(coeffs);
                for(int i = 0; i < coeffs.length; i++) {
                    var alphaVector = FunctionUtils.getVectorByNumber(allField, N, p, s, i);
                    var summ = 0.0;
                    foreach(var kthVector in allField.field) {
                        var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                        alphaVectorCopy[k] = kthVector;
                        var num = FunctionUtils.generateNumberByVector(p, s, alphaVectorCopy);
                        // only real part
                        summ += Math.Cos(-2 * Math.PI * ( kthVector * alphaVector[k] ) / p) * Math.Pow(p, -s) * funValuesCopy[num];
                    }
                    coeffs[i] = summ;
                }
            }
            return coeffs.ToArray();
        }
    }
}
