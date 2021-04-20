using System;

namespace caesar_cipher_igsr.helpers {
    public class CorrelationCoefficient {
        /// <summary>
        /// Calculate Correlation Coefficient
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <returns>Correlation</returns>
        public static double Calculate (double[] x, double[] y, int count) {

            double sumOfX = 0, sumOfY = 0, sumOfXY = 0, squaresumOfX = 0, squaresumOfY = 0;

            for (int i = 0; i < count; i++) {
                sumOfX = sumOfX + x[i];
                sumOfY = sumOfY + y[i];
                sumOfXY = sumOfXY + x[i] * y[i];
                squaresumOfX = squaresumOfX + x[i] * x[i];
                squaresumOfY = squaresumOfY + y[i] * y[i];
            }
            float partOne = (float) (count * sumOfXY - sumOfX * sumOfY);
            double partTwo = Math.Sqrt ((count * squaresumOfX - sumOfX * sumOfX) *
                (count * squaresumOfY - sumOfY * sumOfY));
            double correlation = partOne / partTwo;
            return correlation;
        }
    }
}