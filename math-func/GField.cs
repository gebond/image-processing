using System;
using LinearAlgebra;
using System.Collections.Generic;

namespace MathFunction {
    public class GField {

        public readonly List<IntVector> field;
        public readonly IntVector zero;

        // GF(p^s)
        public GField(int p, int s) {
            if(p < 0 || !FunUtils.isPrime(p)) {
                throw new ArgumentException("p - must be prime!");
            }
            if(s < 0) {
                throw new ArgumentException("s - must be bigger than 0!");
            }
            this.s = s;
            this.p = p;
            field = new List<IntVector>();
            var vector = new IntVector(s);
            zero = new IntVector(vector);
            setCurrentIndex(-1, 0, vector);
        }

        private void setCurrentIndex(int current_index, int current_value, IntVector targetVector) {
            if(current_index >= 0) {
                targetVector[current_index] = current_value;
            }
            if(current_index == this.s - 1) {
                field.Add(new IntVector(targetVector));
                return;
            }
            else {
                for(int i = 0; i < this.p; i++) {
                    setCurrentIndex(current_index + 1, i, targetVector);
                }
            }
            return;
        }

        #region private fields
        private int p;
        private int s;
        #endregion
    }
}
