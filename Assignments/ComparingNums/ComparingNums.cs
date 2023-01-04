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

            // Iff tree
            if (userInput.num1 > userInput.num2)
            {
                con
                    .WriteLine($"Your first number was bigger. ({
                        userInput.num1}>{userInput.num2})");
            }
            else if (userInput.num1 < userInput.num2)
            {
                con
                    .WriteLine($"Your second number was bigger. ({
                        userInput.num1}<{userInput.num2})");
            }
            else
            {
                con
                    .WriteLine($"Both numbers are evaluated the same. ({
                        userInput.num1}=={userInput.num2})");
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
