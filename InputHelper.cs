using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApplication
{
    public static class InputHelper
    {
        public static string GetNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    return input;
                Console.WriteLine("Invalid input, please try again.");
            }
        }

        public static int GetPositiveInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                    return result;
                Console.WriteLine("Invalid input, please enter a positive integer.");
            }
        }
    }

}
