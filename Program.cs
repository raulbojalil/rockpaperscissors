using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();

            Console.WriteLine("The program ended, run again to play again. Press any key to continue.");
            Console.ReadLine();
        }
    }
}
