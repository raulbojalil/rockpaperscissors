using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public interface IGameOption
    {
        /// <summary>
        /// Returns 1 if the current instance wins against the opposing option
        /// Returns 0 if the current instance loses against the opposing option
        /// Returns -1 if it's a draw
        /// </summary>
        /// <param name="opposingOption"></param>
        /// <returns>The outcome of the match</returns>
        int HandleOpposingOption(IGameOption opposingOption);

        /// <summary>
        /// The sort order of this item
        /// </summary>
        /// <returns></returns>
        int GetSortOrder();

    }
}
