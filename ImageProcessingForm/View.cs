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
        public event EventHandler imageSelected;

        #endregion

        private void button1_Click(object sender, EventArgs e) {

        }
    }
}
