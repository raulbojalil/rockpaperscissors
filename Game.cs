using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using RockPaperScissors.GameOptions;
using RockPaperScissors.Players;
using System.Threading;

namespace RockPaperScissors
{
    public class Game
    {
        public int RoundsToWin { get; private set; }

        public Game (int roundsToWin = 3) => RoundsToWin = roundsToWin;

        public void Run()
        {
            PrintBanner();

            //To add a new game option type, add it to the GameOptions folder and implement the GameOption interface
            var gameOptions = GetGameOptions();

            //To add a new player type, add it to the Players folder and implement the Player interface
            var players = GetPlayerTypes();

            PrintRules(gameOptions);

            var firstPlayer = new HumanPlayer("Human");

            var secondPlayer = PickSecondPlayer(players);

            var firstPlayerScore = 0;
            var secondPlayerScore = 0;

            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("THE GAME STARTS!");
            Console.WriteLine($"{firstPlayer.GetFriendlyName()} VS {secondPlayer.GetFriendlyName()}");
            Console.WriteLine($"First player to score {RoundsToWin} round(s) wins!");
            Console.WriteLine("----------------------------------------------------\n");

            //We sleep to make it easier to see what's going on
            Thread.Sleep(1000);

            IGameOption previousSecondPlayerRoundOption = null;

            while (firstPlayerScore != RoundsToWin && secondPlayerScore != RoundsToWin)
            {
                var firstPlayerOption = firstPlayer.PickOption(null, gameOptions);

                Console.WriteLine($"\n{firstPlayer.GetFriendlyName()} picked {firstPlayerOption.GetFriendlyName()}");

                var secondPlayerOption = secondPlayer.PickOption(previousSecondPlayerRoundOption, gameOptions);
                previousSecondPlayerRoundOption = secondPlayerOption;

                Console.WriteLine($"\n{secondPlayer.GetFriendlyName()} picked {secondPlayerOption.GetFriendlyName()}");
                
                Thread.Sleep(1000);

                var roundOutcome = firstPlayerOption.HandleOpposingOption(secondPlayerOption);

                Console.Write($"\n{firstPlayer.GetFriendlyName()} picked {firstPlayerOption.GetFriendlyName()} and {secondPlayer.GetFriendlyName()} picked {secondPlayerOption.GetFriendlyName()} so..., ");

                if (roundOutcome != -1)
                {
                    Console.WriteLine(roundOutcome == 1
                        ? $"{firstPlayer.GetFriendlyName()} wins this round!"
                        : $"{secondPlayer.GetFriendlyName()} wins this round!");
                    firstPlayerScore += (roundOutcome == 1) ? 1 : 0;
                    secondPlayerScore += (roundOutcome == 0) ? 1 : 0;
                }
                else
                    Console.WriteLine("it's a DRAW!, the game continues...");

                Thread.Sleep(1000);

                Console.WriteLine("\n--------------------------------");
                Console.WriteLine("Current score:");
                Console.WriteLine($"{firstPlayer.GetFriendlyName()}: {firstPlayerScore} - {secondPlayer.GetFriendlyName()}: {secondPlayerScore}");
                Console.WriteLine("--------------------------------\n");

                Thread.Sleep(1000);
            }

            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("WE HAVE A WINNER!");
            Console.WriteLine($"CONGRATULATIONS {(firstPlayerScore > secondPlayerScore ? firstPlayer.GetFriendlyName() : secondPlayer.GetFriendlyName())}");
            Console.WriteLine("--------------------------------\n");

        }

        private void PrintBanner()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("WELCOME TO ROCK-PAPER-SCISSORS!");
            Console.WriteLine("--------------------------------");
        }

        private void PrintRules(IGameOption[] options)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("PLEASE REVIEW THE RULES BEFORE PLAYING:");
            Console.WriteLine("---------------------------------------");

            foreach(var option in options)
            {
                foreach (var rivalOption in options)
                {
                    var outcome = option.HandleOpposingOption(rivalOption);
                    var outcomeDisplay = "";

                    switch (outcome)
                    {
                        case 0: outcomeDisplay = "loses against"; break;
                        case -1: outcomeDisplay = "has no effect against"; break;
                        case 1: outcomeDisplay = "beats"; break;
                    }

                    Console.WriteLine($"{option.GetFriendlyName()} {outcomeDisplay} {rivalOption.GetFriendlyName()}");
                }
            }

            Console.WriteLine("---------------------------------------\n");
        }

        private IPlayer PickSecondPlayer(IPlayer[] players)
        {
            var selectedOption = -1;

            Console.WriteLine($"Who do you want to play with?:");
            Console.WriteLine("-------------------------------");

            for (var i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {players[i].GetFriendlyName()}");
            }

            while (selectedOption == -1)
            {
                Console.Write("\nYour choice: ");

                var rawPickedOption = Console.ReadLine();

                selectedOption = int.TryParse(rawPickedOption, out selectedOption) && selectedOption > 0 && selectedOption <= players.Length
                    ? selectedOption
                    : -1;

                if (selectedOption == -1)
                    Console.WriteLine("Invalid option, please try again.");
            }

            return players[selectedOption - 1];
        }

        private IGameOption[] GetGameOptions()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterface(nameof(IGameOption)) != null)
                .Select(x => Activator.CreateInstance(x) as IGameOption)
                .ToArray();
        }

        private IPlayer[] GetPlayerTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterface(nameof(IPlayer)) != null)
                .Select(x => Activator.CreateInstance(x) as IPlayer)
                .ToArray();
        }
    }
}
