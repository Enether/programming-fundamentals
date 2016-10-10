/*
 Write a program to read two rectangles {left, top, width, height} and print whether the first is inside the second.
The input is given as two lines, each holding a rectangle, described by 4 integers: left, top, width and height.
 */
using System;
using System.Linq;

namespace _06.RectanglePosition
{
    class RectanglePosition
    {
        static void Main()
        {
            Rectangle rectA = ReadRectangle();
            Rectangle rectB = ReadRectangle();

            string result = Rectangle.IsInside(rectA, rectB) ? "Inside" : "Not inside";
            Console.WriteLine(result);
        }

        static Rectangle ReadRectangle()
        {
            int[] rectangleCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Point top = new Point(rectangleCoordinates[0], rectangleCoordinates[1]);  // top right coordinates
            int width = rectangleCoordinates[2];
            int height = rectangleCoordinates[3];
            Point bot = new Point(top.X + width, top.Y + height);

            return new Rectangle(top, bot);
        }

    }

    class Rectangle
    {
        public Point topLeft { get; }
        public Point bottomRight { get; }

        public Rectangle(Point top, Point bot)
        {
            this.topLeft = top;
            this.bottomRight = bot;
        }

        public static bool IsInside(Rectangle rectA, Rectangle rectB)
        {
            // Checks whether rectA is inside rectB
            return (rectA.topLeft.X >= rectB.topLeft.X && rectA.bottomRight.X <= rectB.bottomRight.X)
                && (rectA.topLeft.Y <= rectB.topLeft.Y && rectA.bottomRight.Y <= rectB.bottomRight.Y);
        }
    }

    class Point
    {
        public int X;
        public int Y;

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
