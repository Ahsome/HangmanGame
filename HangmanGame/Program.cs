using System;
using System.Linq;

namespace HangmanGame
{
    internal class Hangman
    {
        static readonly string[] Graphics = { "", "", "", "", "", "" };
        static readonly char[] LettersGuessed = new char[26];
        static int wrongGuesses; static char[] guessedCharArray;

        private static void Main()
        {
            Console.CursorVisible = false;
            Console.Clear();
            wrongGuesses = -1;
            FinalGraphics();

            Console.WriteLine("\nType a word that you would like to guess in this game");
            var stringToGuess = Console.ReadLine();
            if (stringToGuess == null) return;
            stringToGuess = stringToGuess.ToUpper();

            var thereAreLetters = stringToGuess.Any(Char.IsLetter);
            if (stringToGuess.Any(t => !Char.IsLetter(t) && t != ' ')) PrintError("The word you provided include characters that do not classify as letters");
            if (!thereAreLetters) PrintError("The word you provided consists entirely of spaces.");

            while (stringToGuess.Contains("  ")) stringToGuess = stringToGuess.Replace("  ", " ");
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
            //Console.WriteLine("\nType a letter, and see if you can guess my word. Good Luck");
            Console.Clear(); Console.CursorTop = 6; guessedCharArray.Output(); LettersGuessed.Output();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                var guessedChar = Char.ToUpper(Console.ReadKey(true).KeyChar);
                if (!Char.IsLetter(guessedChar)) continue;
                var guessIsEdited = false;
                if (LettersGuessed[guessedChar - 65] == guessedChar) continue;
                //guessIsEdited = true;
                for (var i = 0; i < stringToGuess.Length; i++)
                {
                    if (stringToGuess[i] != guessedChar) continue;
                    guessIsEdited = true;
                    guessedCharArray[i] = guessedChar;
                }
                if (Char.IsLetter(guessedChar)) LettersGuessed[guessedChar - 65] = guessedChar;
                if (guessIsEdited) { Console.CursorTop = 6; guessedCharArray.Output(); }
                else IncrementGraphics();
                Console.CursorTop = 7 + guessedCharArray.Length / 39; LettersGuessed.Output();
                if (stringToGuess == new string(guessedCharArray)) EndResult(stringToGuess, "won");
                else if (wrongGuesses == 10) EndResult(stringToGuess, "lost");
            }
        }

        private static void EndResult(string wordGuessed, string outcome)
        {
            Console.Clear();
            Console.ReadKey();
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

        private static void IncrementGraphics()
        {
            wrongGuesses++;
            //TODO: make it console.writeline instead?
            if (wrongGuesses == 0) { Console.CursorTop = 5; Console.Write(" _______________"); }
            if (wrongGuesses == 1) { Console.CursorTop = 1; for (var i = 1; i < 6; i++) Console.WriteLine(Graphics[i] += "|"); }
            if (wrongGuesses == 2) { Console.Write(" __________"); }
            if (wrongGuesses == 3) { Console.CursorTop = 1; Console.Write("| /\n|/"); }
            if (wrongGuesses == 4) { Console.SetCursorPosition(9, 1); Console.Write("|"); }
            if (wrongGuesses == 5) { Console.SetCursorPosition(9, 2); Console.Write("0"); }
            if (wrongGuesses == 6) { Console.SetCursorPosition(9, 3); Console.Write("|");}
            if (wrongGuesses == 7) { Console.SetCursorPosition(8, 3); Console.Write("/"); }
            if (wrongGuesses == 8) { Console.SetCursorPosition(10, 3); Console.Write(@"\"); }
            if (wrongGuesses == 9) { Console.SetCursorPosition(8, 4); Console.Write("/"); }
            if (wrongGuesses == 10) { Console.SetCursorPosition(10, 2); Console.Write(@" \"); }
        }
    }

    static class Extensions
    {
        public static void Fill(this char[] array, char filler) { for (var i = 0; i < array.Length; i++) array[i] = filler; }
        public static void Output(this char[] array) { Console.WriteLine(); foreach (var letter in array) Console.Write(" {0} ", letter); }
    }
}