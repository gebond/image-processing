using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessingModel {
    class ColorElements {

        #region public methods
        public ColorElements(int sizeOfElement, Bitmap sourceImage) {
            initialize(sizeOfElement, sourceImage);
        }
        public List<ColorElement> getElementsAsList() {
            var list = new List<ColorElement>();
            if(elements == null) {
                return list;
            }
            for(int i = 0; i < this.rowCount; i++) {
                for(int j = 0; j < this.colCount; j++) {
                    list.Add(elements[i, j]);
                }
            }
            return list;
        }
        public void replaceElements(List<ColorElement> newElements) {
            if(!( newElements.Count == rowCount * colCount )) {
                throw new ArgumentException("input list has not enough elements");
            }
            Parallel.For(0, this.rowCount, i => {
                for(int j = 0; j < this.colCount; j++) {
                    elements[i, j] = newElements[i * colCount + j];
                }
            });
        }

        public Bitmap buildImage() {
            var height = rowCount * size;
            var width = colCount * size;
            var image = new Bitmap(width, height);
            for(int i = 0; i < height; i++) {
                for(int j = 0; j < width; j++) {
                    image.SetPixel(j, i, elements[i / size, j / size][i % size, j % size]);
                }
            }
            return image;
        }
        public void print() {
            foreach(var element in elements) {
                element.print();
            }
        }
        #endregion

        #region private fields
        private ColorElement[,] elements;
        private int rowCount;
        private int colCount;
        private int size;
        #endregion

        #region private methods
        private void initialize(int sizeOfElement, Bitmap sourceImage) {
            if(sourceImage == null) { throw new ArgumentNullException("source image must be not null!"); }

            int height = sourceImage.Height;
            int width = sourceImage.Width;
            if(height < sizeOfElement || width < sizeOfElement) {
                throw new ArgumentException("size must be less than width and height");
            }
            initializeValues(sizeOfElement, width, height);
            createElements();
            copyPixeles(sourceImage);
            Console.WriteLine("ColorElements were initialized Rows = {0} Cols = {1} size = {2}", rowCount, colCount, size);
        }
        private void initializeValues(int size, int width, int height) {
            this.rowCount = height / size;
            this.colCount = width / size;
            this.size = size;
            this.elements = new ColorElement[rowCount, colCount];
        }
        private void createElements() {
            Parallel.For(0, rowCount, i => {
                for(int j = 0; j < this.colCount; j++) {
                    elements[i, j] = new ColorElement(size);
                }
            });
        }
        private void copyPixeles(Bitmap sourceImage) {
            for(int i = 0; i < size * rowCount; i++) {
                for(int j = 0; j < size * colCount; j++) {
                    elements[i / size, j / size][i % size, j % size] = sourceImage.GetPixel(j, i);
                }
            }
        }
        #endregion
    }
}
