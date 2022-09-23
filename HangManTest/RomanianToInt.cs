using System;
namespace HangManTest
{
    public class RomanianToInt
    {
        public static int Roman(string s)
        {
            var dictionary = new Dictionary<char, int>();
            dictionary.Add('I', 1);
            dictionary.Add('V', 5);
            dictionary.Add('X', 10);
            dictionary.Add('L', 50);
            dictionary.Add('C', 100);
            dictionary.Add('D', 500);
            dictionary.Add('M', 1000);

            int solution = 0;

            s = s.Replace("IV", "IIII")
                .Replace("IX", "VIIII")
                .Replace("XL", "XXXX")
                .Replace("XC", "LXXXX")
                .Replace("CD", "CCCC")
                .Replace("CM", "DCCCC");

            foreach (char c in s)
            {
                solution += dictionary[c];
            }

            return solution;
        }
    }
}

