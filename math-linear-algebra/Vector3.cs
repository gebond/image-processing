using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebra {
    /*class Vector3 : DoubleVector {
        /*
        #region vector3 constructors
        public Vector3() {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public Vector3(bool random) {
            if(random) {
                randomize();
            }
        }
        public Vector3(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(Vector3 vector) {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
        public Vector3(Vector<double> vector) {
            if(vector.length != 3) {
                throw new ArgumentException("can not create Vector3 with lenght != 3");
            }
            x = vector[0];
            y = vector[1];
            z = vector[2];
        }
        public Vector3(int len) : base(len) {
        }
        public Vector3(double[] initArray) : base(initArray) {
        }
        public Vector3(Vector<double> vector) : base(vector) {
        }
        #endregion

        #region Vector3 features
        public double X {
            get {
                return x;
            }
            set {
                x = value;
            }
        }
        public double Y {
            get {
                return y;
            }
            set {
                y = value;
            }
        }
        public double Z {
            get {
                return z;
            }
            set {
                z = value;
            }
        }
        #endregion

        #region IVector override
        public override double this[int index] {
            get {
                switch(index) {
                    case (0):
                        return x;
                    case (1):
                        return y;
                    case (2):
                        return z;
                    default:
                        throw new IndexOutOfRangeException("Vector3 doesnt have index > 2");
                }
            }
            set {
                switch(index) {
                    case (0):
                        x = value;
                        break;
                    case (1):
                        y = value;
                        break;
                    case (2):
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Vector3 doesnt have index > 2");
                }
            }
        }
        public override void print() {
            Console.WriteLine("Vector3: " + this.ToString());
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

        public override int length {
            get { return 3; }
        }
        #endregion

        

        #region private fields
        private double x;
        private double y;
        private double z;
        #endregion
        
}*/
}
