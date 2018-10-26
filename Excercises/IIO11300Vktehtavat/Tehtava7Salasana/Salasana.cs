using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace JAMK.IT.IIO11300
{
    class Salasana
    {
        static public int lowercase { get; set; }
        static private int lowercaseFound { get; set; }
        static public int uppercase { get; set; }
        static private int uppercaseFound { get; set; }
        static public int special { get; set; }
        static private int specialFound { get; set; }
        static public int numbers { get; set; }
        static private int numbersFound { get; set; }
        static public int symbolCount { get; set; }


        static public int AnalyzePassword(string input)
        {
            try
            {
                char[] password = input.ToCharArray();
                uppercaseFound = 0;
                lowercaseFound = 0;
                specialFound = 0;
                numbersFound = 0;
                lowercase = 0;
                uppercase = 0;
                special = 0;
                numbers = 0;

                for (int i = 0; i < password.Length; i++)
                {
                    if (Regex.IsMatch(password[i].ToString(), "[a-z]"))
                    {
                        lowercase++;
                        lowercaseFound = 1;
                    }
                    else if (Regex.IsMatch(password[i].ToString(), "[A-Z]"))
                    {
                        uppercase++;
                        uppercaseFound = 1;
                    }
                    else if (Regex.IsMatch(password[i].ToString(), "[0-9]"))
                    {
                        numbers++;
                        numbersFound = 1;
                    }
                    else
                    {
                        special++;
                        specialFound = 1;
                    }

                }

               // MessageBox.Show("Numbers: " + numbers + ", lowercase: " + lowercase + ", uppercase: " + uppercase + ", special: " + special + ", symbolcount: " + input.Length);

                symbolCount = input.Length;

              // MessageBox.Show((lowercaseFound+uppercaseFound +specialFound+numbersFound).ToString());

                if((lowercaseFound + uppercaseFound + specialFound + numbersFound) == 4 && symbolCount >= 16)
                {
                    return 4;
                }

                else if ((lowercaseFound + uppercaseFound + specialFound + numbersFound) == 3 && symbolCount < 16)
                {
                    return 3;
                }

                else if ((lowercaseFound + uppercaseFound + specialFound + numbersFound) == 2 && symbolCount < 12)
                {
                    return 2;
                }
                else if ((lowercaseFound + uppercaseFound + specialFound + numbersFound) == 1 || symbolCount < 8 && symbolCount != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
