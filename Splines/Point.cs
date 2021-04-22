using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splines
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point a) => a;
        public static Point operator +(Point a, Point b)
        {
            if (a == null && b == null)
            {
                return null;
            }
            else if (a == null && b != null)
            {
                return b;
            }
            else if (a != null && b == null)
            {
                return a;
            }
            else
            {
                return new Point(a.X + b.X, a.Y + b.Y);
            }
        }
        public static Point operator -(Point a)
        {
            if (a == null)
            {
                return null;
            }

            return new Point(-a.X, -a.Y);
        }
        public static Point operator -(Point a, Point b) => a + (-b);
        public static Point operator *(Point a, double b)
        {
            if (b == 0)
            {
                return null;
            }

            if (a == null)
            {
                return null;
            }

            return new Point(a.X * b, a.Y * b);
        }

        public static Point operator *(double b, Point a) => a * b;
        public static Point operator /(Point a, double b) => new Point(a.X / b, a.Y / b);
    }
}
