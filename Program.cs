using System;

namespace Lis
{
    public class ConvertNumberToWords
    {


        #region Ones Constants
        private static readonly string[] One = {"", "one ", "two ", "three ", "four ",
            "five ", "six ", "seven ", "eight ",
            "nine ", "ten ", "eleven ", "twelve ",
            "thirteen ", "fourteen ", "fifteen ",
            "sixteen ", "seventeen ", "eighteen ",
            "nineteen "};
        #endregion

        #region Tens Constants
        private static readonly string[] Ten = {"", "", "twenty ", "thirty ", "forty ",
            "fifty ", "sixty ", "seventy ", "eighty ",
            "ninety "};
        #endregion

        #region Convert number upto 2 digits
        static string NumToWords(int number, string wordAfterNumber)
        {
            string str = "";

            if (number > 19)
            {
                str += Ten[number / 10] + One[number % 10];
            }
            else
            {
                str += One[number];
            }

            if (number != 0)
            {
                str += wordAfterNumber;
            }

            return str;
        }
        #endregion

        #region Convert Number more that 2 digits
        static string ConvertToWords(long n)
        {

            string out1 = "";

            out1 += NumToWords((int)(n / 10000000),
                "crore ");

            out1 += NumToWords((int)((n / 100000) % 100),
                "lakh ");

            out1 += NumToWords((int)((n / 1000) % 100),
                "thousand ");

            out1 += NumToWords((int)((n / 100) % 10),
                "hundred ");

            if (n > 100 && n % 100 > 0)
            {
                out1 += "and ";
            }

            out1 += NumToWords((int)(n % 100), "");

            return out1;
        }
        #endregion

        #region Main
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter a number to convert it into words...");
                Int64 input = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine(ConvertToWords(input));
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty((ex.Message)))
                {
                    Console.WriteLine("Number is out of range.");
                }
            }
        }
        #endregion


    }
}

