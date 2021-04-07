using RockPaperScissors.GameOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players
{
    public interface IPlayer
    {
        /// <summary>
        /// Handles the logic of selecting an option
        /// </summary>
        /// <returns>The selected option</returns>
        IGameOption PickOption(IGameOption previousRoundOption, IGameOption[] gameOptions);

        /// <summary>
        /// The sort order of this item
        /// </summary>
        /// <returns></returns>
        int GetSortOrder();
    }
}
