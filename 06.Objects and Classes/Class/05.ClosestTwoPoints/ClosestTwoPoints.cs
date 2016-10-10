/* Write a program to read n points and find the closest two of them. */
using System;

namespace _05.ClosestTwoPoints
{
    class ClosestTwoPoints
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Point[] coordinates = new Point[n];
            // Fill array with coordinates
            for (int i = 0; i < n; i++)
            {
                coordinates[i] = ReadPoint();
            }

            int minPointAIndex = -1;
            int minPointBIndex = -1;
            double minDistance = double.MaxValue;
            for (int pointAIndex = 0; pointAIndex < coordinates.Length; pointAIndex++)
            {
                Point pointA = coordinates[pointAIndex];

                for (int pointBIndex = pointAIndex + 1; pointBIndex < coordinates.Length; pointBIndex++)
                {
                    Point pointB = coordinates[pointBIndex];
                    double distance = Point.GetDistanceBetweenTwoPoints(pointA, pointB);
                    if(distance < minDistance)
                    {
                        minDistance = distance;
                        minPointAIndex = pointAIndex;
                        minPointBIndex = pointBIndex;
                    }
                }
            }

            Console.WriteLine("{0:F3}", minDistance);
            Console.WriteLine(coordinates[minPointAIndex]);
            Console.WriteLine(coordinates[minPointBIndex]);
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
