using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splines
{
    public static class Spline
    {
        public static Point Bezier(double t, Point[] b, int polynomialDegree)
        {
            Point a = new Point(0, 0);

            for (int i = 0; i < b.Length; i++)
            {
                a += BernsteinPolynomial(t, i, polynomialDegree) * b[i];
            }

            return a;
        }

        public static double BernsteinPolynomial(double t, int i, int polynomialDegree)
        {
            return binomialCoeff(polynomialDegree, i) * Math.Pow(t, i) * Math.Pow(1 - t, polynomialDegree - i);
        }

        public static Point CatmullRom(double t, Point[] points, int k = 0)
        {
            int p0, p1, p2, p3;
            p1 = (int)t + 1;
            p2 = p1 + 1;
            p3 = p2 + 1;
            p0 = p1 - 1;

            t = t - (int)t;

            double tt = t * t;
            double ttt = tt * t;

            double q1 = -ttt + 2.0d * tt - t;
            double q2 = 3.0d * ttt - 5.0d * tt + 2.0d;
            double q3 = -3.0d * ttt + 4.0d * tt + t;
            double q4 = ttt - tt;

            return 0.5d * (points[p0] * q1 + points[p1] * q2 + points[p2] * q3 + points[p3] * q4);
        }

        public static int binomialCoeff(int n, int k)
        {
            int res = 1;

            // Since C(n, k) = C(n, n-k)
            if (k > n - k)
                k = n - k;

            // Calculate value of [n * ( n - 1) *---* (
            // n - k + 1)] / [k * (k - 1) *----* 1]
            for (int i = 0; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            return res;
        }

        public static Point OpenUniformBSpline(double t, Point[] points, int k)
        {
            Point a = null;
            double[] knotVectors = CreateOpenUniformKnotVectors(points.Length - 1, k);

            for (int i = 0; i < points.Length; i++)
            {
                double basis = BasisBSplineFunction(t, i, k, knotVectors);

                a += basis * points[i];
            }

            return a;
        }

        public static double BasisBSplineFunction(double t, int i, int j, double[] knot)
        {
            if (j == 0)
            {
                if (knot[i] <= t && t < knot[i + 1])
                    return 1;
                else
                    return 0;
            }

            double factorOne, factorTwo;

            factorOne = (t - knot[i]) / (knot[i + j] - knot[i]);
            factorTwo = (knot[i + j + 1] - t) / (knot[i + j + 1] - knot[i + 1]);

            if (!double.IsNormal(factorOne))
                factorOne = 0;

            if (!double.IsNormal(factorTwo))
                factorTwo = 0;

            if (factorOne == 0 && factorTwo == 0)
                return 0;

            double result = factorOne * BasisBSplineFunction(t, i, j - 1, knot) + factorTwo * BasisBSplineFunction(t, i + 1, j - 1, knot);

            return result;
        }


        public static double[] CreateUniformKnotVectors(int m)
        {
            double[] vector = new double[m + 1];
            for (int i = 0; i < m + 1; i++)
            {
                vector[i] = i;
            }

            return vector;
        }

        public static double[] CreateOpenUniformKnotVectors(int n, int k)
        {
            int m = k + n + 1;

            double[] vector = new double[m + 1];
            int counter = 0;
            for (int i = k; i < m + 1; i++)
            {
                vector[i] = counter;

                if (counter < n + 1 - k)
                    counter++;
            }

            return vector;
        }
    }
}
