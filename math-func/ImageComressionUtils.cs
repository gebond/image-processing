using System;
using System.Threading.Tasks;

namespace MathFunction {
    public static class ComressionUtils {
        public static int[,] compress(int[,] inputValues, double compression_coeff) {
            var doubles = compress(Utils.createDouble(inputValues), compression_coeff);
            return Utils.createInt(doubles);
        }
        public static double[,] compress(double[,] inputValues, double compression_coeff) {
            if(compression_coeff < 0 || compression_coeff > 100) {
                throw new ArgumentException("compression coeff is incorect");
            }
            if(inputValues == null || inputValues.Length == 0) {
                throw new ArgumentException("input values are null or empty");
            }
            var amount_to_delete = (int) ( inputValues.Length * ( 1.0 - ( compression_coeff / 100.0 ) ) );
            apply_Coeff(inputValues, amount_to_delete);
            return inputValues;
        }

        #region private methods
        private static void apply_Coeff(double[,] target, int target_amount_of_deleted) {
            if(target_amount_of_deleted == 0) {
                return; // nothing to delete
            }
            int amount_of_deleted = 0;
            while(amount_of_deleted < target_amount_of_deleted) {
                var min = find_min_value(target);
                if(delete_first_by_value(target, min)) {
                    amount_of_deleted += 1;
                }
                else {
                    break; // not found min value
                }
            }
        }
        private static double find_min_value(double[,] target) {
            var min_value = Double.MaxValue;
            Parallel.For(0, target.GetLength(0), i => {
                for(int j = 0; j < target.GetLength(1); j++) {
                    if(target[i, j] != 0 && Math.Abs(target[i, j]) < min_value) {
                        min_value = target[i, j];
                    }
                }
            });
            return min_value;
        }
        private static bool delete_first_by_value(double[,] target, double targetValue) {
            for(int i = 0; i < target.GetLength(0); i++) {
                for(int j = 0; j < target.GetLength(1); j++) {
                    if(target[i, j] == targetValue) {
                        target[i, j] = 0;
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
