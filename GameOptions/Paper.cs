using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public class Paper : GameOption
    {
        public string GetFriendlyName()
        {
            return "Paper";
        }

        public int HandleOpposingOption(GameOption opposingOption)
        {
            if (opposingOption is Rock) return 1;
            else if (opposingOption is Paper) return -1;
            else if (opposingOption is Scissors) return 0;

            throw new Exception("Undefined behavior for specified type");
        }
    }
}
