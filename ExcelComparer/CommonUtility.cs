using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelComparer_Unmatch
{
     static class CommonUtility
    {
        public static string getcolumnname(long columnNumber)
        {

            StringBuilder retVal = new StringBuilder();
            int x = 0;
            try
            {
                for (int n = (int)(Math.Log(25 * (columnNumber + 1)) / Math.Log(26)) - 1; n >= 0; n--)
                {
                    x = (int)((Math.Pow(26, (n + 1)) - 1) / 25 - 1);
                    if (columnNumber > x)
                        retVal.Append(System.Convert.ToChar((int)(((columnNumber - x - 1) / Math.Pow(26, n)) % 26 + 65)));
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal.ToString();

        }

        public static int GetColumnNumber(string name)
        {
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }

            return number;
        }
    }
}
