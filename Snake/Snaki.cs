using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Snaki
    {
        public static void RemoveFirst<T>(this List<T> list)
        {
            if (list.Any())
            {
                list.Remove(list.First());
            }
        }

        public static void RemoveLast<T>(this List<T> list)
        {
            if (list.Any())
            {
                list.Remove(list.Last());
            }
        }

        public static Point Copy(this Point point)
        {
            return new Point(point.X, point.Y);
        }

        public static void Write(this IEnumerable<Point> points, string text)
        {
            foreach (var point in points)
            {
                Write(text, point.X, point.Y);
            }
        }

        public static void Write(this IEnumerable<Point> points, string text, ConsoleColor foreground, ConsoleColor background)
        {
            foreach (var point in points)
            {
                Write(text, point.X, point.Y, foreground, background);
            }
        }

        public static void Write(this Point point, string text)
        {
            Write(text, point.X, point.Y);
        }

        public static void Write(this Point point, string text, ConsoleColor foreground, ConsoleColor background)
        {
            Write(text, point.X, point.Y, foreground, background);
        }

        public static void Write(this string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void Write(this string text, int x, int y, ConsoleColor foreground, ConsoleColor background)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
