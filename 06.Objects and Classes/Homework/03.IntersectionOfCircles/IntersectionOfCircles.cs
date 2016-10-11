/*
 Create class Circle with properties Center and Radius. 
 The center is a point with coordinates X and Y (make a class Point). 
 Write a method bool Intersect(Circle c1, Circle c2) that tells whether the two given circles intersect or not.
 Write a program that tells if two circles intersect.
The input lines will be in format: {X} {Y} {Radius}. Print as output “Yes” or “No”.
 */
using System;
using System.Linq;

namespace _03.IntersectionOfCircles
{
    class IntersectionOfCircles
    {
        static void Main()
        {
            int[] circAInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] circBInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Circle circA = new Circle(
                new Point(circAInfo[0], circAInfo[1]),
                circAInfo[2]);

            Circle circB = new Circle(
                new Point(circBInfo[0], circBInfo[1]),
                circBInfo[2]);

            string result = DoIntersect(circA, circB) ? "Yes" : "No";
            Console.WriteLine(result);
        }

        static bool DoIntersect(Circle circA, Circle circB)
        {
            // This method returns a boolean indicating if two circles intersect
            bool doIntersect = false;
            if (Math.Sqrt(Math.Pow(circB.Center.X - circA.Center.X, 2) + Math.Pow(circB.Center.Y - circA.Center.Y, 2)) 
                <= circA.Radius + circB.Radius)
                doIntersect = true;

            return doIntersect;
        }
    }

    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Circle(Point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
    }

    class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
