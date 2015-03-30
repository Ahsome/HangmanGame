using System;
using System.Linq;

namespace HangmanGame
{
    internal class Hangman
    {
        static readonly string[] Graphics = {"", "", "", "", "", ""};
        static int wrongGuesses;
        static readonly char[] LettersGuessed = new char[26];
        static char[] guessedCharArray;

        private static void Main()
        {
            Console.Clear();
            wrongGuesses = -1;
            FinalGraphics();

            Console.WriteLine("\nType a word that you would like to guess in this game");
            var stringToGuess = Console.ReadLine();
            if (stringToGuess == null) return;
            stringToGuess = stringToGuess.ToUpper();

            var thereAreLetters = stringToGuess.Any(Char.IsLetter);
            while (stringToGuess.Contains("  ")) stringToGuess = stringToGuess.Replace("  ", " ");
            if (stringToGuess.Any(t => !Char.IsLetter(t) && t != ' ')) PrintError("The word you provided include characters that do not classify as letters");
            if (!thereAreLetters) PrintError("The word you provided consists entirely of spaces.");

            guessedCharArray = new char[stringToGuess.Length];
            LettersGuessed.Fill('_');
            guessedCharArray.Fill('_');
            for (var i = 0; i < stringToGuess.Length; i++) if (stringToGuess[i] == ' ') guessedCharArray[i] = ' ';
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
                if (!Char.IsLetter(guessedChar) || LettersGuessed.Any(t => guessedChar == t)) guessIsEdited = true;
                else for (var i = 0; i < stringToGuess.Length; i++)
                {
                    if (stringToGuess[i] != guessedChar) continue;
                    guessIsEdited = true;
                    guessedCharArray[i] = guessedChar;
                }
                if (stringToGuess == new string(guessedCharArray)) EndResult(stringToGuess, "won");
                else if (wrongGuesses == 10) EndResult(stringToGuess, "lost");
                if (Char.IsLetter(guessedChar)) LettersGuessed[guessedChar - 65] = guessedChar;
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

        private static void PrintError(string error)
        {
            Console.Clear();
            FinalGraphics();
            Console.WriteLine("\nAn error has occured in the game\nError: {0}\nPress any key to try again", error);
            Console.ReadKey(true);
            Main();
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

    static class Extensions
    {
        public static void Fill(this char[] charArray, char charToReplace) { for (var i = 0; i < charArray.Length; i++) charArray[i] = charToReplace; }

    }
}