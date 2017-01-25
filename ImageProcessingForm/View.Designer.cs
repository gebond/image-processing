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
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
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
            this.selectImage.Location = new System.Drawing.Point(105, 330);
            this.selectImage.Name = "selectImage";
            this.selectImage.Size = new System.Drawing.Size(125, 23);
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
            this.errorMessage.Location = new System.Drawing.Point(739, 360);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 13);
            this.errorMessage.TabIndex = 3;
            this.errorMessage.Click += new System.EventHandler(this.errorLabel_Click);
            // 
            // getResultImage
            // 
            this.getResultImage.Location = new System.Drawing.Point(756, 330);
            this.getResultImage.Name = "getResultImage";
            this.getResultImage.Size = new System.Drawing.Size(124, 23);
            this.getResultImage.TabIndex = 4;
            this.getResultImage.Text = "Get result image";
            this.getResultImage.UseVisualStyleBackColor = true;
            this.getResultImage.Click += new System.EventHandler(this.getResultImage_Click);
            // 
            // parameter_R_percentage
            // 
            this.parameter_R_percentage.Location = new System.Drawing.Point(457, 71);
            this.parameter_R_percentage.Name = "parameter_R_percentage";
            this.parameter_R_percentage.Size = new System.Drawing.Size(32, 20);
            this.parameter_R_percentage.TabIndex = 5;
            this.parameter_R_percentage.Tag = "";
            this.parameter_R_percentage.Text = "100";
            this.parameter_R_percentage.TextChanged += new System.EventHandler(this.parameter_R_percentage_TextChanged);
            // 
            // label_R_percentage
            // 
            this.label_R_percentage.AutoSize = true;
            this.label_R_percentage.Location = new System.Drawing.Point(425, 74);
            this.label_R_percentage.Name = "label_R_percentage";
            this.label_R_percentage.Size = new System.Drawing.Size(26, 13);
            this.label_R_percentage.TabIndex = 6;
            this.label_R_percentage.Text = "R %";
            // 
            // label_B_percentage
            // 
            this.label_B_percentage.AutoSize = true;
            this.label_B_percentage.Location = new System.Drawing.Point(427, 122);
            this.label_B_percentage.Name = "label_B_percentage";
            this.label_B_percentage.Size = new System.Drawing.Size(25, 13);
            this.label_B_percentage.TabIndex = 8;
            this.label_B_percentage.Text = "B %";
            // 
            // parameter_B_percentage
            // 
            this.parameter_B_percentage.Location = new System.Drawing.Point(457, 119);
            this.parameter_B_percentage.Name = "parameter_B_percentage";
            this.parameter_B_percentage.Size = new System.Drawing.Size(32, 20);
            this.parameter_B_percentage.TabIndex = 7;
            this.parameter_B_percentage.Text = "100";
            this.parameter_B_percentage.TextChanged += new System.EventHandler(this.parameter_B_percentage_TextChanged);
            // 
            // label_parameter_G
            // 
            this.label_parameter_G.AutoSize = true;
            this.label_parameter_G.Location = new System.Drawing.Point(426, 170);
            this.label_parameter_G.Name = "label_parameter_G";
            this.label_parameter_G.Size = new System.Drawing.Size(26, 13);
            this.label_parameter_G.TabIndex = 10;
            this.label_parameter_G.Text = "G %";
            // 
            // parameter_G_percentage
            // 
            this.parameter_G_percentage.Location = new System.Drawing.Point(457, 167);
            this.parameter_G_percentage.Name = "parameter_G_percentage";
            this.parameter_G_percentage.Size = new System.Drawing.Size(32, 20);
            this.parameter_G_percentage.TabIndex = 9;
            this.parameter_G_percentage.Text = "100";
            this.parameter_G_percentage.TextChanged += new System.EventHandler(this.parameter_G_percentage_TextChanged);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(428, 205);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(61, 23);
            this.reset.TabIndex = 11;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.reset_MouseClick);
            // 
            // selectedMethodBox
            // 
            this.selectedMethodBox.FormattingEnabled = true;
            this.selectedMethodBox.Items.AddRange(new object[] {
            "transformation by Matrix",
            "transformation by Walsh",
            "transformation by Haart"});
            this.selectedMethodBox.Location = new System.Drawing.Point(428, 251);
            this.selectedMethodBox.Name = "selectedMethodBox";
            this.selectedMethodBox.Size = new System.Drawing.Size(148, 21);
            this.selectedMethodBox.TabIndex = 13;
            this.selectedMethodBox.Text = "select method";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 372);
            this.Controls.Add(this.selectedMethodBox);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.label_parameter_G);
            this.Controls.Add(this.parameter_G_percentage);
            this.Controls.Add(this.label_B_percentage);
            this.Controls.Add(this.parameter_B_percentage);
            this.Controls.Add(this.sourceImage);
            this.Controls.Add(this.label_R_percentage);
            this.Controls.Add(this.parameter_R_percentage);
            this.Controls.Add(this.getResultImage);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.selectImage);
            this.Controls.Add(this.resultImage);
            this.Name = "View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
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
    }
}

