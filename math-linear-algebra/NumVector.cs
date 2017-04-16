using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    public abstract class NumVector<T> : Vector<T> {

        #region constructors
        protected NumVector(int len) : base(len) {
        }
        protected NumVector(T[] initArray) : base(initArray) {
        }
        protected NumVector(Vector<T> vector) : base(vector) {
        }
        #endregion

        #region general abstract methods
        public abstract double norm { get; }
        public abstract void normalize();
        public abstract void randomize(T lower, T upper);
        public abstract NumVector<T> ones { get; }
        public abstract NumVector<T> zeros { get; }
        public abstract NumVector<T> minus(NumVector<T> vect1, NumVector<T> vect2);
        public abstract NumVector<T> plus(NumVector<T> vect1, NumVector<T> vect2);
        public abstract double product(NumVector<T> vect1, NumVector<T> vect2);
        #endregion

        #region general operations
        #endregion
    }
}
