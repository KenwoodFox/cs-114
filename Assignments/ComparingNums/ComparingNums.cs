// ComparingNums
// Alias
using con = System.Console;

namespace ComparingNums
{
    class ComparingNums
    {
        static void Main(string[] args)
        {
            // Store our incoming user input
            CompInput userInput = new CompInput();

            con.WriteLine("Welcome to comparing nums!");

            con.WriteLine("Please enter a number: ");
            userInput.num1 = int.Parse(con.ReadLine());
            con.WriteLine("Please enter another number: ");
            userInput.num2 = int.Parse(con.ReadLine());

            // If tree
            if (userInput.num1 == userInput.num2){
                con.WriteLine("Both inputs are identical");
            } else {
                con.WriteLine($"Your {userInput.num1 > userInput.num2 ? "first" : "second"} number was bigger. ({userInput.num1}{userInput.num1 > userInput.num2 ? " is greater than " : " is less than "}{userInput.num2})");
            }
        }
    }

    public struct CompInput
    {
        // Class storage for user input
        public int num1;

        public int num2;
    }
}
