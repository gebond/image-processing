using LinearAlgebra;
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

        private Color[,] pixeles;
        private int size;

        public ColorElement(int size) {
            if(size <= 0) {
                throw new ArgumentException("size can be less than 1");
            }
            this.size = size;
            pixeles = new Color[size, size];
        }

        public Color this[int i, int j] {
            get {
                if(i < 0 || i >= pixeles.Length) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= pixeles.Length) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                return pixeles[i, j];
            }
            set {
                if(i < 0 || i >= pixeles.Length) {
                    throw new IndexOutOfRangeException("index i < 0 or index i >= length");
                }
                if(j < 0 || j >= pixeles.Length) {
                    throw new IndexOutOfRangeException("index j < 0 or index j >= length");
                }
                pixeles[i, j] = value;
            }
        }

        public void print() {
            Console.WriteLine("Element:");
            for(int i = 0; i < size; i++) {
                for(int j = 0; j < size; j++) {
                    Console.Write("{0} ", pixeles[i, j].ToString());
                }
                Console.Write("\n");
            }
        }
    }
}
