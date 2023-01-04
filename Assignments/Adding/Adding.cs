// Adding
using System;
using System.Linq;

// Alias
using con = System.Console;

namespace Adding
{
    class Adding
    {
        static void Main(string[] args)
        {
            const int NUMBERS_TO_ADD = 2;

            // Place to store user input
            int[] intArray = new int[NUMBERS_TO_ADD];

            con.WriteLine("Addition program.");

            // Collect user input
            for (int i = 0; i < NUMBERS_TO_ADD; i++)
            {
                con
                    .WriteLine($"Please enter a number: ({i + 1}/{
                        NUMBERS_TO_ADD})");
                intArray[i] = int.Parse(con.ReadLine());
            }

            // Find sum
            int sum = 0;
            for (int i = 0; i < NUMBERS_TO_ADD; i++)
            {
                sum += intArray[i];
            }

            con
                .WriteLine($"The sum of your input numbers is {
                    sum}, the max is {intArray.Max()}.");
        }
    }
}
