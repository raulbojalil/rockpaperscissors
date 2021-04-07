using RockPaperScissors.GameOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players
{
    public class HumanPlayer : IPlayer
    {
        public string FriendlyName { get; private set; }

        public HumanPlayer(string friendlyName) => FriendlyName = friendlyName;

        public HumanPlayer() => FriendlyName = "Human (P2)";

        public override string ToString() => FriendlyName;
        public int GetSortOrder() => 1;

        public IGameOption PickOption(IGameOption previousRoundOption, IGameOption[] gameOptions)
        {
            return ConsoleUtils.Prompt($"\n{FriendlyName}, pick an option: ", gameOptions);
        }
    }
}
