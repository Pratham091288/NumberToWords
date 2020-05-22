using System;

namespace Lis
{

    public static class OnesTensConstants
    {

        public static string[] One = {"", "one ", "two ", "three ", "four ",
            "five ", "six ", "seven ", "eight ",
            "nine ", "ten ", "eleven ", "twelve ",
            "thirteen ", "fourteen ", "fifteen ",
            "sixteen ", "seventeen ", "eighteen ",
            "nineteen "};


        public static string[] Ten = {"", "", "twenty ", "thirty ", "forty ",
            "fifty ", "sixty ", "seventy ", "eighty ",
            "ninety "};

    }
    public interface ITwoDigit
    {
        public string NumToWords(int number, string wordAfterNumber);
    }

    public interface INumberConverter
    {
        public string ConvertToWords(long number);
    }

    public class TwoDigit:ITwoDigit
    {
        string ITwoDigit.NumToWords(int number, string wordAfterNumber)
        {
            string str = "";

            if (number > 19)
            {
                str += OnesTensConstants.Ten[number / 10] + OnesTensConstants.One[number % 10];
            }
            else
            {
                str += OnesTensConstants.One[number];
            }

            if (number != 0)
            {
                str += wordAfterNumber;
            }

            return str;
        }
    }
    public class ConvertNumberToWords : INumberConverter
    {
        ITwoDigit _twoDigit = new TwoDigit();

        string INumberConverter.ConvertToWords(long n)
        {

            string out1 = "";

            out1 += _twoDigit.NumToWords((int)(n / 10000000), "crore ");

            out1 += _twoDigit.NumToWords((int)((n / 100000) % 100), "lakh ");

            out1 += _twoDigit.NumToWords((int)((n / 1000) % 100), "thousand ");

            out1 += _twoDigit.NumToWords((int)((n / 100) % 10), "hundred ");

            if (n > 100 && n % 100 > 0)
            {
                out1 += "and ";
            }

            out1 += _twoDigit.NumToWords((int)(n % 100), "");

            return out1;
        }

        public static void Main()
        {
            try
            {
                INumberConverter numberConverter = new ConvertNumberToWords();
                Console.WriteLine("Enter a number to convert it into words...");
                Int64 input = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine(numberConverter.ConvertToWords(input));
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty((ex.Message)))
                {
                    Console.WriteLine("Number is out of range.");
                }
            }
        }
    }
}

