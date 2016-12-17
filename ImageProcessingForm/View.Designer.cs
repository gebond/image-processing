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
            this.resultImage.Location = new System.Drawing.Point(719, 12);
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
            this.errorMessage.Location = new System.Drawing.Point(843, 400);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 13);
            this.errorMessage.TabIndex = 3;
            this.errorMessage.Click += new System.EventHandler(this.errorLabel_Click);
            // 
            // getResultImage
            // 
            this.getResultImage.Location = new System.Drawing.Point(846, 330);
            this.getResultImage.Name = "getResultImage";
            this.getResultImage.Size = new System.Drawing.Size(124, 23);
            this.getResultImage.TabIndex = 4;
            this.getResultImage.Text = "Get result image";
            this.getResultImage.UseVisualStyleBackColor = true;
            this.getResultImage.Click += new System.EventHandler(this.getResultImage_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 443);
            this.Controls.Add(this.getResultImage);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.selectImage);
            this.Controls.Add(this.resultImage);
            this.Controls.Add(this.sourceImage);
            this.Name = "View";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.View_Load);
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
    }
}

