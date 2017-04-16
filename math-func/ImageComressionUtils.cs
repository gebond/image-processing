using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            var list = new List<Value>();
            for(int i = 0; i < target.GetLength(0); i++) {
                for(int j = 0; j < target.GetLength(1); j++) {
                    list.Add(new Value(i, j, target[i, j]));
                }
            }
            var deleted = 0;
            var quer = list.OrderBy(x => x.absValue);
            foreach(var item in quer) {
                if(deleted < target_amount_of_deleted) {
                    target[item.i, item.j] = 0;
                    deleted++;
                }
                else {
                    break;
                }
            }
        }
        private class Value {
            public int i;
            public int j;
            public double value;

            public double absValue {
                get { return Math.Abs(value); }
            }

            public Value(int i, int j, double value) {
                this.i = i;
                this.j = j;
                this.value = value;
            }
        }
        #endregion
    }
}
