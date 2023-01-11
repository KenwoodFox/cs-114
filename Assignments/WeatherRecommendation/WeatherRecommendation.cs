// WeatherRecommendation
// Alias
using con = System.Console;

namespace WeatherRecommendation
{
    class WeatherRecommendation
    {
        static void Main(string[] args)
        {
            con
                .WriteLine(@"Welcome to
__        __         _   _               
\ \      / /__  __ _| |_| |__   ___ _ __ 
 \ \ /\ / / _ \/ _` | __| '_ \ / _ \ '__|
  \ V  V /  __/ (_| | |_| | | |  __/ |   
   \_/\_/ \___|\__,_|\__|_| |_|\___|_|");

            string uName = "";
            bool isRainy = false;
            bool isWindy = false;

            con.Write("\nPlease enter your name: ");
            uName = con.ReadLine();

            con.Write("Is it raining today (y/n)? ");
            isRainy = con.ReadLine() == "y" ? true : false; // Anything other than y is false

            con.Write("Is it windy today (y/n)? ");
            isWindy = con.ReadLine() == "y" ? true : false; // Anything other than y is false

            // Tell the user what the weather is like
            con.Write($"Hello {uName}\n"
            + $"Its {isRainy && isWindy? "windy and rainy" : isRainy ? "raining" : isWindy? "windy" : "neither rainy, nor windy"} today.\n");

            // Edge case
            if (isRainy && !(isWindy)){
                con.WriteLine("You should pack an umbrella.");
            }
        }
    }
}
