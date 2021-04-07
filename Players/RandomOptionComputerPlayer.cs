using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using RockPaperScissors.GameOptions;

namespace RockPaperScissors.Players
{
    public class RandomOptionComputerPlayer : Player
    {
        private Random _random = new Random();

        public string GetFriendlyName()
        {
            return "Computer (which always selects a random option)";
        }

        public GameOption PickOption(GameOption previousRoundOption, GameOption[] gameOptions)
        {
            //To simulate computer "thinking"
            Thread.Sleep(500);

            Console.WriteLine("\nComputer says: I'm picking whatever option I want!");
            return gameOptions[_random.Next(gameOptions.Length)];
        }
    }
}
