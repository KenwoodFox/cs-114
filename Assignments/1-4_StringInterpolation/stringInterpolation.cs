// String interpolation

// Alias
using con = System.Console;

namespace HelloWorld
{
    class Hello {
        static void Main(string[] args)
        {
            string myString;

            con.WriteLine("Welcome to the program. Please enter a string: ");
            myString = con.ReadLine(); // Read a string from console

            con.WriteLine($"Your string was \"{myString}\""); // Print that string back out
        }
    }
}
