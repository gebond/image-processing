using System;
using LinearAlgebra;
using System.Collections.Generic;

namespace MathFunction {
    public class FourierDescreteTransformation : FourierTransformation2D {

        private static int p = 2; // 2 coord in alpha vector
        private static int s = 2; // 0, 1 - values of alpha coord
        private static GField allField = new GField(p, s); // allfield
        private static Dictionary<int, Vector<IntVector>> vectorByNumber;
        private static int[,,,,,] vectors;
        private static int N = 3;

        public FourierDescreteTransformation() {
            vectorByNumber = new Dictionary<int, Vector<IntVector>>();
            vectors = new int[p, p, p, p, p, p];
            for(int i = 0; i < Math.Pow(p, s * N); i++) {
                var vector = MathFunction.FunctionUtils.getVectorByNumber(allField, N, p, s, i);
                vectorByNumber.Add(i, vector);
                vectors[vector[0][0], vector[0][1], vector[1][0],
                        vector[1][1], vector[2][0], vector[2][1]] = i;
            }
            Console.WriteLine();
        }

        public override double[] doAnalysis(double[] values) {
            var N = calculateN(values.Length); // amount of alpha vectors
            var funValues = new DoubleVector(values); // size = p^(N*s)

            for(int k = 0; k < N; k++) {
                // k-th step of process
                var funValuesCopy = new DoubleVector(funValues);
                for(int i = 0; i < funValues.length; i++) {
                    //var alphaVector = FunctionUtils.getVectorByNumber(allField, N, p, s, i);
                    Vector<IntVector> alphaVector;
                    vectorByNumber.TryGetValue(i, out alphaVector);
                    var summ = 0.0;
                    foreach(var kthVector in allField.field) {
                        var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                        alphaVectorCopy[k] = kthVector;
                        int num;
                        num = vectors[alphaVectorCopy[0][0], alphaVectorCopy[0][1], alphaVectorCopy[1][0],
                        alphaVectorCopy[1][1], alphaVectorCopy[2][0], alphaVectorCopy[2][1]];
                        //num = FunctionUtils.generateNumberByVector(p, s, alphaVectorCopy);
                        //numberByVector.TryGetValue(alphaVectorCopy, out num);
                        // only real part
                        summ += Math.Cos(-2 * Math.PI * ( kthVector * alphaVector[k] ) / p) * Math.Pow(p, s / 2) * Math.Pow(p, -s / 2) * funValuesCopy[num];
                    }
                    funValues[i] = summ;
                }
            }
            return funValues.ToArray();
        }

        private int calculateN(int sourceLength) {
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
            var N = calculateN(coeff.Length); // amount of alpha vectors
            var coeffs = new DoubleVector(coeff); // size = p^(N*s)

            for(int k = 0; k < N; k++) {
                // k-th step of process
                var funValuesCopy = new DoubleVector(coeffs);
                for(int i = 0; i < coeffs.length; i++) {
                    Vector<IntVector> alphaVector;
                    vectorByNumber.TryGetValue(i, out alphaVector);
                    var summ = 0.0;
                    foreach(var kthVector in allField.field) {
                        var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                        alphaVectorCopy[k] = kthVector;
                        int num;
                        num = vectors[alphaVectorCopy[0][0], alphaVectorCopy[0][1], alphaVectorCopy[1][0],
                        alphaVectorCopy[1][1], alphaVectorCopy[2][0], alphaVectorCopy[2][1]];
                        //num = FunctionUtils.generateNumberByVector(p, s, alphaVectorCopy);
                        //numberByVector.TryGetValue(alphaVectorCopy, out num);
                        // only real part
                        summ += Math.Cos(-2 * Math.PI * ( kthVector * alphaVector[k] ) / p) * Math.Pow(p, -s) * funValuesCopy[num];
                    }
                    coeffs[i] = summ;
                }
            }
            return coeffs.ToArray();
        }

        public override double[,] doAnalysis(double[,] values) {
            var N = calculateN(values.Length); // amount of alpha vectors
            var funValues = new double[values.GetLength(0), values.GetLength(1)];
            Array.Copy(values, funValues, values.Length); // size = p^(N*s )
            for(int k = 0; k < N; k++) {
                // k-th step of process
                var funValuesCopy = new double[values.GetLength(0), values.GetLength(1)];
                Array.Copy(funValues, funValuesCopy, values.Length);
                for(int i = 0; i < values.GetLength(0); i++) {
                    for(int j = 0; j < values.GetLength(1); j++) {
                        Vector<IntVector> alphaVector;
                        vectorByNumber.TryGetValue(i * values.GetLength(0) + j, out alphaVector);
                        var summ = 0.0;
                        foreach(var kthVector in allField.field) {
                            var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                            alphaVectorCopy[k] = kthVector;
                            int num;
                            num = vectors[alphaVectorCopy[0][0], alphaVectorCopy[0][1], alphaVectorCopy[1][0],
                        alphaVectorCopy[1][1], alphaVectorCopy[2][0], alphaVectorCopy[2][1]];
                            //num = FunctionUtils.generateNumberByVector(p, s, alphaVectorCopy);
                            //numberByVector.TryGetValue(alphaVectorCopy, out num);
                            // only real part
                            var coord_i = (int) num / funValuesCopy.GetLength(0);
                            var coord_j = num - ( funValuesCopy.GetLength(0) * coord_i );
                            summ += Math.Cos(-2 * Math.PI * ( kthVector * alphaVector[k] ) / p) * Math.Pow(p, s / 2) * Math.Pow(p, -s / 2) * funValuesCopy[coord_i, coord_j];
                        }
                        funValues[i, j] = summ;
                    }
                }
            }
            return funValues;
        }

        public override double[,] doSynthesis(double[,] coeffs) {
            var N = calculateN(coeffs.Length); // amount of alpha vectors
            var funCoeffs = new double[coeffs.GetLength(0), coeffs.GetLength(1)];
            Array.Copy(coeffs, funCoeffs, coeffs.Length); // size = p^(N*s)

            for(int k = 0; k < N; k++) {
                // k-th step of process
                var funCoeffsCopy = new double[coeffs.GetLength(0), coeffs.GetLength(1)];
                Array.Copy(funCoeffs, funCoeffsCopy, coeffs.Length);
                for(int i = 0; i < coeffs.GetLength(0); i++) {
                    for(int j = 0; j < coeffs.GetLength(1); j++) {
                        Vector<IntVector> alphaVector;
                        vectorByNumber.TryGetValue(i * coeffs.GetLength(0) + j, out alphaVector);
                        var summ = 0.0;
                        foreach(var kthVector in allField.field) {
                            var alphaVectorCopy = new Vector<IntVector>(alphaVector);
                            alphaVectorCopy[k] = kthVector;
                            int num;
                            num = vectors[alphaVectorCopy[0][0], alphaVectorCopy[0][1], alphaVectorCopy[1][0],
                        alphaVectorCopy[1][1], alphaVectorCopy[2][0], alphaVectorCopy[2][1]];
                            //num = FunctionUtils.generateNumberByVector(p, s, alphaVectorCopy);
                            //numberByVector.TryGetValue(alphaVectorCopy, out num);
                            // only real part
                            var coord_i = (int) num / funCoeffs.GetLength(0);
                            var coord_j = num - ( funCoeffs.GetLength(0) * coord_i );
                            summ += Math.Cos(-2 * Math.PI * ( kthVector * alphaVector[k] ) / p) * Math.Pow(p, -s) * funCoeffsCopy[coord_i, coord_j];
                        }
                        funCoeffs[i, j] = summ;
                    }
                }
            }
            return funCoeffs;
        }
    }
}
