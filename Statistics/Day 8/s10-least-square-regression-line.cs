using System;
using System.Collections.Generic;
using System.Linq;
namespace Statistics
{
    class s10_least_square_regression_line
    {
        public static void Solve()
        {
            int input = 80;

            int n = 5;
            double[] arX = new double[] { 95, 85, 80, 70, 60 };
            double[] arY = new double[] { 85, 95, 70, 65, 70 };

            var pc = CalcPearsonCoef(n, arX, arY);
            var stdevX = CalcStdDev(n, arX);
            var stdevY = CalcStdDev(n, arY);
            var meanX = CalcMean(n, arX);
            var meanY = CalcMean(n, arY);

            var b = pc * stdevY / stdevX;
            var a = meanY - b * meanX;

            var res = a + b * input;
            Console.WriteLine("{0:F3}", res);
        }
        static double CalcMean(int n, double[] ar)
        {
            double res = 0;
            res = ar.Sum() / n;
            return res;
        }
        static double CalcStdDev(int n, double[] ar)
        {
            var mean = CalcMean(n, ar);
            var sqdist = new double[n];
            for (int i = 0; i < n; i++)
            {
                sqdist[i] = Math.Pow(ar[i] - mean, 2);
            }
            return Math.Sqrt(sqdist.Sum() / n);
        }

        static double CalcPearsonCoef(int n, double[] arX, double[] arY)
        {
            double muX = CalcMean(n, arX);
            double muY = CalcMean(n, arY);

            double sigmaX = CalcStdDev(n, arX);
            double sigmaY = CalcStdDev(n, arY);

            double pc = 0d;

            for (int i = 0; i < n; i++)
            {
                pc += (arX[i] - muX) * (arY[i] - muY);
            }

            pc = pc / (n * sigmaX * sigmaY);
            return pc;
        }
    }
}