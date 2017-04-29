using System;
using LinearAlgebra;

namespace MathFunction {
    public static class FunctionUtils {

        #region Rademacher Function
        // r_0(x) for x: from 0 to 1
        public static double rademacher(double x) {
            x = getValid(x);
            if(( x >= 0 && x < 0.5 ) || x == 1) {
                return 1;
            }
            else {
                return -1;
            }
        }
        // r_k(x) for real x
        public static double rademacher(int k, double x) {
            if(k < 0) {
                throw new ArgumentException("k > 0 must be for Rademacher Function");
            }
            return rademacher(Math.Pow(2, k) * x);
        }
        #endregion

        #region Haart Function
        public static double haart(int m, int k, double x) {
            if(k == 0 && m == 0) {
                return 1.0;
            }
            if(k < 0 && ( m < 0 || k >= Math.Pow(2, m) )) {
                throw new ArgumentException("Wrong args Haart function: k = 0, 1, ..., 2^m - 1");
            }
            x = getValid(x);
            var powM = Math.Pow(2, m);
            if(x >= ( (double) k - 1 ) / powM && x < ( (double) k - 0.5 ) / powM) {
                //return Math.Sqrt(powM);
                return 1.0;
            }
            if(x >= ( (double) k - 0.5 ) / powM && x < ( (double) k ) / powM) {
                //return -Math.Sqrt(powM);
                return -1.0;
            }
            return 0.0;
        }
        public static double haart(int n, double x) {
            if(n == 0) {
                return haart(0, 0, x);
            }
            if(n == 1) {
                return haart(0, 1, x);
            }
            var m = (int) Math.Truncate(Math.Log(n, 2));
            var k = 1;
            var targetK = (int) Math.Pow(2, m);
            while(targetK != n) {
                targetK++;
                k++;
            }
            return haart(m, k, x);
        }
        #endregion

        #region Walsh Function
        // w_k(x)
        public static double walsh(int n, double x) {
            if(n < 0) {
                throw new ArgumentException("n > 0 must be for Walsh Function");
            }
            var result = 1.0;
            if(n != 0) {
                var eps = paley(n); // get array of {1, 0} according to Paley Numbers
                for(int i = 0; i < eps.Length; i++) {
                    result = result * Math.Pow(rademacher(i, x), eps[i]);
                }
            }
            return result;
        }
        #endregion

        #region Paley Numbers
        // Paley is the method of getting array of coeffs for Epsilons {1, 0} for input Value n
        public static int[] paley(int n) {
            // k is number of the elder pow of epsilon
            var k = (int) Math.Truncate(Math.Log(n, 2));
            var result = new int[k + 1];
            result[k] = 1;
            // checks if n is not power of 2
            if(Math.Log(n, 2) - k != 0) {
                findCoeffs(n, k, 1, result);
                result = targetResult;
            }
            return result;
        }
        private static void findCoeffs(int n, int k, int tryDigit, int[] sourceArray) {
            sourceArray[k] = tryDigit;
            if(k < 1) {
                if(summaWithPowOfTwo(sourceArray) == n) {
                    targetResult = new int[sourceArray.Length];
                    Array.Copy(sourceArray, targetResult, sourceArray.Length);
                    return;
                }
                return;
            }
            else {
                findCoeffs(n, k - 1, 1, sourceArray);
                findCoeffs(n, k - 1, 0, sourceArray);
            }
            return;
        }
        private static int[] targetResult;
        private static double summaWithPowOfTwo(int[] array) {
            var res = 0.0;
            for(int i = 0; i < array.Length; i++) {
                res += array[i] * Math.Pow(2, i);
            }
            return res;
        }
        #endregion

        #region New SF Feature
        // is n prime
        public static bool isPrime(int n) {
            for(int i = 2; i <= Math.Sqrt(n); i++) {
                if(n % i == 0) {
                    return false;
                }
            }
            return true;
        }

        public static int generateNumberByVector(int p, int s, Vector<IntVector> array) {
            var result = 0.0;
            var ps = Math.Pow(p, s);
            for(int i = 0; i < array.length; i++) {
                var var = 0.0;
                for(int j = 0; j < array[i].length; j++) {
                    var += array[i][j] * Math.Pow(p, j);
                }
                result += var * Math.Pow(ps, array.length - 1 - i);
            }
            return (int) result;
        }

        public static Vector<IntVector> getVectorByNumber(GField gfield, int N, int p, int s, int number) {
            var vector = new Vector<IntVector>(N);
            for(int i = 0; i < vector.length; i++) {
                vector[i] = gfield.zero;
            }
            foreach(var alpha in gfield.field) {
                search(gfield, vector, alpha, number, 0, p, s);
            }
            return resultVector;
        }

        private static void search(GField gfield, Vector<IntVector> target, IntVector tryVector, int targetNumber, int currentIndex, int p, int s) {
            target[currentIndex] = tryVector;
            if(currentIndex == target.length - 1) {
                if(generateNumberByVector(p, s, target) == targetNumber) {
                    resultVector = new Vector<IntVector>(target);
                    return;
                }
                return;
            }
            else {
                foreach(var vector in gfield.field) {
                    search(gfield, target, vector, targetNumber, currentIndex + 1, p, s);
                }
            }
            return;
        }
        private static Vector<IntVector> resultVector;
        /**
         * len : length of input array
         * p: prime
         * s: lentgth of vectors
         * N: amount of vectors
         * */
        public static int getPParameter(int len, int s, int N) {
            if(len <= 0 || N <= 0 || s <= 0) {
                throw new ArgumentException("len, N, s must be > 0");
            }
            var sq_len = (int) Math.Pow(len, 1.0 / ( s + N ));
            if(isPrime(sq_len)) {
                return sq_len;
            }
            throw new ArgumentException("len, N, s are inccorect!");
        }
        #endregion

        #region private methods
        private static double getValid(double x) {
            if(x >= 1) {
                x = x - Math.Truncate(x);
            }
            else if(x < 0) {
                x = 1 - ( Math.Abs(x) - Math.Truncate(Math.Abs(x)) );
            }
            return x;
        }
        #endregion
    }
}
