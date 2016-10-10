/* Write a method to calculate the distance between two points p1 {x1, y1} and p2 {x2, y2}.
 *  Write a program to read two points (given as two integers) and print the Euclidean distance between them */
using System;

namespace _04.DistanceBetweenPoints
{
    class DistanceBetweenPoints
    {
        static void Main()
        {
            Point pointA = ReadPoint();
            Point pointB = ReadPoint();

            Console.WriteLine(Point.GetDistanceBetweenTwoPoints(pointA, pointB));
        }

        public static Point ReadPoint()
        {
            string[] coords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  // read input
            return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
        }
    }

    class Point
    {
        private int X { get; }
        private int Y { get; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static double GetDistanceBetweenTwoPoints(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow((pointA.X - pointB.X), 2) + Math.Pow((pointA.Y - pointB.Y), 2));
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }

}
