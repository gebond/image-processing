using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunctionModule
{
    public interface FourierTransformation
    {
        // doAnalysis returns FourierCoeffs using input values of function
        double[] doAnalysis(double[] values);
        // doSynthesis returns Values of function using input values of function
        double[] doSynthesis(double[] coeff);
    }
}
