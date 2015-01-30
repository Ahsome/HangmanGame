using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Solution
    {
        static int hangmanGraphicsID;
        static char[] alphabetCharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static char[] lettersGuessed;
        static char[] guessedCharArray;
        static void Main()
        {
            hangmanGraphicsID = -1;
            Console.Clear();
            OutputGraphics(10);
            Console.WriteLine();
            Console.WriteLine("Type a word that you would like to guess in this game");
            string stringToGuess = Console.ReadLine().ToUpper().Replace(" ", "");
            Console.Clear();

            foreach (char letter in stringToGuess)
            {
                if (Char.IsNumber(letter))
                {
                    PrintError("The word you provided included a number/s, which is not supported");
                }
            }

            OutputGraphics(10);
            Console.WriteLine("Type a letter, and see if you can guess my word. Good Luck");
            char guessedChar = Char.ToUpper(Console.ReadKey().KeyChar);

            guessedCharArray = new char[stringToGuess.Length];
            lettersGuessed = new char[] { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', };

            Console.Clear();
            SolveHangman(guessedChar, stringToGuess, guessedCharArray);
        }
        static void SolveHangman(char guessedChar, string stringToGuess, char[] guessedCharArray)
        {
            Console.Clear();
            bool isGuessEdited = false;

            for (int i = 0; i < stringToGuess.Length; i++)
            {
                if (guessedChar == stringToGuess[i])
                {
                    guessedCharArray[i] = guessedChar;
                    isGuessEdited = true;
                }
            }

            if (stringToGuess == new string(guessedCharArray))
            {
                EndResult(stringToGuess, "won", guessedCharArray);
            }
            else if (hangmanGraphicsID == 9)
            {
                EndResult(stringToGuess, "lost", guessedCharArray);
            }

            if (!isGuessEdited)
            {
                hangmanGraphicsID++;
            }

            for (int i = 0; i < alphabetCharArray.Length; i++)
            {
                if (alphabetCharArray[i] == guessedChar)
                {
                    lettersGuessed[i] = guessedChar;
                }
            }

            OutputGraphics(hangmanGraphicsID);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            foreach (char element in guessedCharArray)
            {
                Console.Write("  {0}  ", element);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            foreach (char element in lettersGuessed)
            {
                Console.Write("  {0}  ", element);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type a letter, and see if you can guess my word. Good Luck");
            guessedChar = Char.ToUpper(Console.ReadKey().KeyChar);
            SolveHangman(guessedChar, stringToGuess, guessedCharArray);
        }

        static void EndResult(string wordGuessed, string outcome, char[] yourGuess)
        {
            Console.Clear();
            if (wordGuessed != "won")
            {
                OutputGraphics(hangmanGraphicsID);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                OutputGraphics(hangmanGraphicsID);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            foreach (char element in guessedCharArray)
            {
                Console.Write("  {0}  ", element);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            foreach (char element in lettersGuessed)
            {
                Console.Write("  {0}  ", element);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("You {0}, the word was {1}!\nPress any key to try again", outcome, wordGuessed);
            Console.ReadKey();
            Main();
        }

        static void PrintError(string error)
        {
            Console.Clear();
            Console.WriteLine("An error has occured in the game\nError: {0}\nPress any key to try again", error);
            Console.ReadKey();
            Main();
        }

        static void OutputGraphics(int hangmanGraphicsID)
        {
            switch (hangmanGraphicsID)
            {

                case -1:
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    break;
                case 0:
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("                                                       ");
                    Console.WriteLine("        __________________________________             ");
                    break;

                case 1:
                    Console.WriteLine("                                                      ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 2:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 3:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /                                  ");
                    Console.WriteLine("               |  /                                    ");
                    Console.WriteLine("               |/                                      ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 4:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/                                      ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 5:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/               O                      ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 6:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/               O                      ");
                    Console.WriteLine("               |                |                      ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 7:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/               O                      ");
                    Console.WriteLine("               |               \\|                     ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 8:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/               O                      ");
                    Console.WriteLine("               |               \\|/                     ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 9:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/               O                      ");
                    Console.WriteLine("               |               \\|/                     ");
                    Console.WriteLine("               |               /                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;

                case 10:
                    Console.WriteLine("        __________________________________             ");
                    Console.WriteLine("               |    /           |                      ");
                    Console.WriteLine("               |  /             |                      ");
                    Console.WriteLine("               |/               O                      ");
                    Console.WriteLine("               |               \\|/                     ");
                    Console.WriteLine("               |               / \\                     ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("               |                                       ");
                    Console.WriteLine("        _______|__________________________             ");
                    break;
            }
        }
    }
}