// MathMax
// Alias
using con = System.Console;

namespace MathMax
{
    class MathMax
    {
        static void Main(string[] args)
        {
            const int NUMBERS_TO_MAX = 3;

            double[] dubArray = new double[NUMBERS_TO_MAX];

            con.WriteLine("Welcome to MathMax.");

            // Collect user input
            for (int i = 0; i < NUMBERS_TO_MAX; i++)
            {
                con
                    .WriteLine($"Please enter a number: ({i + 1}/{
                        NUMBERS_TO_MAX})");
                dubArray[i] = double.Parse(con.ReadLine());
            }

            con
                .WriteLine($"The maximum of your input was {
                    Maximum(dubArray)}.");
        }

        static double Maximum(double[] inD)
        {
            double max = 0.0;
            for (int i = 0; i < inD.Length; i++)
            {
                if (inD[i] > max)
                {
                    max = inD[i];
                }
            }
            return max;
        }
    }
}
