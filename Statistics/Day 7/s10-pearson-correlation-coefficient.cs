using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace Statistics
{
    class s10_pearson_correlation_coefficient
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            double[] arX = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), arTemp => Double.Parse(arTemp, CultureInfo.InvariantCulture));
            double[] arY = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), arTemp => Double.Parse(arTemp, CultureInfo.InvariantCulture));

            double muX = CalcMean(n, arX);
            double muY = CalcMean(n, arY);

            double sigmaX = CaltStdDev(n, arX);
            double sigmaY = CaltStdDev(n, arY);

            double pc = 0d;

            for (int i = 0; i < n; i++)
            {
                pc += (arX[i] - muX) * (arY[i] - muY);
            }

            pc = pc / (n * sigmaX * sigmaY);
            Console.WriteLine("{0:F3}", pc );
        }

        static double CalcMean(int n, double[] ar)
        {
            double res = 0;
            res = Convert.ToDouble(ar.Sum()) / n;
            return res;
        }

        static double CaltStdDev(int n, double[] ar)
        {
            var mean = CalcMean(n, ar);
            var sqdist = new double[n];
            for (int i = 0; i < n; i++)
            {
                sqdist[i] = Math.Pow(ar[i] - mean, 2);
            }
            return Math.Sqrt(sqdist.Sum() / n);
        }
    }
}