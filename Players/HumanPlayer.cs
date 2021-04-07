using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameOptions
{
    public class HumanPlayer : Player
    {
        public string FriendlyName { get; private set; }

        public HumanPlayer(string friendlyName) => FriendlyName = friendlyName;

        public HumanPlayer() => FriendlyName = "Human (P2)";

        public string GetFriendlyName()
        {
            return FriendlyName;
        }

        public GameOption PickOption(GameOption previousRoundOption, GameOption[] gameOptions)
        {
            var selectedOption = -1;

            Console.WriteLine($"\n{GetFriendlyName()}, pick an option:");
            Console.WriteLine("------------------");

            for (var i = 0; i < gameOptions.Length; i++)
            {
                Console.WriteLine($"{i+1}: {gameOptions[i].GetFriendlyName()}");
            }

            while (selectedOption == -1) {

                Console.Write("\nYour choice: ");

                var rawPickedOption = Console.ReadLine();

                selectedOption = int.TryParse(rawPickedOption, out selectedOption) && selectedOption > 0 && selectedOption <= gameOptions.Length
                    ? selectedOption
                    : -1;

                if (selectedOption == -1)
                    Console.WriteLine("Invalid option, please try again.");
            }

            return gameOptions[selectedOption-1];
        }
    }
}
