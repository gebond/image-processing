using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    public class Vector<T> {

        #region constructors
        public Vector(int len) {
            if(len < 0) {
                throw new IndexOutOfRangeException("len was out of scope");
            }
            coord = new T[len];
        }

        public Vector(T[] initArray) {
            if(initArray == null || initArray.Length == 0) {
                throw new IndexOutOfRangeException("initarray was null or empty");
            }
            coord = new T[initArray.Length];
            for(int i = 0; i < length; i++) {
                coord[i] = initArray[i];
            }
        }

        public Vector(Vector<T> vector) {
            if(vector == null || vector.length == 0) {
                throw new IndexOutOfRangeException("init vector was null or empty");
            }
            coord = new T[vector.length];
            for(int i = 0; i < length; i++) {
                coord[i] = vector[i];
            }
        }
        #endregion

        #region general vector methods
        public T this[int index] {
            get {
                if(index < 0 || index >= length) {
                    throw new IndexOutOfRangeException("index was out of scope");
                }
                return coord[index];
            }
            set {
                if(index < 0 || index >= length) {
                    throw new IndexOutOfRangeException("index was out of scope");
                }
                coord[index] = value;
            }
        }
        public int length {
            get {
                return coord.Length;
            }
        }
        #endregion

        #region general abstract operations
        protected virtual bool fieldsMatch(Vector<T> vector) {
            for(int i = 0; i < length; i++) {
                if(!coord[i].Equals(vector[i])) {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region override object methods
        public static bool operator ==(Vector<T> a, Vector<T> b) {
            if(a != null) {
                return a.Equals(b);
            }
            return false;
        }
        public static bool operator !=(Vector<T> a, Vector<T> b) {
            return !( a.Equals(b) );
        }
        public override string ToString() {
            String result = "[";
            for(int i = 0; i < this.length; i++) {
                result += this[i];
                if(i != this.length - 1) {
                    result += ", ";
                }
            }
            result += "]";
            return result;
        }
        public override bool Equals(Object obj) {

            // If both are null, or both are same instance, return true.
            if(System.Object.ReferenceEquals(this, obj)) {
                return true;
            }
            // If one is null, but not both, return false.
            if(( (object) this == null ) || ( (object) obj == null )) {
                return false;
            }
            var vector = (Vector<T>) obj;
            if(vector == null) {
                throw new ArgumentException("Can not cast object to IVector type!");
            }
            if(vector.length != this.length) {
                throw new ArgumentException("Vectors must have similiar length!");
            }
            // Return true if the fields match:
            return fieldsMatch(vector);
        }
        public override int GetHashCode() {
            int hashcode = 0;
            for(int i = 0; i < this.length; i++) {
                hashcode = 31 * hashcode + (int) this[i].GetHashCode();
            }
            return hashcode;
        }
        #endregion

        #region private fields
        protected T[] coord;
        #endregion
    }
}