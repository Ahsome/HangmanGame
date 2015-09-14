using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class Game : IDisposable
    {
        private Graphics graphics;
        private bool running;
        private bool inGame;
        readonly char[] LettersGuessed;
        int wrongGuesses;
        char[] guessedCharArray;

        public Game()
        {
            graphics = new Graphics();
            LettersGuessed = new char[26];
        }

        public void Initialise()
        {
            running = true;
            inGame = false;
            Console.CursorVisible = false;
            Run();
        }

        private void Run()
        {
            // Main Game loop (allows returning to start after invalid characters being provided by the user)
            while (running)
            {
                Console.Clear();
                wrongGuesses = -1;
                graphics.FinalGraphics();

                Console.WriteLine("\nType a word that you would like to guess in this game");
                var stringToGuess = "";

                while (String.IsNullOrWhiteSpace(stringToGuess))
                    stringToGuess = Console.ReadLine();

                if (stringToGuess.Any(t => !Char.IsLetter(t) && !Char.IsSeparator(t)))
                {
                    Console.WriteLine("The word you provided include characters that do not classify as letters");
                    Console.ReadKey();
                    continue;
                }

                stringToGuess = stringToGuess.ToUpper();
                stringToGuess = stringToGuess.Replace("  ", " ");

                guessedCharArray = new char[stringToGuess.Length];
                LettersGuessed.Fill('_');
                guessedCharArray.Fill('_');

                for (var i = 0; i < stringToGuess.Length; i++)
                {
                    if (stringToGuess[i] == ' ')
                        guessedCharArray[i] = ' ';
                }

                Console.Clear();
                Console.CursorTop = 6;
                guessedCharArray.Output();
                LettersGuessed.Output();
                inGame = true;

                // Ingame loop, whilst true, the user is trying to guess a word
                while (inGame)
                {
                    Console.SetCursorPosition(0, 0);
                    var guessedChar = Char.ToUpper(Console.ReadKey(true).KeyChar);

                    if (!Char.IsLetter(guessedChar))
                        continue;

                    var guessIsEdited = false;

                    if (LettersGuessed[guessedChar - 65] == guessedChar)
                        continue;

                    for (var i = 0; i < stringToGuess.Length; i++)
                    {
                        if (stringToGuess[i] != guessedChar)
                            continue;

                        guessIsEdited = true;
                        guessedCharArray[i] = guessedChar;
                    }

                    if (Char.IsLetter(guessedChar)) LettersGuessed[guessedChar - 65] = guessedChar;

                    if (guessIsEdited)
                    {
                        Console.CursorTop = 6;
                        guessedCharArray.Output();
                    }
                    else
                    {
                        wrongGuesses++;
                        graphics.IncrementGraphics(wrongGuesses);
                    }

                    Console.CursorTop = 7 + guessedCharArray.Length / 39; LettersGuessed.Output();

                    if (stringToGuess == new string(guessedCharArray))
                    {
                        graphics.EndResult(stringToGuess, "won");
                        if (Console.ReadKey(true).KeyChar == 'n')
                        {
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadKey(true);
                            running = false;
                        }
                        inGame = false;
                    }
                    else if (wrongGuesses == 10)
                    {
                        graphics.EndResult(stringToGuess, "lost");
                        if (Console.ReadKey(true).KeyChar == 'n')
                        {
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadKey(true);
                            running = false;
                        }
                        inGame = false;
                    }
                }
            }
        }

        public void Dispose()
        { }
    }

    static class Extensions
    {
        public static void Fill(this char[] array, char filler)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = filler;
            }
        }

        public static void Output(this char[] array)
        {
            Console.WriteLine();
            foreach (var letter in array)
            {
                Console.Write(" {0} ", letter);
            }
        }
    }
}
