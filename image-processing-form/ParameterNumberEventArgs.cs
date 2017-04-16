using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingForm {
    public class ColorParameterNumberEventArgs : NumberEventArgs {
        private string parameter;
        private string color;
        public ColorParameterNumberEventArgs(double number, string color_str, string parameter_str) : base(number){
            parameter = parameter_str;
            color = color_str;
        }
        
        public string Parameter {
            get { return parameter; }
        }
        public string Color {
            get { return color; }
        }
    }
}
