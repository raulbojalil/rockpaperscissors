using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RockPaperScissors
{
    public static class ConsoleUtils
    {
        public static T Prompt<T>(string prompt, T[] options)
        {
            var selectedOption = -1;

            Console.WriteLine(prompt);
            Console.WriteLine(string.Join("", prompt.Select(x => "-")));

            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {options[i]}");
            }

            while (selectedOption == -1)
            {
                Console.Write("\nYour choice: ");

                var rawPickedOption = Console.ReadLine();

                selectedOption = int.TryParse(rawPickedOption, out selectedOption) 
                    && selectedOption > 0 
                    && selectedOption <= options.Length
                    ? selectedOption
                    : -1;

                if (selectedOption == -1)
                    Console.WriteLine("Invalid option, please try again.");
            }

            return options[selectedOption-1];
        }

    }
}
