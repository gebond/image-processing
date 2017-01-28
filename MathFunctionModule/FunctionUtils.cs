using System;

namespace MathFunctionModule {
    public static class FunctionUtils {

        #region Rademacher Function
        // r_0(x) for x: from 0 to 1
        public static double rademacher(double x) {
            if(x < 0 || x >= 1) {
                x = x - Math.Truncate(x);
            }
            if(x >= 0 && x < 0.5) {
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
        public static double haart(int k, double x) {
            return 0;
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
                for(int k = 0; k < eps.Length; k++) {
                    result = result * Math.Pow(rademacher(k, x), eps[k]);
                }
            }
            return result;
        }
        #endregion

        #region Paley Numbers
        // Paley is the method of getting array of coeffs for Epsilons {1, 0} for input Value n
        public static int[] paley(int n) {
            // k is number of the elder pow of epsilon
            var k = (int)Math.Truncate(Math.Log(n, 2));
            var result = new int[k + 1];
            result[k] = 1;
            // checks if n is not power of 2
            if(Math.Log(n, 2) - k != 0) {
                // TODO fix recursion whenever, now fuck it, i'm done
                findCoeffs(n, k, 1, result);
                result = targetResult;
            }
            return result;
        }
        private static void findCoeffs(int n, int k, int tryDigit, int[] sourceArray) {
            sourceArray[k] = tryDigit;
            Console.WriteLine("k = {0}, digit = {1}", k, tryDigit);
            if(k < 1) {
                if(summaWithPowOfTwo(sourceArray) == n) {
                    Console.WriteLine("Summa found!", summaWithPowOfTwo(sourceArray));
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
    }
}
