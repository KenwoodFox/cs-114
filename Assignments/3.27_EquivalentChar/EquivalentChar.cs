// EquivalentChar 3.27
using System;

// Alias
using con = System.Console;

namespace EquivalentChar
{
    class EquivalentChar
    {
        static void Main(string[] args)
        {
            con
                .WriteLine("Enter as many characters as you like, use Ctrl+C to exit.\nThis program will print their integer representation for you.");

            while (true)
            {
                string uStr = con.ReadLine(); // Get a string
                foreach (char
                    c
                    in
                    uStr // Every char in that string
                )
                {
                    Console
                        .WriteLine($"The character {c} has the value {
                            ((int) c)}");
                }
                con
                    .WriteLine("Would you like to find the int value of a character? (y/n)");
            }
        }
    }
}
