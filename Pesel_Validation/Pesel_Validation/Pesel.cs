using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesel_Validation  {
    class Pesel : DataForValidation {
        private string pesel;

        public Pesel(String pesel) { this.pesel = pesel;}

        //returning the value from the list

        public string getDataForValidation()
        {
            return pesel;
        }
        
    }
}
