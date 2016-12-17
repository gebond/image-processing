using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessingForm {
    public partial class View : Form, IView {
        public View() {
            InitializeComponent();
        }
        #region IView implementaion 
        public event EventHandler<BitmapEventArgs> imageSelected;

        #endregion

        #region Events creation
        private void selectImage_Click(object sender, EventArgs e) {
            var eventHandler = imageSelected;
            if(eventHandler != null) {
                if(pictureBox1 != null) {
                    var args = new BitmapEventArgs(createBitmap(pictureBox1));
                    eventHandler(sender, args);
                }
            }
        }
        #endregion

        #region private methods
        private Bitmap createBitmap(PictureBox pictureBox) {
            Bitmap image = null;
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if(openFileDialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try {
                    image = new Bitmap(openFileDialog.FileName);
                    pictureBox.Image = image;
                    pictureBox.Invalidate();
                }
                catch {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return image;
        }
        #endregion
    }
}
