using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingForm {
    public class NumberEventArgs : EventArgs {
        private double number;
        public NumberEventArgs(double number) {
            this.number = number;
        }

        public double Number {
            get { return number; }
        }
    }
}
