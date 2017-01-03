using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessingModel {
    class ColorElements {
        private ColorElement[,] elements;
        private int rowCount;
        private int colCount;

        public ColorElements(int sizeOfElement, Bitmap sourceImage) {
            initialize(sizeOfElement, sourceImage);
        }

        public void initialize(int sizeOfElement, Bitmap sourceImage) {
            if(sourceImage == null) { throw new ArgumentNullException("source image must be not null!"); }

            int height = sourceImage.Height;
            int width = sourceImage.Width;
            this.rowCount = height / sizeOfElement;
            this.colCount = width / sizeOfElement;

            elements = new ColorElement[rowCount, colCount];

            for(int i = 0; i < height; i++) {
                for(int j = 0; j < width; j++) {
                    elements[i, j][i, j] = sourceImage.GetPixel(i, j);
                }
            }
        }

        private void createAndFillElements(int sizeOfElement) {
            for(int i = 0; i < this.rowCount; i++) {
                for(int j = 0; j < this.colCount; j++) {
                    elements[i, j] = new ColorElement(sizeOfElement);
                }
            }
        }

        public void print() {
            foreach(var element in elements) {
                element.print();
            }
        }
    }
}
