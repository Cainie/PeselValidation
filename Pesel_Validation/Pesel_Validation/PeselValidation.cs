using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesel_Validation {
    class PeselValidation : Validator {

        //extracted from peselToIntArray
        private int[] peselInIntArray;

        //extracted from birthDate function
        private int year, month, day;

        public bool validateValues(List<DataForValidation> datalist)
        {
            foreach (DataForValidation aDataList in datalist)
            {
                if (!peselToIntArray(aDataList.getDataForValidation()))
                {
                    throw new ValidationException("Pesel made not in numbers only");
                }
                else if (!isThereEnoughNumbers(peselInIntArray))
                {
                    throw new ValidationException("Pesel too short or too long to be a Pesel");
                }
                else if (!isControlNumberCorrect(peselInIntArray))
                {
                    throw new ValidationException("Control number incorrect");
                }
                else
                {
                    birthDate(peselInIntArray);
                    if (!isMonthCorrect())
                    {
                        throw new ValidationException("Month in Pesel not correct");
                    }
                    else if (!isDayCorrect())
                    {
                        throw new ValidationException("Day in Pesel not correct");
                    }
                }
            }
            return true;
        }


        //checks if there are only numbers in pesel
        private bool peselToIntArray (String pesel)
        {
            peselInIntArray = new int[pesel.Length];
            try
            {
                for (int i = 0; i < pesel.Length; i++)
                {
                    peselInIntArray[i] = Int32.Parse(Convert.ToString(pesel[i]));
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        //checks the lenght of pesel
        private bool isThereEnoughNumbers(int[] pesel)
        {
            return pesel.Length == 11;
        }

        //checks the control number
        private bool isControlNumberCorrect(int[] pesel)
        {
            int[] wagi = new int[] { 9, 7, 3, 1, 9, 7, 3, 1, 9, 7 };
            int sum = 0;
            for (int i = 0; i < pesel.Length - 1; i++)
            {
                sum += (pesel[i] * wagi[i]);

            }
            int controlNum = sum % 10;
            return controlNum == pesel[pesel.Length - 1];
        }

        //checks the month
        private bool isMonthCorrect()
        {
            return month > 0 && month < 13;
        }

        //checks the day
        private bool isDayCorrect()
        {
            return (day > 0 && day < 32) && (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) || (day > 0 && day < 31) && (month == 4 || month == 6 || month == 9 || month == 11) || (day > 0 && day < 30 && leapYear(year)) || (day > 0 && day < 29 && !leapYear(year));
        }

        //birth day extract
        private void birthDate(int[] pesel)
        {
            //year
            year = 10 * pesel[0];
            year += pesel[1];
            month = 10 * pesel[2];
            month += pesel[3];
            if (month > 80 && month < 93)
            {
                year += 1800;
            }
            else if (month > 0 && month < 13)
            {
                year += 1900;
            }
            else if (month > 20 && month < 33)
            {
                year += 2000;
            }
            else if (month > 40 && month < 53)
            {
                year += 2100;
            }
            else if (month > 60 && month < 73)
            {
                year += 2200;
            }
            //month
            if (month > 80 && month < 93)
            {
                month -= 80;
            }
            else if (month > 20 && month < 33)
            {
                month -= 20;
            }
            else if (month > 40 && month < 53)
            {
                month -= 40;
            }
            else if (month > 60 && month < 73)
            {
                month -= 60;
            }
            //day
            day = 10 * pesel[4];
            day += pesel[5];
        }

        //leap year check
        private bool leapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
    }
}
