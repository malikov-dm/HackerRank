using System;

namespace _30_Days_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 4;
            double d = 4.0;
            string s = "HackerRank ";

            // Declare second integer, double, and String variables.

            // Read and save an integer, double, and String to your variables.

            // Print the sum of both integer variables on a new line.

            // Print the sum of the double variables on a new line.

            // Concatenate and print the String variables on a new line
            // The 's' variable above should be printed first.

            int inpi = Convert.ToInt32(Console.ReadLine());
            double inpd = Convert.ToDouble(Console.ReadLine());
            string inps = Console.ReadLine();

            Console.WriteLine("{0}", i + inpi);
            Console.WriteLine("{0:F1}", d + inpd);
            Console.WriteLine("{0}{1}", s, inps);
        }
    }
}
