using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public interface Player
    {
        /// <summary>
        /// Gets the friendly name of the Player
        /// </summary>
        /// <returns>The friendly name of the player</returns>
        string GetFriendlyName();

        /// <summary>
        /// Handles the logic of selecting an option
        /// </summary>
        /// <returns>The selected option</returns>
        GameOption PickOption(GameOption previousRoundOption, GameOption[] gameOptions);
    }
}
