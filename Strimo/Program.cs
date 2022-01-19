using System;

namespace Strimo
{
    class Program
    {
        private readonly static string[] m = { "", "M", "MM", "MMM" };
        private readonly static string[] c = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCC", "CM" };
        private readonly static string[] x = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private readonly static string[] i = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        static void Main(string[] args)
        {
            int[] testValues = { 1, 9, 19, 199, 234, 456, 1800, 1934, 1999, 3000, 3104, 3999 };

            foreach(var i in testValues)
            {
                Console.WriteLine($"{i} in Roman numerals is {ConvertToRoman(i)}");
            }
        }

        static string ConvertToRoman(int n)
        {
            string retVal;

            if (n == 0)
            {
                retVal = "Nullus";
            }
            else if (n >= 4000 || n < 0)
            {
                retVal = "Please enter an integer less than or equal to 3999";
            }
            else
            {
                var thousands = m[GetPlace(n, 1000)];
                var hundereds = c[GetPlace(n, 100)];
                var tens = x[GetPlace(n, 10)];
                var ones = i[GetPlace(n, 1)];

                retVal = string.Concat(thousands, hundereds, tens, ones);
            }

            return retVal;
        }

        /* Method based on logic found here: 
         * https://stackoverflow.com/questions/48556743/how-to-get-number-of-hundreds-and-tens-from-a-total-value-in-c
         */
        static int GetPlace(int value, int place)
        {
            return (place <= 0 || value <= 0) ? 0 : ((value % (place * 10)) - (value % place)) / place;
        }
    }
}
