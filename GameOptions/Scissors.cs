using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public class Scissors : GameOption
    {
        public string GetFriendlyName()
        {
            return "Scissors";
        }

        public int HandleOpposingOption(GameOption opposingOption)
        {
            if (opposingOption is Rock) return 0;
            else if (opposingOption is Paper) return 1;
            else if (opposingOption is Scissors) return -1;
            else if (opposingOption is Flamethrower) return 1;

            throw new Exception("Undefined behavior for specified type");
        }
    }
}
