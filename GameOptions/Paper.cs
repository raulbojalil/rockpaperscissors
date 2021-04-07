using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public class Paper : IGameOption
    {
        public override string ToString() => "Paper";
        public int GetSortOrder() => 0;

        public int HandleOpposingOption(IGameOption opposingOption)
        {
            if (opposingOption is Rock) return 1;
            else if (opposingOption is Paper) return -1;
            else if (opposingOption is Scissors) return 0;
            else if (opposingOption is Flamethrower) return 0;

            throw new Exception("Undefined behavior for specified type");
        }
    }
}
