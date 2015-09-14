using System;
using System.Linq;

namespace HangmanGame
{
    internal class Hangman
    {
        private static void Main()
        {
            using (var hangmanGame = new Game())
            {
                hangmanGame.Initialise();
            }
        }
    }
}