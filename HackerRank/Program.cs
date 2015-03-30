using System;
using System.Linq;

namespace HangmanGame
{
    internal class HangmanLogic
    {
        static readonly string[] Graphics = {"", "", "", "", "", ""};
        private static int wrongGuesses;

        private static readonly char[] AlphabetCharArray =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        private static readonly char[] LettersGuessed = new char[26];
        private static char[] guessedCharArray;

        private static void Main()
        {
            Console.Clear();
            wrongGuesses = -1;
            FinalGraphics();

            Console.WriteLine("\nType a word that you would like to guess in this game");
            var readLine = Console.ReadLine();
            if (readLine == null) return;
            var stringToGuess = readLine.ToUpper();
            CheckWordSupport(stringToGuess);

            guessedCharArray = new char[stringToGuess.Length];
            ReplaceCharArray(LettersGuessed, '_');
            ReplaceCharArray(guessedCharArray, '_');
            ReplaceGuessWithSpace(stringToGuess);
            Console.Clear();
            FinalGraphics();
            SolveHangman(stringToGuess);
        }

        private static void SolveHangman(string stringToGuess)
        {
            Console.WriteLine("\nType a letter, and see if you can guess my word. Good Luck");
            while (true)
            {
                var guessedChar = Char.ToUpper(Console.ReadKey(true).KeyChar);
                if (!Char.IsLetter(guessedChar)) continue;
                
                var guessIsEdited = false;

                if (!Char.IsLetter(guessedChar) || CheckIfTyped(guessedChar)) guessIsEdited = true;
                else for (var i = 0; i < stringToGuess.Length; i++)
                {
                    if (stringToGuess[i] != guessedChar) continue;
                    guessIsEdited = true;
                    guessedCharArray[i] = guessedChar;
                }
                CheckIfWon(stringToGuess);
                ChangeCharOnType(guessedChar);
                if (guessIsEdited)
                {
                    if (stringToGuess.All(t => t != guessedChar)) wrongGuesses++;
                    Console.Clear();
                    OutputGraphics(wrongGuesses);
                    OutputCharArray(guessedCharArray);
                    OutputCharArray(LettersGuessed);
                }
                Console.WriteLine();
            }
        }

        private static void EndResult(string wordGuessed, string outcome)
        {
            Console.Clear();
            Console.CursorTop = 10;
            Console.WriteLine("\n\nYou {0}, the word was {1}!\nPress any key to try again, or press n to close", outcome, wordGuessed);
            if (Console.ReadKey(true).KeyChar == 'n')
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadKey(true); // So people can read it
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                for (var i = 0; i < 6; i++) Graphics[i] = "";
                Main();
            }
        }

        private static void ReplaceGuessWithSpace(string stringToGuess) { for (var i = 0; i < stringToGuess.Length; i++) if (stringToGuess[i] == ' ') guessedCharArray[i] = ' '; }

        private static void PrintError(string error)
        {
            Console.Clear();
            FinalGraphics();
            Console.WriteLine("\nAn error has occured in the game\nError: {0}\nPress any key to try again", error);
            Console.ReadKey(true);
            Main();
        }

        private static void ChangeCharOnType(char guessedChar) { for (var i = 0; i < AlphabetCharArray.Length; i++) if (AlphabetCharArray[i] == guessedChar) LettersGuessed[i] = guessedChar; }

        private static void ReplaceCharArray(char[] charArray, char charToReplace) { for (var i = 0; i < charArray.Length; i++) charArray[i] = charToReplace; }

        private static void CheckIfWon(string stringToGuess)
        {
            if (stringToGuess == new string(guessedCharArray)) EndResult(stringToGuess, "won");
            else if (wrongGuesses == 10) EndResult(stringToGuess, "lost");
        }

        private static bool CheckIfTyped(char guessedChar) { return LettersGuessed.Any(t => guessedChar == t); }

        private static void CheckWordSupport(string stringToGuess)
        {
            var areThereLetters = false;

            for (var i = 0; i < stringToGuess.Length; i++)
            {
                if (!areThereLetters && stringToGuess[i] != ' ') areThereLetters = true;
                if (!Char.IsLetter(stringToGuess[i]) && stringToGuess[i] != ' ') PrintError("The word you provided include characters that do not classify as letters");
                if (stringToGuess[i] != ' ' || stringToGuess[i] != stringToGuess[i + 1]) continue;
                stringToGuess = stringToGuess.Remove(i + 1, 1);
                i--;
            }

            if (!areThereLetters) PrintError("The word you provided consists entirely of spaces.");
        }

        private static void OutputCharArray(char[] charArray) { Console.WriteLine(); foreach (var element in charArray) Console.Write(" {0} ", element); }

        private static void FinalGraphics()
        {
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
            @" __________",
            @"| /      |",
            @"|/       0",
            @"|       /|\",
            @"|       / \",
            @"|_______________");
        }

        private static void OutputGraphics(int graphicsId)
        {
            if (graphicsId == 0) Graphics[5] = " _______________";
            if (graphicsId == 1)
            {
                for (var i = 1; i < 5; i++) Graphics[i] += "|";
                Graphics[5] = Graphics[5].Remove(0, 1).Insert(0, "|"); 
            }
            if (graphicsId == 2) Graphics[0] = " __________";
            if (graphicsId == 3) { Graphics[1] += " /"; Graphics[2] += "/"; }
            if (graphicsId == 4) Graphics[1] += "        |";
            if (graphicsId == 5) Graphics[2] += "         0";
            if (graphicsId == 6) Graphics[3] += "          |";
            if (graphicsId == 7) { Graphics[3] = Graphics[3].Remove(10, 1).Insert(10, "/"); }
            //TODO: optimise
            if (graphicsId == 8) Graphics[3] += @"\";
            if (graphicsId == 9) Graphics[4] += "         /";
            if (graphicsId == 10) Graphics[4] += " \\";
            for (var i = 0; i < 6; i++) Console.WriteLine(Graphics[i]);
        }
    }
}