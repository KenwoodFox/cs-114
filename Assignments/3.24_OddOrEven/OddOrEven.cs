// OddOrEven 3.24
// Alias
using con = System.Console;

namespace OddOrEven
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            con.WriteLine("Enter an integer:");

            // Fetch user input
            int uIn = int.Parse(con.ReadLine());

            // The omission of "an odd" in "odd" is on purpose.
            con.WriteLine($"{uIn} is {uIn % 2 == 0 ? "an even":"odd"} number\n");
        }
    }
}
