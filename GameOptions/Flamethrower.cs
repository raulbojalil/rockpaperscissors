using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public class Flamethrower : GameOption
    {
        public string GetFriendlyName()
        {
            return "Flamethrower";
        }

        public int HandleOpposingOption(GameOption opposingOption)
        {
            //A Flamethrower beats paper and loses to rock and scissors.
            if (opposingOption is Rock) return 0;
            else if (opposingOption is Paper) return 1;
            else if (opposingOption is Scissors) return 0;
            else if (opposingOption is Flamethrower) return -1;

            throw new Exception("Undefined behavior for specified type");
        }
    }
}
