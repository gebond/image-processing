using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingConstants {
    public static class ImageConstants {
        public static readonly string ELEMENT_SIZE = "element-size";

        // channels colors
        public static readonly string RED_PERCENTAGE = "r-percentage";
        public static readonly string GREEN_PERCENTAGE = "g-percentage";
        public static readonly string BLUE_PERCENTAGE = "b-percentage";

        // transformation methods
        public static readonly string FOURIER_BY_MATRIX = "fourier-matrix";
        public static readonly string FOURIER_BY_WALSH = "fourier-walsh";
        public static readonly string FOURIER_BY_HAART = "fourier-haart";
    }
}
