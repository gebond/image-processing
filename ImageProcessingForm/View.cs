using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using ImageProcessingConstants;

namespace ImageProcessingForm {
    public partial class View : Form, IView {
        public View() {
            InitializeComponent();
        }
        #region IView implementaion 
        public event EventHandler<BitmapEventArgs> imageSelected;
        public event EventHandler resultImageRequest;
        public event EventHandler<ParameterNumberEventArgs> parameterInserted;

        public void setResultImage(Bitmap image) {
            if(resultImage != null) {
                resultImage.Image = image;
                resultImage.Invalidate();
            }
        }
        public void error(string message) {
            errorMessage.Text = message;
        }
        public double getParameterValue(string parameter_str) {
            if(parameter_str.Equals(ImageConstants.RED_PERCENTAGE)) {
                double value;
                var success = Double.TryParse(parameter_R_percentage.Text, out value);
                return ( success ) ? value : 0.0;
            }
            if(parameter_str.Equals(ImageConstants.GREEN_PERCENTAGE)) {
                double value;
                var success = Double.TryParse(parameter_G_percentage.Text, out value);
                return ( success ) ? value : 0.0;
            }
            if(parameter_str.Equals(ImageConstants.BLUE_PERCENTAGE)) {
                double value;
                var success = Double.TryParse(parameter_B_percentage.Text, out value);
                return ( success ) ? value : 0.0;
            }
            throw new ArgumentException("Parameter {0} not found on view " + parameter_str);
        }
        
        public string getSelectedFourierMethod() {
            var selected_index = selectedMethodBox.SelectedIndex;
            switch(selected_index) {
                case 0:
                    return ImageConstants.FOURIER_BY_MATRIX;
                case 1:
                    return ImageConstants.FOURIER_BY_WALSH;
                case 2:
                    return ImageConstants.FOURIER_BY_HAART;
            }
            return null;
        }
        #endregion

        #region Events creation
        private void selectImage_Click(object sender, EventArgs e) {
            var eventHandler = imageSelected;
            if(eventHandler != null) {
                if(sourceImage != null) {
                    var args = new BitmapEventArgs(createBitmap(sourceImage));
                    eventHandler(sender, args);
                }
            }
        }
        private void getResultImage_Click(object sender, EventArgs e) {
            clearError();
            resultImageRequest?.Invoke(sender, e);
        }
        private void errorLabel_Click(object sender, EventArgs e) {
            SystemSounds.Asterisk.Play();
            clearError();
        }


        #endregion

        #region validations

        private void parameter_R_percentage_TextChanged(object sender, EventArgs e) {
            var textBox = sender as TextBox;
            if(textBox != null) {
                validate(textBox);
            }
        }

        private void parameter_B_percentage_TextChanged(object sender, EventArgs e) {
            var textBox = sender as TextBox;
            if(textBox != null) {
                validate(textBox);
            }
        }

        private void parameter_G_percentage_TextChanged(object sender, EventArgs e) {
            var textBox = sender as TextBox;
            if(textBox != null) {
                validate(textBox);
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
        private void clearError() {
            if(errorMessage != null) {
                errorMessage.Text = "";
            }
        }
        private void validate(TextBox sender) {
            var text = sender.Text;
            double number;
            if(!Double.TryParse(text, out number) || number < 0 || number > 100) {
                sender.Text = "";
                error("Percentage must be double in range 0 - 100");
            }
        }
        private void reset_MouseClick(object sender, MouseEventArgs e) {
            this.parameter_R_percentage.Text = "100";
            this.parameter_B_percentage.Text = "100";
            this.parameter_G_percentage.Text = "100";
        }

        #endregion
        
    }
}
