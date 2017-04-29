namespace ImageProcessingForm {
    partial class View {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.sourceImage = new System.Windows.Forms.PictureBox();
            this.resultImage = new System.Windows.Forms.PictureBox();
            this.selectImage = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorMessage = new System.Windows.Forms.Label();
            this.getResultImage = new System.Windows.Forms.Button();
            this.parameter_R_percentage = new System.Windows.Forms.TextBox();
            this.label_R_percentage = new System.Windows.Forms.Label();
            this.label_B_percentage = new System.Windows.Forms.Label();
            this.parameter_B_percentage = new System.Windows.Forms.TextBox();
            this.label_parameter_G = new System.Windows.Forms.Label();
            this.parameter_G_percentage = new System.Windows.Forms.TextBox();
            this.reset = new System.Windows.Forms.Button();
            this.selectedMethodBox = new System.Windows.Forms.ComboBox();
            this.sizeElementBox = new System.Windows.Forms.GroupBox();
            this.radioButton_8 = new System.Windows.Forms.RadioButton();
            this.radioButton_16 = new System.Windows.Forms.RadioButton();
            this.radioButton_32 = new System.Windows.Forms.RadioButton();
            this.colorParamsBox = new System.Windows.Forms.GroupBox();
            this.oldImage1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.resultParamsBox = new System.Windows.Forms.GroupBox();
            this.g_psnr_delta = new System.Windows.Forms.Label();
            this.b_psnr_delta = new System.Windows.Forms.Label();
            this.r_psnr_delta = new System.Windows.Forms.Label();
            this.g_mse_delta = new System.Windows.Forms.Label();
            this.b_mse_delta = new System.Windows.Forms.Label();
            this.r_mse_delta = new System.Windows.Forms.Label();
            this.g_psnr_value = new System.Windows.Forms.TextBox();
            this.b_psnr_value = new System.Windows.Forms.TextBox();
            this.r_psnr_value = new System.Windows.Forms.TextBox();
            this.psnr_param_label = new System.Windows.Forms.Label();
            this.mse_param_label = new System.Windows.Forms.Label();
            this.g_param_label = new System.Windows.Forms.Label();
            this.g_mse_value = new System.Windows.Forms.TextBox();
            this.b_param_label = new System.Windows.Forms.Label();
            this.b_mse_value = new System.Windows.Forms.TextBox();
            this.r_param_label = new System.Windows.Forms.Label();
            this.r_mse_value = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
            this.sizeElementBox.SuspendLayout();
            this.colorParamsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.resultParamsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceImage
            // 
            this.sourceImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sourceImage.Location = new System.Drawing.Point(12, 12);
            this.sourceImage.Name = "sourceImage";
            this.sourceImage.Size = new System.Drawing.Size(354, 300);
            this.sourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sourceImage.TabIndex = 0;
            this.sourceImage.TabStop = false;
            // 
            // resultImage
            // 
            this.resultImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultImage.Location = new System.Drawing.Point(629, 12);
            this.resultImage.Name = "resultImage";
            this.resultImage.Size = new System.Drawing.Size(354, 300);
            this.resultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resultImage.TabIndex = 1;
            this.resultImage.TabStop = false;
            // 
            // selectImage
            // 
            this.selectImage.Location = new System.Drawing.Point(397, 12);
            this.selectImage.Name = "selectImage";
            this.selectImage.Size = new System.Drawing.Size(193, 23);
            this.selectImage.TabIndex = 2;
            this.selectImage.Text = "Select source image";
            this.selectImage.UseVisualStyleBackColor = true;
            this.selectImage.Click += new System.EventHandler(this.selectImage_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(10, 10);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 13);
            this.errorMessage.TabIndex = 3;
            this.errorMessage.Click += new System.EventHandler(this.errorLabel_Click);
            // 
            // getResultImage
            // 
            this.getResultImage.Location = new System.Drawing.Point(397, 288);
            this.getResultImage.Name = "getResultImage";
            this.getResultImage.Size = new System.Drawing.Size(193, 23);
            this.getResultImage.TabIndex = 4;
            this.getResultImage.Text = "Get result image";
            this.getResultImage.UseVisualStyleBackColor = true;
            this.getResultImage.Click += new System.EventHandler(this.getResultImage_Click);
            // 
            // parameter_R_percentage
            // 
            this.parameter_R_percentage.Location = new System.Drawing.Point(45, 24);
            this.parameter_R_percentage.Name = "parameter_R_percentage";
            this.parameter_R_percentage.Size = new System.Drawing.Size(26, 20);
            this.parameter_R_percentage.TabIndex = 5;
            this.parameter_R_percentage.Tag = "";
            this.parameter_R_percentage.Text = "100";
            this.parameter_R_percentage.TextChanged += new System.EventHandler(this.parameter_R_percentage_TextChanged);
            // 
            // label_R_percentage
            // 
            this.label_R_percentage.AutoSize = true;
            this.label_R_percentage.Location = new System.Drawing.Point(13, 27);
            this.label_R_percentage.Name = "label_R_percentage";
            this.label_R_percentage.Size = new System.Drawing.Size(26, 13);
            this.label_R_percentage.TabIndex = 6;
            this.label_R_percentage.Text = "R %";
            // 
            // label_B_percentage
            // 
            this.label_B_percentage.AutoSize = true;
            this.label_B_percentage.Location = new System.Drawing.Point(15, 75);
            this.label_B_percentage.Name = "label_B_percentage";
            this.label_B_percentage.Size = new System.Drawing.Size(25, 13);
            this.label_B_percentage.TabIndex = 8;
            this.label_B_percentage.Text = "B %";
            // 
            // parameter_B_percentage
            // 
            this.parameter_B_percentage.Location = new System.Drawing.Point(45, 72);
            this.parameter_B_percentage.Name = "parameter_B_percentage";
            this.parameter_B_percentage.Size = new System.Drawing.Size(26, 20);
            this.parameter_B_percentage.TabIndex = 7;
            this.parameter_B_percentage.Text = "100";
            this.parameter_B_percentage.TextChanged += new System.EventHandler(this.parameter_B_percentage_TextChanged);
            // 
            // label_parameter_G
            // 
            this.label_parameter_G.AutoSize = true;
            this.label_parameter_G.Location = new System.Drawing.Point(14, 123);
            this.label_parameter_G.Name = "label_parameter_G";
            this.label_parameter_G.Size = new System.Drawing.Size(26, 13);
            this.label_parameter_G.TabIndex = 10;
            this.label_parameter_G.Text = "G %";
            // 
            // parameter_G_percentage
            // 
            this.parameter_G_percentage.Location = new System.Drawing.Point(45, 120);
            this.parameter_G_percentage.Name = "parameter_G_percentage";
            this.parameter_G_percentage.Size = new System.Drawing.Size(26, 20);
            this.parameter_G_percentage.TabIndex = 9;
            this.parameter_G_percentage.Text = "100";
            this.parameter_G_percentage.TextChanged += new System.EventHandler(this.parameter_G_percentage_TextChanged);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(16, 158);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(55, 23);
            this.reset.TabIndex = 11;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.reset_MouseClick);
            // 
            // selectedMethodBox
            // 
            this.selectedMethodBox.FormattingEnabled = true;
            this.selectedMethodBox.Items.AddRange(new object[] {
            "transformation by LocalField",
            "transformation by Walsh",
            "transformation by Haart"});
            this.selectedMethodBox.Location = new System.Drawing.Point(397, 261);
            this.selectedMethodBox.Name = "selectedMethodBox";
            this.selectedMethodBox.Size = new System.Drawing.Size(193, 21);
            this.selectedMethodBox.TabIndex = 13;
            this.selectedMethodBox.Text = "select method";
            // 
            // sizeElementBox
            // 
            this.sizeElementBox.Controls.Add(this.radioButton_8);
            this.sizeElementBox.Controls.Add(this.radioButton_16);
            this.sizeElementBox.Controls.Add(this.radioButton_32);
            this.sizeElementBox.Location = new System.Drawing.Point(504, 55);
            this.sizeElementBox.Name = "sizeElementBox";
            this.sizeElementBox.Size = new System.Drawing.Size(86, 109);
            this.sizeElementBox.TabIndex = 15;
            this.sizeElementBox.TabStop = false;
            this.sizeElementBox.Text = "size of elements";
            // 
            // radioButton_8
            // 
            this.radioButton_8.AutoSize = true;
            this.radioButton_8.Checked = true;
            this.radioButton_8.Location = new System.Drawing.Point(26, 38);
            this.radioButton_8.Name = "radioButton_8";
            this.radioButton_8.Size = new System.Drawing.Size(31, 17);
            this.radioButton_8.TabIndex = 2;
            this.radioButton_8.TabStop = true;
            this.radioButton_8.Text = "8";
            this.radioButton_8.UseVisualStyleBackColor = true;
            // 
            // radioButton_16
            // 
            this.radioButton_16.AutoSize = true;
            this.radioButton_16.Location = new System.Drawing.Point(26, 61);
            this.radioButton_16.Name = "radioButton_16";
            this.radioButton_16.Size = new System.Drawing.Size(37, 17);
            this.radioButton_16.TabIndex = 1;
            this.radioButton_16.Text = "16";
            this.radioButton_16.UseVisualStyleBackColor = true;
            // 
            // radioButton_32
            // 
            this.radioButton_32.AutoSize = true;
            this.radioButton_32.Location = new System.Drawing.Point(26, 85);
            this.radioButton_32.Name = "radioButton_32";
            this.radioButton_32.Size = new System.Drawing.Size(37, 17);
            this.radioButton_32.TabIndex = 0;
            this.radioButton_32.TabStop = true;
            this.radioButton_32.Text = "32";
            this.radioButton_32.UseVisualStyleBackColor = true;
            // 
            // colorParamsBox
            // 
            this.colorParamsBox.Controls.Add(this.label_R_percentage);
            this.colorParamsBox.Controls.Add(this.parameter_R_percentage);
            this.colorParamsBox.Controls.Add(this.parameter_B_percentage);
            this.colorParamsBox.Controls.Add(this.reset);
            this.colorParamsBox.Controls.Add(this.label_B_percentage);
            this.colorParamsBox.Controls.Add(this.label_parameter_G);
            this.colorParamsBox.Controls.Add(this.parameter_G_percentage);
            this.colorParamsBox.Location = new System.Drawing.Point(397, 55);
            this.colorParamsBox.Name = "colorParamsBox";
            this.colorParamsBox.Size = new System.Drawing.Size(84, 185);
            this.colorParamsBox.TabIndex = 16;
            this.colorParamsBox.TabStop = false;
            this.colorParamsBox.Text = "color rate";
            // 
            // oldImage1
            // 
            this.oldImage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.oldImage1.Location = new System.Drawing.Point(629, 330);
            this.oldImage1.Name = "oldImage1";
            this.oldImage1.Size = new System.Drawing.Size(170, 170);
            this.oldImage1.TabIndex = 17;
            this.oldImage1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(813, 330);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 170);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // resultParamsBox
            // 
            this.resultParamsBox.Controls.Add(this.g_psnr_delta);
            this.resultParamsBox.Controls.Add(this.b_psnr_delta);
            this.resultParamsBox.Controls.Add(this.r_psnr_delta);
            this.resultParamsBox.Controls.Add(this.g_mse_delta);
            this.resultParamsBox.Controls.Add(this.b_mse_delta);
            this.resultParamsBox.Controls.Add(this.r_mse_delta);
            this.resultParamsBox.Controls.Add(this.g_psnr_value);
            this.resultParamsBox.Controls.Add(this.b_psnr_value);
            this.resultParamsBox.Controls.Add(this.r_psnr_value);
            this.resultParamsBox.Controls.Add(this.psnr_param_label);
            this.resultParamsBox.Controls.Add(this.mse_param_label);
            this.resultParamsBox.Controls.Add(this.g_param_label);
            this.resultParamsBox.Controls.Add(this.g_mse_value);
            this.resultParamsBox.Controls.Add(this.b_param_label);
            this.resultParamsBox.Controls.Add(this.b_mse_value);
            this.resultParamsBox.Controls.Add(this.r_param_label);
            this.resultParamsBox.Controls.Add(this.r_mse_value);
            this.resultParamsBox.Location = new System.Drawing.Point(397, 330);
            this.resultParamsBox.Name = "resultParamsBox";
            this.resultParamsBox.Size = new System.Drawing.Size(200, 170);
            this.resultParamsBox.TabIndex = 19;
            this.resultParamsBox.TabStop = false;
            this.resultParamsBox.Text = "result parameters";
            // 
            // g_psnr_delta
            // 
            this.g_psnr_delta.AutoSize = true;
            this.g_psnr_delta.Location = new System.Drawing.Point(145, 150);
            this.g_psnr_delta.Name = "g_psnr_delta";
            this.g_psnr_delta.Size = new System.Drawing.Size(35, 13);
            this.g_psnr_delta.TabIndex = 23;
            this.g_psnr_delta.Text = "label6";
            // 
            // b_psnr_delta
            // 
            this.b_psnr_delta.AutoSize = true;
            this.b_psnr_delta.Location = new System.Drawing.Point(145, 108);
            this.b_psnr_delta.Name = "b_psnr_delta";
            this.b_psnr_delta.Size = new System.Drawing.Size(35, 13);
            this.b_psnr_delta.TabIndex = 22;
            this.b_psnr_delta.Text = "label5";
            // 
            // r_psnr_delta
            // 
            this.r_psnr_delta.AutoSize = true;
            this.r_psnr_delta.Location = new System.Drawing.Point(145, 59);
            this.r_psnr_delta.Name = "r_psnr_delta";
            this.r_psnr_delta.Size = new System.Drawing.Size(35, 13);
            this.r_psnr_delta.TabIndex = 21;
            this.r_psnr_delta.Text = "label4";
            // 
            // g_mse_delta
            // 
            this.g_mse_delta.AutoSize = true;
            this.g_mse_delta.Location = new System.Drawing.Point(67, 150);
            this.g_mse_delta.Name = "g_mse_delta";
            this.g_mse_delta.Size = new System.Drawing.Size(35, 13);
            this.g_mse_delta.TabIndex = 20;
            this.g_mse_delta.Text = "label3";
            // 
            // b_mse_delta
            // 
            this.b_mse_delta.AutoSize = true;
            this.b_mse_delta.Location = new System.Drawing.Point(67, 105);
            this.b_mse_delta.Name = "b_mse_delta";
            this.b_mse_delta.Size = new System.Drawing.Size(35, 13);
            this.b_mse_delta.TabIndex = 19;
            this.b_mse_delta.Text = "label2";
            // 
            // r_mse_delta
            // 
            this.r_mse_delta.AutoSize = true;
            this.r_mse_delta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.r_mse_delta.Location = new System.Drawing.Point(67, 58);
            this.r_mse_delta.Name = "r_mse_delta";
            this.r_mse_delta.Size = new System.Drawing.Size(35, 13);
            this.r_mse_delta.TabIndex = 18;
            this.r_mse_delta.Text = "label1";
            // 
            // g_psnr_value
            // 
            this.g_psnr_value.Location = new System.Drawing.Point(133, 127);
            this.g_psnr_value.Name = "g_psnr_value";
            this.g_psnr_value.ReadOnly = true;
            this.g_psnr_value.Size = new System.Drawing.Size(59, 20);
            this.g_psnr_value.TabIndex = 17;
            this.g_psnr_value.Tag = "";
            // 
            // b_psnr_value
            // 
            this.b_psnr_value.Location = new System.Drawing.Point(133, 85);
            this.b_psnr_value.Name = "b_psnr_value";
            this.b_psnr_value.ReadOnly = true;
            this.b_psnr_value.Size = new System.Drawing.Size(60, 20);
            this.b_psnr_value.TabIndex = 16;
            this.b_psnr_value.Tag = "";
            // 
            // r_psnr_value
            // 
            this.r_psnr_value.Location = new System.Drawing.Point(132, 38);
            this.r_psnr_value.Name = "r_psnr_value";
            this.r_psnr_value.ReadOnly = true;
            this.r_psnr_value.Size = new System.Drawing.Size(60, 20);
            this.r_psnr_value.TabIndex = 15;
            this.r_psnr_value.Tag = "";
            // 
            // psnr_param_label
            // 
            this.psnr_param_label.AutoSize = true;
            this.psnr_param_label.Location = new System.Drawing.Point(146, 16);
            this.psnr_param_label.Name = "psnr_param_label";
            this.psnr_param_label.Size = new System.Drawing.Size(37, 13);
            this.psnr_param_label.TabIndex = 14;
            this.psnr_param_label.Text = "PSNR";
            // 
            // mse_param_label
            // 
            this.mse_param_label.AutoSize = true;
            this.mse_param_label.Location = new System.Drawing.Point(68, 16);
            this.mse_param_label.Name = "mse_param_label";
            this.mse_param_label.Size = new System.Drawing.Size(30, 13);
            this.mse_param_label.TabIndex = 13;
            this.mse_param_label.Text = "MSE";
            // 
            // g_param_label
            // 
            this.g_param_label.AutoSize = true;
            this.g_param_label.Location = new System.Drawing.Point(16, 127);
            this.g_param_label.Name = "g_param_label";
            this.g_param_label.Size = new System.Drawing.Size(18, 13);
            this.g_param_label.TabIndex = 12;
            this.g_param_label.Text = "G ";
            // 
            // g_mse_value
            // 
            this.g_mse_value.Location = new System.Drawing.Point(58, 127);
            this.g_mse_value.Name = "g_mse_value";
            this.g_mse_value.ReadOnly = true;
            this.g_mse_value.Size = new System.Drawing.Size(60, 20);
            this.g_mse_value.TabIndex = 11;
            this.g_mse_value.Tag = "";
            // 
            // b_param_label
            // 
            this.b_param_label.AutoSize = true;
            this.b_param_label.Location = new System.Drawing.Point(16, 84);
            this.b_param_label.Name = "b_param_label";
            this.b_param_label.Size = new System.Drawing.Size(17, 13);
            this.b_param_label.TabIndex = 10;
            this.b_param_label.Text = "B ";
            // 
            // b_mse_value
            // 
            this.b_mse_value.Location = new System.Drawing.Point(58, 84);
            this.b_mse_value.Name = "b_mse_value";
            this.b_mse_value.ReadOnly = true;
            this.b_mse_value.Size = new System.Drawing.Size(60, 20);
            this.b_mse_value.TabIndex = 9;
            this.b_mse_value.Tag = "";
            // 
            // r_param_label
            // 
            this.r_param_label.AutoSize = true;
            this.r_param_label.Location = new System.Drawing.Point(16, 38);
            this.r_param_label.Name = "r_param_label";
            this.r_param_label.Size = new System.Drawing.Size(18, 13);
            this.r_param_label.TabIndex = 8;
            this.r_param_label.Text = "R ";
            // 
            // r_mse_value
            // 
            this.r_mse_value.Location = new System.Drawing.Point(58, 38);
            this.r_mse_value.Name = "r_mse_value";
            this.r_mse_value.ReadOnly = true;
            this.r_mse_value.Size = new System.Drawing.Size(60, 20);
            this.r_mse_value.TabIndex = 7;
            this.r_mse_value.Tag = "";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 520);
            this.Controls.Add(this.resultParamsBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.oldImage1);
            this.Controls.Add(this.colorParamsBox);
            this.Controls.Add(this.sizeElementBox);
            this.Controls.Add(this.selectedMethodBox);
            this.Controls.Add(this.sourceImage);
            this.Controls.Add(this.getResultImage);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.selectImage);
            this.Controls.Add(this.resultImage);
            this.Name = "View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
            this.sizeElementBox.ResumeLayout(false);
            this.sizeElementBox.PerformLayout();
            this.colorParamsBox.ResumeLayout(false);
            this.colorParamsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.resultParamsBox.ResumeLayout(false);
            this.resultParamsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourceImage;
        private System.Windows.Forms.PictureBox resultImage;

        private System.Windows.Forms.Button selectImage;
        private System.Windows.Forms.Button getResultImage;

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.TextBox parameter_R_percentage;
        private System.Windows.Forms.Label label_R_percentage;
        private System.Windows.Forms.Label label_B_percentage;
        private System.Windows.Forms.TextBox parameter_B_percentage;
        private System.Windows.Forms.Label label_parameter_G;
        private System.Windows.Forms.TextBox parameter_G_percentage;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.ComboBox selectedMethodBox;
        private System.Windows.Forms.GroupBox sizeElementBox;
        private System.Windows.Forms.RadioButton radioButton_8;
        private System.Windows.Forms.RadioButton radioButton_16;
        private System.Windows.Forms.RadioButton radioButton_32;
        private System.Windows.Forms.GroupBox colorParamsBox;
        private System.Windows.Forms.PictureBox oldImage1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox resultParamsBox;
        private System.Windows.Forms.Label mse_param_label;
        private System.Windows.Forms.Label g_param_label;
        private System.Windows.Forms.TextBox g_mse_value;
        private System.Windows.Forms.Label b_param_label;
        private System.Windows.Forms.TextBox b_mse_value;
        private System.Windows.Forms.Label r_param_label;
        private System.Windows.Forms.TextBox r_mse_value;
        private System.Windows.Forms.TextBox g_psnr_value;
        private System.Windows.Forms.TextBox b_psnr_value;
        private System.Windows.Forms.TextBox r_psnr_value;
        private System.Windows.Forms.Label psnr_param_label;
        private System.Windows.Forms.Label g_psnr_delta;
        private System.Windows.Forms.Label b_psnr_delta;
        private System.Windows.Forms.Label r_psnr_delta;
        private System.Windows.Forms.Label g_mse_delta;
        private System.Windows.Forms.Label b_mse_delta;
        private System.Windows.Forms.Label r_mse_delta;
    }
}