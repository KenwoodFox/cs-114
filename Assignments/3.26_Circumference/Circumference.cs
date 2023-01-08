// Circumference 3.26
using System;

// Alias
using con = System.Console;

namespace Circumference
{
    class Circumference
    {
        static void Main(string[] args)
        {
            con.WriteLine("Please enter radius (feet)");

            // Fetch user input
            double uIn = double.Parse(con.ReadLine());

            con.WriteLine($"Area of circle is: {Area(uIn):f2} sq. ft");
            con.WriteLine($"circumference is: {Circum(uIn):f2} ft");
        }

        static double Circum(double r)
        {
            return 2 * Math.PI * r;
        }

        static double Area(double r)
        {
            return Math.PI * Math.Pow(r, 2);
        }
    }
}
