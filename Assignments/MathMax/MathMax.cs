// MathMax
// Alias
using System.Collections.Generic;

using con = System.Console;

namespace MathMax
{
    class MathMax
    {
        static void Main(string[] args)
        {
            List<double> dubList = new List<double>();

            con
                .WriteLine(@"Welcome to
 __  __       _   _       __  __            
|  \/  | __ _| |_| |__   |  \/  | __ ___  __
| |\/| |/ _` | __| '_ \  | |\/| |/ _` \ \/ /
| |  | | (_| | |_| | | | | |  | | (_| |>  < 
|_|  |_|\__,_|\__|_| |_| |_|  |_|\__,_/_/\_\");

            // Collect user input
            try
            {
                while (true)
                {
                    con
                        .Write($"\nPlease enter a number (enter a non-number when done)\n: ");
                    dubList.Add(double.Parse(con.ReadLine()));
                }
            }
            catch (System.FormatException)
            {
                /* We end up here when exception is caught */
            }

            con.WriteLine($"The maximum of your input was {Maximum(dubList)}.");
        }

        static double Maximum(List<double> inD)
        {
            double max = 0.0;
            for (int i = 0; i < inD.Count; i++)
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
