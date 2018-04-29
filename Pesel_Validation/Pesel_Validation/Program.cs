using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesel_Validation {
    class Program {
        static void Main(string[] args)
        {
            // Making a list
            Console.WriteLine("edycja");
            
            List<DataForValidation> peselList = new List<DataForValidation>();

            //Adding object to the list, randomly generated pesel 
            
            peselList.Add(new Pesel("92071314764"));

            //creating an object for 
            
            PeselValidation validator = new PeselValidation();

            
            try
            {
                Console.WriteLine("Everything went well, Daddy is pleased, bool value is: " + validator.validateValues(peselList));
            }
            catch (ValidationException e)
            {
                Console.WriteLine("Something's wrong, here's the exception messege: " + e.GetMessege());
            }

            Console.ReadKey();
        }
    }
}
