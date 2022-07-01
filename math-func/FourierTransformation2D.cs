using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunction {
    public abstract class FourierTransformation2D : FourierTransformation {
        // doAnalysis returns FourierCoeffs using input values of function
        public abstract double[,] doAnalysis(double[,] values);
        // doSynthesis returns Values of function using input values of function
        public abstract double[,] doSynthesis(double[,] coeff);
    }
}
