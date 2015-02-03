using System;
using System.Collections.Generic;

namespace HangmanCode
{
    class HangmanLogic
    {
        /*
        Things to do:
         * Make all errors call one specific function
         * Rewrite error function to look better
         * Fix issue with space bar, simply add a space, and then remove it from the string afterwards 
        */
        static int hangmanGraphicsID;
        static char[] alphabetCharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static char[] lettersGuessed = new char[alphabetCharArray.Length];
        static char[] guessedCharArray;

        static void Main()
        {
            Console.Clear();
            hangmanGraphicsID = -1;
            OutputGraphics(10);

            Console.WriteLine();
            Console.WriteLine("Type a word that you would like to guess in this game");
            string stringToGuess = Console.ReadLine().ToUpper().Replace(" ", string.Empty);

            foreach (char letter in stringToGuess)
            {
                if (Char.IsNumber(letter))
                {
                    PrintError("The word you provided included a number/s, which is not supported");
                }
            }

            guessedCharArray = new char[stringToGuess.Length];
            ReplaceCharArray(lettersGuessed, '-');
            ReplaceCharArray(guessedCharArray, '-');

            SolveHangman(stringToGuess, guessedCharArray);
        }

        static void SolveHangman(string stringToGuess, char[] guessedCharArray)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type a letter, and see if you can guess my word. Good Luck");
            char guessedChar = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.Clear();

            bool isGuessEdited = false;

           

            for (int i = 0; i < stringToGuess.Length; i++)
            {
                if (!Char.IsLetter(guessedChar))
                {
                    isGuessEdited = true;
                    break;
                }
                if (CheckIfTyped(guessedChar))
                {
                    isGuessEdited = true;
                    break;
                }
                if (guessedChar == stringToGuess[i])
                {
                    guessedCharArray[i] = guessedChar;
                    isGuessEdited = true;
                }
            }

            if (stringToGuess == new string(guessedCharArray))
            {
                if (EndResult(stringToGuess, "won", guessedCharArray))
                {
                    return;
                }
                else
                {
                    Main();
                }
            }
            else if (hangmanGraphicsID == 9)
            {
                if (EndResult(stringToGuess, "lost", guessedCharArray))
                {
                    return;
                }
                else
                {
                    Main();
                }
            }

            if (!isGuessEdited)
            {
                hangmanGraphicsID++;
            }

            ChangeCharOnType(guessedChar);
            OutputGraphics(hangmanGraphicsID);

            OutputCharArray(guessedCharArray);
            OutputCharArray(lettersGuessed);
            SolveHangman(stringToGuess, guessedCharArray);
        }

        static bool EndResult(string wordGuessed, string outcome, char[] yourGuess)
        {
            Console.Clear();
            OutputGraphics(hangmanGraphicsID);
            OutputCharArray(guessedCharArray);
            OutputCharArray(lettersGuessed);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("You {0}, the word was {1}!\nPress any key to try again, or press N to close", outcome, wordGuessed);
            if (Char.ToUpper(Console.ReadKey().KeyChar) == 'N')
            {
                Console.WriteLine("Thanks for playing!");
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }
        }

        static void PrintError(string error)
        {
            Console.Clear();
            Console.WriteLine("An error has occured in the game\nError: {0}\nPress any key to try again", error);
            Console.ReadKey();
            Main();
        }

        static void ChangeCharOnType(char guessedChar)
        {
            for (int i = 0; i < alphabetCharArray.Length; i++)
            {
                if (alphabetCharArray[i] == guessedChar)
                {
                    lettersGuessed[i] = guessedChar;
                }
            }
        }

        static void ReplaceCharArray(char[] charArray, char charToReplace)
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = charToReplace;
            }
        }

        static void CheckIfWon(string stringToGuess)
        {
            if (stringToGuess == new string(guessedCharArray))
            {
                if (EndResult(stringToGuess, "won", guessedCharArray))
                {
                    return;
                }
                else
                {
                    Main();
                }
            }
            else if (hangmanGraphicsID == 9)
            {
                EndResult(stringToGuess, "lost", guessedCharArray);
            }
        }

        static bool CheckIfTyped(char guessedChar)
        {
            for (int i = 0; i < lettersGuessed.Length; i++)
            {
                if (guessedChar == lettersGuessed[i])
                {
                    return true;
                }
            }
            return false;
        }

        static void OutputCharArray(char[] charArray)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (char element in charArray)
            {
                Console.Write(" {0} ", element);
            }
        }

        static void OutputGraphics(int hangmanGraphicsID)
        {
            switch (hangmanGraphicsID)
            {

                case -1:
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;

                case 0:
                    Console.WriteLine(" ");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 1:
                    Console.WriteLine(" __________");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 2:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /");
                    Console.WriteLine("|/");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 3:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 4:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/         0");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 5:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/         0");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 6:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/         0");
                    Console.WriteLine("|         /|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 7:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/         0");
                    Console.WriteLine("|         /|\\");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 8:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/         0");
                    Console.WriteLine("|         /|\\");
                    Console.WriteLine("|         /");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;

                case 9:
                    Console.WriteLine(" __________");
                    Console.WriteLine("| /        |");
                    Console.WriteLine("|/         0");
                    Console.WriteLine("|         /|\\");
                    Console.WriteLine("|         / \\");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
            }
        }
    }
}