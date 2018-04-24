using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesel_Validation {
    interface Validator {
        bool validateValues(List<DataForValidation> datalist);
    }
}
