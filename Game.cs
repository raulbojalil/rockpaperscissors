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
        public void Run(int roundsToWin = 3)
        {
            //To add a new game option type, add it to the GameOptions folder and implement the GameOption interface
            var gameOptions = GetGameOptions();

            //To add a new player type, add it to the Players folder and implement the Player interface
            var players = GetPlayerTypes();

            PrintRules(gameOptions);

            var firstPlayer = new HumanPlayer("Human");
            var secondPlayer = ConsoleUtils.Prompt("Who do you want to play with?", players);

            var firstPlayerScore = 0;
            var secondPlayerScore = 0;
            var currentRound = 0;

            PrintStartGameBanner(firstPlayer, secondPlayer, roundsToWin);

            //We sleep to make it easier to see what's going on
            Thread.Sleep(1000);

            IGameOption previousSecondPlayerRoundOption = null;

            while (firstPlayerScore != roundsToWin && secondPlayerScore != roundsToWin)
            {
                currentRound++;
                Console.WriteLine($"\n------ ROUND {currentRound} -------\n");

                Thread.Sleep(500);

                var firstPlayerOption = firstPlayer.PickOption(null, gameOptions);

                Console.WriteLine($"\n{firstPlayer} picked {firstPlayerOption}");

                var secondPlayerOption = secondPlayer.PickOption(previousSecondPlayerRoundOption, gameOptions);
                previousSecondPlayerRoundOption = secondPlayerOption;

                Console.WriteLine($"\n{secondPlayer} picked {secondPlayerOption}");
                
                Thread.Sleep(1000);

                var roundOutcome = firstPlayerOption.HandleOpposingOption(secondPlayerOption);

                firstPlayerScore += (roundOutcome == 1) ? 1 : 0;
                secondPlayerScore += (roundOutcome == 0) ? 1 : 0;

                PrintRoundOutcome(roundOutcome, firstPlayer, firstPlayerOption, secondPlayer, secondPlayerOption);

                Thread.Sleep(1000);

                PrintCurrentScore(firstPlayer, firstPlayerScore, secondPlayer, secondPlayerScore);

                Thread.Sleep(1000);
            }

            PrintWinner(firstPlayerScore > secondPlayerScore ? firstPlayer : secondPlayer, currentRound);

        }

        private void PrintRoundOutcome(int roundOutcome, IPlayer firstPlayer, IGameOption firstPlayerOption, 
            IPlayer secondPlayer, IGameOption secondPlayerOption)
        {
            Console.Write($"\n{firstPlayer} picked {firstPlayerOption} and {secondPlayer} picked {secondPlayerOption} so..., ");

            if (roundOutcome != -1)
            {
                Console.WriteLine(roundOutcome == 1
                    ? $"{firstPlayer} wins this round!"
                    : $"{secondPlayer} wins this round!");
            }
            else
                Console.WriteLine("it's a DRAW!, the game continues...");
        }

        private void PrintStartGameBanner(IPlayer firstPlayer, IPlayer secondPlayer, int roundsToWin)
        {
            Console.WriteLine("\n---------------------------------------------------" +
                              "\nTHE GAME STARTS!" +
                             $"\n{firstPlayer} VS {secondPlayer}" +
                             $"\nFirst player to score {roundsToWin} round(s) wins!" +
                              "\n----------------------------------------------------\n");
        }

        private void PrintCurrentScore(IPlayer firstPlayer, int firstPlayerScore, IPlayer secondPlayer, int secondPlayerScore)
        {
            Console.WriteLine("\n--------------------------------" +
                              "\nCURRENT SCORE:" +
                             $"\n{firstPlayer}: {firstPlayerScore} - {secondPlayer}: {secondPlayerScore}" +
                              "\n--------------------------------\n");
        }

        private void PrintWinner(IPlayer player, int totalRounds)
        {
            Console.WriteLine("\n--------------------------------" +
                              "\nWE HAVE A WINNER!" +
                             $"\nCONGRATULATIONS {player}" +
                             $"\nTOTAL ROUNDS: {totalRounds}" +
                              "\n--------------------------------\n");
        }

        private void PrintRules(IGameOption[] options)
        {
            Console.WriteLine("---------------------------------------" +
                              "\nWELCOME TO ROCK - PAPER - SCISSORS!" +
                              "\nPLEASE REVIEW THE RULES BEFORE PLAYING:" +
                              "\n---------------------------------------");

            foreach(var option in options)
            {
                foreach (var rivalOption in options)
                {
                    var outcome = option.HandleOpposingOption(rivalOption);
                    var outcomeDisplay = "";

                    switch (outcome)
                    {
                        case 0: outcomeDisplay = "loses to"; break;
                        case -1: outcomeDisplay = "has no effect against"; break;
                        case 1: outcomeDisplay = "beats"; break;
                    }

                    Console.WriteLine($"{option} {outcomeDisplay} {rivalOption}");
                }
            }

            Console.WriteLine("---------------------------------------\n");
        }

        private IGameOption[] GetGameOptions()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterface(nameof(IGameOption)) != null)
                .Select(x => Activator.CreateInstance(x) as IGameOption)
                .OrderBy(x => x.GetSortOrder())
                .ToArray();
        }

        private IPlayer[] GetPlayerTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterface(nameof(IPlayer)) != null)
                .Select(x => Activator.CreateInstance(x) as IPlayer)
                .OrderBy(x => x.GetSortOrder())
                .ToArray();
        }
    }
}
