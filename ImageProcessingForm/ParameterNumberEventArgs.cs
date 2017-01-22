using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingForm {
    public class ParameterNumberEventArgs : NumberEventArgs {
        private string parameter;
        public ParameterNumberEventArgs(double number, string parameter_as_str) : base(number){
            parameter = parameter_as_str;
        }
        
        public string Parameter {
            get { return parameter; }
        }
    }
}
