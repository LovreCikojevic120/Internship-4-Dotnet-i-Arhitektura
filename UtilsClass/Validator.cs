using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilsClass
{
    public static class Validator
    {
        public static bool IsValidMenuOption(string start, string end, string option)
        {
            if(option.All(letter => char.IsDigit(letter)))
                if (int.TryParse(option, out int result) && int.TryParse(start, out int min) && int.TryParse(end, out int max))
                    if (result >= min && result <= max)
                        return true;
            return false;
        }

        public static bool CheckStringFormat(string suspectString)
        {
            if (suspectString.Any(letter => char.IsDigit(letter)) || string.IsNullOrEmpty(suspectString) || string.IsNullOrWhiteSpace(suspectString))
                return false;
            return true;
        }

        public static void WriteExitMessage(string message)
        {
            Console.WriteLine($"\n{message}, za nastavak pritisnite bilo koju tipku!");
            Console.ReadKey();
            Console.Clear();
        }

        public static string ValidateString(string message)
        {
            string suspectString = null;
            bool success = false;

            Console.WriteLine($"Unesite {message}:");
            do
            {
                suspectString = Console.ReadLine();

                if (CheckStringFormat(suspectString) is true)
                    success = true;

                else Console.WriteLine($"{message} krivo uneseno, pokusajte ponovono!\n");

            } while (success is not true);

            return suspectString.Trim();
        }

        public static List<int> ArrayToList(Array array)
        {
            var list = new List<int>();

            foreach (var item in array)
                list.Add((int)item);

            return list;
        }
    }
}
