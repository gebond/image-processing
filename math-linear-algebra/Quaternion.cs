using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    /*class Quaternion : AbstractVector {

        #region IVector override
        public override double this[int index] {
            get {
                switch(index) {
                    case (0):
                        return w;
                    case (1):
                        return vector3.X;
                    case (2):
                        return vector3.Y;
                    case (3):
                        return vector3.Z;
                    default:
                        throw new IndexOutOfRangeException("Vector3 doesnt have index > 3");
                }
            }
            set {
                switch(index) {
                    case (0):
                        w = value;
                        break;
                    case (1):
                        vector3.X = value;
                        break;
                    case (2):
                        vector3.Y = value;
                        break;
                    case (3):
                        vector3.Z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Vector3 doesnt have index > 3");
                }
            }
        }
        public override void print() {
            Console.WriteLine("Quaternion: " + this.ToString());
        }
        public override int length {
            get { return 3; }
        }
        public override AbstractVector summa(AbstractVector vector1, AbstractVector vector2) {
            throw new NotImplementedException();
        }

        public override AbstractVector substract(AbstractVector vector1, AbstractVector vector2) {
            throw new NotImplementedException();
        }

        public override AbstractVector product(double a, AbstractVector vector) {
            throw new NotImplementedException();
        }

        public override AbstractVector product(int a, AbstractVector vector) {
            throw new NotImplementedException();
        }

        public override double product(AbstractVector vector1, AbstractVector vector2) {
            throw new NotImplementedException();
        }
        #endregion

        #region quaternion constructors
        public Quaternion(bool random) {
            if(random) {
                randomize();
            }
            else {

            }
        }
        public Quaternion(double x, double y, double z) {
            this.vector3.X = x;
            this.vector3.Y = y;
            this.vector3.Z = z;
        }
        public Quaternion(Vector3 vector) {
            this.vector3.X = vector.X;
            this.vector3.Y = vector.Y;
            this.vector3.Z = vector.Z;
        }
        public Quaternion(AbstractVector vector) {
            if(vector.length != 4) {
                throw new ArgumentException("can not create Quaternion with lenght != 4");
            }
            w = vector[0];
            vector3.X = vector[1];
            vector3.Y = vector[2];
            vector3.Z = vector[3];
        }
        #endregion

        #region private fields
        // Quaternion q = {w, v}; v = {x, y, z}
        private Vector3 vector3;
        private double w;
        #endregion

        #region override object methods
        public override string ToString() {
            return "[" + w + ", {" + vector3.X + ", " + vector3.Y + ", " + vector3.Z + "}]";
        }
        #endregion
    }*/
}
