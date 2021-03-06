using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using RockPaperScissors.GameOptions;

namespace RockPaperScissors.Players
{
    public class ComputerPlayer : IPlayer
    {
        public override string ToString() => "Computer";
        public int GetSortOrder() => 0;

        public IGameOption PickOption(IGameOption previousRoundOption, IGameOption[] gameOptions)
        {
            //To simulate computer "thinking"
            Thread.Sleep(500);

            //The computer player chooses the option that would have beat its previous selection.
            // Ex: In round 1, the computer chooses rock, then in round 2 it selects paper.

            //if previous round option is null (which means that it's the first round) then pick at random
            if (previousRoundOption == null)
            {
                Console.WriteLine("\nComputer says: This is the first round, I'm picking whatever option I want!");
                return gameOptions[new Random().Next(gameOptions.Length)];
            }

            var option = gameOptions.FirstOrDefault(x => x.HandleOpposingOption(previousRoundOption) == 1);

            if (option == null)
                throw new Exception("No suitable option found");

            Console.WriteLine($"\nComputer says: Since I picked {previousRoundOption} before, I'm picking {option}!");

            return option;
        }
    }
}
