using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public class Rock : IGameOption
    {
        public string GetFriendlyName()
        {
            return "Rock";
        }

        public int HandleOpposingOption(IGameOption opposingOption)
        {
            if (opposingOption is Rock) return -1;
            else if (opposingOption is Paper) return 0;
            else if (opposingOption is Scissors) return 1;
            else if (opposingOption is Flamethrower) return 1;

            throw new Exception("Undefined behavior for specified type");
        }
    }
}
