// String interpolation

// Alias
using con = System.Console;

namespace HelloWorld
{
    class Hello {
        static void Main(string[] args)
        {
            string userString;
            const string person = "Jamila";

            con.WriteLine("Welcome to the program.\n\n");

            con.WriteLine($"Hello I am {person}");
            con.WriteLine("Please enter your name: ");
            userString = con.ReadLine(); // Read a string from console

            con.WriteLine($"Hello {person} {userString}"); // Print that string back out
        }
    }
}
