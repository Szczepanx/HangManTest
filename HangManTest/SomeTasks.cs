using System;
namespace HangManTest
{
    public class SomeTasks
    {
        public static int PoleFgury(int a, int b)
        {
            return a * b;
        }

        public static int KonwersjaTypu(float a)
        {
            return (int)a;
        }

        public static string OdwrocenieTekstu(string str)
        {
            string reversed = "";
            char[] chars = str.ToCharArray();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                reversed = reversed + chars[i];
            }
            //Console.WriteLine(string.Join(" ", words.Split(' ').Where(x => !String.IsNullOrEmpty(x)).Reverse()));
            return reversed;
        }

        public static void WystapieniaCyfry(int a, int b)
        {


            int count = 0;
            char[] numbers = a.ToString().ToArray();

            foreach (int w in numbers)
            {
                if ((w - '0') == b) { count++; }

            }
            Console.WriteLine(count);

        }


        public static int CiagFibonnaciego(int a)
        {
            List<int> firstNumbers = new List<int>() { 1, 1 };

            while (firstNumbers.Count < a)
            {
                firstNumbers.Add(firstNumbers[firstNumbers.Count - 2] + firstNumbers[firstNumbers.Count - 1]);
            }

            return firstNumbers[firstNumbers.Count - 1];
        }


        public static void FizzBuzz()
        {
            Enumerable.Range(1, 100).Select(x =>
            {
                var str = "";
                if (x % 3 == 0)
                {
                    str += "Fizz";
                }
                if (x % 5 == 0)
                {
                    str += "Buzz";
                }
                if (str == "")
                {
                    str = x.ToString();
                }
                return str;
            }).ToList().ForEach(Console.WriteLine);
        }
        public static void checkPalindrome(string str)
        {
            bool check = false;
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                if (str[i] != str[j])
                {
                    check = false;
                    break;
                }
                else
                    check = true;
            }
            if (check)
            {
                Console.WriteLine("Palindrome");
            }
            else
                Console.WriteLine("Not Palindrome");
        }
    }
}

