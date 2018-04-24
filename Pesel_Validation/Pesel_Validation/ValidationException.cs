using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesel_Validation {
    class ValidationException : Exception {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public String GetMessege()
        {
            return base.Message;
        }
    }
}
