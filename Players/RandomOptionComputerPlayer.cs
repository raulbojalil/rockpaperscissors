using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using RockPaperScissors.GameOptions;

namespace RockPaperScissors.Players
{
    public class RandomOptionComputerPlayer : IPlayer
    {
        private Random _random = new Random();

        public int GetSortOrder() => 2;
        public override string ToString() => "Computer (which always selects a random option)";

        public IGameOption PickOption(IGameOption previousRoundOption, IGameOption[] gameOptions)
        {
            //To simulate computer "thinking"
            Thread.Sleep(500);

            Console.WriteLine("\nComputer says: I'm picking whatever option I want!");
            return gameOptions[_random.Next(gameOptions.Length)];
        }
    }
}
