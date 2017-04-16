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

        #region constructor
        public View() {
            InitializeComponent();
        }
        #endregion

        #region IView implementaion 
        public event EventHandler<BitmapEventArgs> imageSelected;
        public event EventHandler resultImageRequest;
        //public event EventHandler<ColorParameterNumberEventArgs> parameterInserted;

        public void setResultImage(Bitmap image) {
            if(resultImage != null) {
                resultImage.Image = image;
                resultImage.Invalidate();
            }
        }
        public void setColorParameterValue(ImageColor color, string parameter_str, double value) {
            if(parameter_str.Equals(ImageConstants.PARAM_MSE)) {
                switch(color) {
                    case ImageColor.RED:
                        setNewValueWithDelta(value, r_mse_value, r_mse_delta);
                        break;
                    case ImageColor.GREEN:
                        setNewValueWithDelta(value, g_mse_value, g_mse_delta);
                        break;
                    case ImageColor.BLUE:
                        setNewValueWithDelta(value, b_mse_value, b_mse_delta);
                        break;
                    default:
                        break;
                }               
            }
            if(parameter_str.Equals(ImageConstants.PARAM_PSNR)) {
                switch(color) {
                    case ImageColor.RED:
                        setNewValueWithDelta(value, r_psnr_value, r_psnr_delta);
                        break;
                    case ImageColor.GREEN:
                        setNewValueWithDelta(value, g_psnr_value, g_psnr_delta);
                        break;
                    case ImageColor.BLUE:
                        setNewValueWithDelta(value, b_psnr_value, b_psnr_delta);
                        break;
                    default:
                        break;
                }
            }
        }
        public void error(string message) {
            errorMessage.Text = message;
        }
        public double getColorParameterValue(ImageColor color, string parameter_str) {
            if(parameter_str.Equals(ImageConstants.PERCENTAGE)) {
                double value = 0.0;
                bool success = false;
                switch(color) {
                    case ImageColor.RED:
                        success = Double.TryParse(parameter_R_percentage.Text, out value);
                        break;
                    case ImageColor.GREEN:
                        success = Double.TryParse(parameter_G_percentage.Text, out value);
                        break;
                    case ImageColor.BLUE:
                        success = Double.TryParse(parameter_B_percentage.Text, out value);
                        break;
                    default:
                        break;
                }
                return ( success ) ? value : 0.0;
            }
            if(parameter_str.Equals(ImageConstants.ELEMENT_SIZE)) {
                return getSelectedElementSize();
            }
            throw new ArgumentException("Parameter {0} not found on view " + parameter_str);
        }
        public double getParameterValue(string parameter_str) {
            if(parameter_str.Equals(ImageConstants.ELEMENT_SIZE)) {
                return getSelectedElementSize();
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

        private double getSelectedElementSize() {
            if(radioButton_8.Checked) {
                return 8;
            }
            if(radioButton_16.Checked) {
                return 16;
            }
            if(radioButton_32.Checked) {
                return 32;
            }
            return 8;
        }
        private void setNewValueWithDelta(double newValue, TextBox oldValueBox, Label targetLabel) {
            if(!oldValueBox.Text.Equals("")) {
                double oldValue = Convert.ToDouble(oldValueBox.Text);
                double delta = ( ( newValue - oldValue ) / oldValue ) * 100;
                if(delta >= 0) {
                    targetLabel.ForeColor = Color.Green;
                    targetLabel.Text = "+" + Convert.ToString(delta) + "%";
                }
                else {
                    targetLabel.ForeColor = Color.Red;
                    targetLabel.Text = "-" + Convert.ToString(delta) + "%";
                }
                targetLabel.Text = Convert.ToString(delta);
            }
            oldValueBox.Text = Convert.ToString(newValue);
        }
        #endregion
    }
}
