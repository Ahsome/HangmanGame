using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class Graphics
    {
        public void FinalGraphics()
        {
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
            @" __________",
            @"| /      |",
            @"|/       0",
            @"|       /|\",
            @"|       / \",
            @"|_______________");
        }

        public void IncrementGraphics(int wrongGuesses)
        {
            switch (wrongGuesses)
            {
                case 0:
                    Console.CursorTop = 5; Console.Write(" _______________");
                    break;
                case 1:
                    for (var i = 1; i < 6; i++)
                    {
                        Console.SetCursorPosition(0, i); Console.Write("|");
                    }
                    break;
                case 2:
                    Console.Write(" __________");
                    break;
                case 3:
                    Console.CursorTop = 1; Console.Write("| /\n|/");
                    break;
                case 4:
                    Console.SetCursorPosition(9, 1); Console.Write("|");
                    break;
                case 5:
                    Console.SetCursorPosition(9, 2); Console.Write("0");
                    break;
                case 6:
                    Console.SetCursorPosition(9, 3); Console.Write("|");
                    break;
                case 7:
                    Console.SetCursorPosition(8, 3); Console.Write("/");
                    break;
                case 8:
                    Console.SetCursorPosition(10, 3); Console.Write(@"\");
                    break;
                case 9:
                    Console.SetCursorPosition(8, 4); Console.Write("/");
                    break;
                case 10:
                    Console.SetCursorPosition(10, 4); Console.Write(@"\");
                    break;
            }
        }

        public void EndResult(string stringToGuess, string outcome)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("You {0}, the word was {1}!\nPress any key to try again, or press [n] to close", outcome, stringToGuess);
        }
    }
}
