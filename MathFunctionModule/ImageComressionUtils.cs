using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunctionModule {
    public static class ImageComressionUtils {
        public static int[,] compress(int[,] inputValues, double compression_coeff) {
            if(compression_coeff < 0 || compression_coeff > 100) {
                throw new ArgumentException("compression coeff is incorect");
            }
            if(inputValues == null || inputValues.Length == 0) {
                throw new ArgumentException("input values are null or empty");
            }
            var amount_to_delete = (int)(inputValues.Length * ( 1.0 - ( compression_coeff / 100.0 )));
            apply_Coeff(inputValues, amount_to_delete);
            return null;
        }

        private static void apply_Coeff(int[,] target, int target_amount_of_deleted) {
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
            Console.WriteLine("Deleted {0} of {1}", amount_of_deleted, target_amount_of_deleted);
        }

        private static int find_min_value(int[,] target) {
            var min_value = Int32.MaxValue;
            for(int i = 0; i < target.GetLength(0); i++) {
                for(int j = 0; j < target.GetLength(1); j++) {
                    if(target[i,j] != 0 && target[i, j] < min_value) {
                        min_value = target[i, j];
                    }
                }
            }
            return min_value;
        }
        private static bool delete_first_by_value(int[,] target, int targetValue) {
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


    }
}
