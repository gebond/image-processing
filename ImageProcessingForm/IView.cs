using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingForm {
    public interface IView {
        event EventHandler<> imageSelected;

    }
}
