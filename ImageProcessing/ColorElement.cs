using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public ColorElement(int[,] red_colors, int[,] green_colors, int[,] blue_colors) {
            if(( red_colors.GetLength(0) != red_colors.GetLength(1) ) ||
                ( green_colors.GetLength(0) != green_colors.GetLength(1) ) ||
                ( blue_colors.GetLength(0) != blue_colors.GetLength(1) )) {
                throw new Exception("imposible create Element with not quadratic lens");
            }
            if(( red_colors.Length != green_colors.Length ) || ( green_colors.Length != blue_colors.Length )) {
                throw new Exception("imposible create Element with R_len != G_len != B_len");
            }
            this.size =(int) Math.Sqrt(red_colors.Length);
            pixeles = new Color[size, size];
            for(int i = 0; i < size; i++) {
                for(int j = 0; j < size; j++) {
                    var color = Color.FromArgb(red_colors[i, j], green_colors[i, j], blue_colors[i, j]);
                    pixeles[i, j] = color;
                }
            }
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
        public int[,] getRColors() {
            return getColor('r');
        }
        public int[,] getGColors() {
            return getColor('g');
        }
        public int[,] getBColors() {
            return getColor('b');
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
        private int[,] getColor(char color_symbol) {
            var result = new int[size, size];
            for(int i = 0; i < size; i++) {
                for(int j = 0; j < size; j++) {
                    switch(color_symbol) {
                        case 'r':
                            result[i, j] = pixeles[i, j].R;
                            break;
                        case 'g':
                            result[i, j] = pixeles[i, j].G;
                            break;
                        case 'b':
                            result[i, j] = pixeles[i, j].B;
                            break;
                    }
                }
            }
            return result;
        }
        #endregion

    }
}
