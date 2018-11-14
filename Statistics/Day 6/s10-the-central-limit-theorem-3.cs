using System;
namespace Statistics
{
    class s10_the_central_limit_theorem_3
    {
        public static void Solve()
        {
            double mu = 500d;
            double sigma = 80d;

            int n = 100;

            double z = 1.96d;

            double margin = z * sigma / Math.Sqrt(n);

            Console.WriteLine("{0:F2}", mu - margin);
            Console.WriteLine("{0:F2}", mu + margin);
        }
    }
}