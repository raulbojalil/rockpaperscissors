using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public interface GameOption
    {
        /// <summary>
        /// Gets the friendly name of the Game Option
        /// </summary>
        /// <returns></returns>
        string GetFriendlyName();

        /// <summary>
        /// Returns 1 if the current instance wins against the opposing option
        /// Returns 0 if the current instance loses against the opposing option
        /// Returns -1 if it's a draw
        /// </summary>
        /// <param name="opposingOption"></param>
        /// <returns>The outcome of the match</returns>
        int HandleOpposingOption(GameOption opposingOption);
    }
}
