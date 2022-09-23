using System.Diagnostics;

namespace HangManTest
{
    class Program
    {
        private static async Task saveScores(string txt)
        {
            using StreamWriter file = new("/Users/szczepangizicki/Documents/Projects/HangManTest/HangManTest/Scores.txt", append: true);
            await file.WriteLineAsync(txt);
        }


        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            //Console.Write("\r\n");
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Welcome to hangman :)");
            Console.WriteLine("-----------------------------------------");

            Random random = new Random();
            List<string> lines = System.IO.File.ReadLines("/Users/szczepangizicki/Documents/Projects/HangManTest/HangManTest/dane_wisielec.csv").ToList();
            lines.RemoveAt(0);
            int index = random.Next(lines.Count);
            String randomWord = lines[index].ToLower();
            

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> letterGuessedNow = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in letterGuessedNow)
                {
                    Console.Write(letter + " ");
                }
                
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                if (letterGuessedNow.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(letterGuessedNow, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        letterGuessedNow.Add(letterGuessed);
                        currentLettersRight = printWord(letterGuessedNow, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong += 1;
                        letterGuessedNow.Add(letterGuessed);
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(letterGuessedNow, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }

            if (amountOfTimesWrong != 6)
            {
                Console.WriteLine("\r\nYou Win! Thank you for playing :)");
                stopwatch.Stop();
                string stopwachTime = stopwatch.Elapsed.ToString();

                string toTxtFile = $"\nWord you gessed : {randomWord}\nNumber of your guesses : {letterGuessedNow.Count} \nNumber of wrong guesses : {amountOfTimesWrong}\nTime of your game : {stopwachTime}";

                saveScores(toTxtFile);
            }
            else
            {
                Console.Write($"\rYou Lost! Try aganin next time! :D\nYour word was : {randomWord}");
            }
            
            
           
            Console.ReadLine();
        }
    }
}