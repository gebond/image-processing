using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingConstants {
    public static class ImageConstants {
        public static readonly string ELEMENT_SIZE = "element-size";

        // channels colors
        public static readonly string YCRCB_ENABLED = "YCrCb-enabled";
        public static readonly string PERCENTAGE = "percentage";

        // transformation methods
        public static readonly string FOURIER_BY_LOCAL = "fourier-local";
        public static readonly string FOURIER_BY_WALSH = "fourier-walsh";
        public static readonly string FOURIER_BY_HAART = "fourier-haart";

        //params
        public static readonly string MSE_PSNR_CALCULATE = "mse-psnr-calculate";
        public static readonly string PARAM_MSE = "param-mse";
        public static readonly string PARAM_PSNR = "param-psnr";
    }
}
