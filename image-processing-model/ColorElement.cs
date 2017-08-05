using System;
using System.Drawing;
using System.Threading.Tasks;
using MathFunction;
using ImageProcessingConstants;

namespace ImageProcessingModel {
    /*
     ColorElement - NxN matrix which contains amount of pixels
         with get, set methods
         */
    public class ColorElement {

        #region public methods
        public ColorElement(int size) {
            if(size <= 0) {
                throw new ArgumentException("size can be less than 1");
            }
            this.size = size;
            pixeles = new Color[size, size];
        }
        public ColorElement(bool ycrb, double[,] colors_1, double[,] colors_2, double[,] colors_3) {
            if(( colors_1.GetLength(0) != colors_1.GetLength(1) ) ||
                ( colors_2.GetLength(0) != colors_2.GetLength(1) ) ||
                ( colors_3.GetLength(0) != colors_3.GetLength(1) )) {
                throw new Exception("imposible create Element with not quadratic lens");
            }
            if(( colors_2.Length != colors_1.Length ) || ( colors_1.Length != colors_3.Length )) {
                throw new Exception("imposible create Element with R_len != G_len != B_len");
            }
            this.size = (int) Math.Sqrt(colors_1.Length);
            pixeles = new Color[size, size];
            Parallel.For(0, size, i => {
                for(int j = 0; j < size; j++) {
                    Color color;
                    if(!ycrb) {
                        color = Color.FromArgb(
                            getValid(colors_1[i, j]),
                            getValid(colors_2[i, j]),
                            getValid(colors_3[i, j]));
                    }
                    else {
                        var y = colors_1[i, j];
                        var cr = colors_2[i, j];
                        var cb = colors_3[i, j];
                        var r = (int) ( y + 1.402 * ( cr - 128 ) );
                        var g = (int) ( y - 0.344136 * ( cb - 128 ) - 0.714136 * ( cr - 128 ) );
                        var b = (int) ( y + 1.772 * ( cb - 128 ) );
                        color = Color.FromArgb(
                            getValid(r),
                            getValid(g),
                            getValid(b));
                    }
                    pixeles[i, j] = color;
                }
            });
        }
        public Color this[int i, int j] {
            get {
                if(i < 0 || i >= size) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= size) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                return pixeles[i, j];
            }
            set {
                if(i < 0 || i >= size) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= size) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                pixeles[i, j] = value;
            }
        }

        public int this[int i, int j, int color] {
            get {
                if(i < 0 || i >= size) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= size) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                switch(color) {
                    case 1: { return pixeles[i, j].R; }
                    case 2: { return pixeles[i, j].G; }
                    case 3: { return pixeles[i, j].B; }
                    default: { throw new IndexOutOfRangeException("color is not defined"); }
                }
            }
        }
        public ColorElement recalculateElement(bool ycrcb, double rate_1, double rate_2, double rate_3, FourierTransformation transformation) {
            if(ycrcb) {
                var ys = getYColors();
                var y_coeffs = TransformationUtils.get2DCoeffs(ys, transformation);
                y_coeffs = ComressionUtils.compress(y_coeffs, rate_1);
                ys = TransformationUtils.get2DValues(y_coeffs, transformation);

                var crs = getCrColors();
                var cr_coeffs = TransformationUtils.get2DCoeffs(crs, transformation);
                cr_coeffs = ComressionUtils.compress(cr_coeffs, rate_2);
                crs = TransformationUtils.get2DValues(cr_coeffs, transformation);

                var cbs = getCbColors();
                var cb_coeffs = TransformationUtils.get2DCoeffs(cbs, transformation);
                cb_coeffs = ComressionUtils.compress(cb_coeffs, rate_3);
                cbs = TransformationUtils.get2DValues(cb_coeffs, transformation);
                return new ColorElement(ycrcb, ys, crs, cbs);

            }
            var reds = getRColors();
            var red_coeffs = TransformationUtils.get2DCoeffs(reds, transformation);
            red_coeffs = ComressionUtils.compress(red_coeffs, rate_1);
            reds = TransformationUtils.get2DValues(red_coeffs, transformation);

            var greens = getGColors();
            var green_coeffs = TransformationUtils.get2DCoeffs(greens, transformation);
            green_coeffs = ComressionUtils.compress(green_coeffs, rate_2);
            greens = TransformationUtils.get2DValues(green_coeffs, transformation);

            var blues = getBColors();
            var blue_coeffs = TransformationUtils.get2DCoeffs(blues, transformation);
            blue_coeffs = ComressionUtils.compress(blue_coeffs, rate_3);
            blues = TransformationUtils.get2DValues(blue_coeffs, transformation);
            return new ColorElement(ycrcb, reds, greens, blues);
        }
        public void print() {
            Console.WriteLine("Element:");
            for(int i = 0; i < size; i++) {
                for(int j = 0; j < size; j++) {
                    Console.Write("[{0}, {1}, {2}]", pixeles[i, j].R, pixeles[i, j].G, pixeles[i, j].B);
                }
                Console.Write("\n");
            }
        }
        #endregion

        #region private fields
        private Color[,] pixeles;
        private int size;
        #endregion

        #region private methods
        private double[,] getRColors() {
            return getColor(ImageColor.RED);
        }
        private double[,] getGColors() {
            return getColor(ImageColor.GREEN);
        }
        private double[,] getBColors() {
            return getColor(ImageColor.BLUE);
        }
        private double[,] getYColors() {
            return getColor(ImageColor.Y);
        }
        private double[,] getCrColors() {
            return getColor(ImageColor.CR);
        }
        private double[,] getCbColors() {
            return getColor(ImageColor.CB);
        }
        private double[,] getColor(ImageColor color_chanel) {
            var result = new double[size, size];
            Parallel.For(0, size, i => {
                for(int j = 0; j < size; j++) {
                    switch(color_chanel) {
                        case ImageColor.RED:
                            result[i, j] = pixeles[i, j].R;
                            break;
                        case ImageColor.GREEN:
                            result[i, j] = pixeles[i, j].G;
                            break;
                        case ImageColor.BLUE:
                            result[i, j] = pixeles[i, j].B;
                            break;
                        case ImageColor.Y:
                            result[i, j] = (float) ( 0.299 * pixeles[i, j].R + 0.587 * pixeles[i, j].G + 0.114 * pixeles[i, j].B );
                            break;
                        case ImageColor.CR:
                            result[i, j] = (float) ( 128 + 0.5 * pixeles[i, j].R - 0.418688 * pixeles[i, j].G - 0.081312 * pixeles[i, j].B );
                            break;
                        case ImageColor.CB:
                            result[i, j] = (float) ( 128 - 0.168736 * pixeles[i, j].R - 0.33264 * pixeles[i, j].G + 0.5 * pixeles[i, j].B );
                            break;
                    }
                }
            });
            return result;
        }

        private int getValid(double value) {
            if(value > 255) {
                return 255;
            }
            if(value < 0) {
                return 0;
            }
            return (int) value;
        }
        #endregion

    }
}
