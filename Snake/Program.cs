using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Snake
{
    public enum Direction { Stop, Up, Down, Left, Right }

    internal class Program
    {
        private static Size size;
        private static Point head;
        private static Point point;
        private static bool lose;
        private static List<Point> tail;
        private static Direction direction;
        private static readonly Random random = new Random();

        private static void Main(string[] args)
        {
            Show();
            while (lose == false)
            {
                Draw();
                Move();
                Logica();
                Thread.Sleep(100);
            }
            End();
        }

        

        private static void Show()
        {
            lose = false;
            size = new Size(60, 30);
            tail = new List<Point>();
            direction = Direction.Stop;
            head = RandomPoint();
            point = RandomPoint();

            Console.Clear();
            Console.CursorVisible = false;
            

            for (var pos = 0; pos < size.Height; pos++)
            {
                if (pos == 0 || pos == size.Height - 1)
                {
                    $"o{new string('*', size.Width - 2)}o".Write(0, pos);
                }
                else
                {
                    $"*{new string(' ', size.Width - 2)}*".Write(0, pos);
                }
            }
        }

        private static void Draw()
        {
            for (var pos = 1; pos < size.Height - 1; pos++)
            {
                new string(' ', size.Width - 2).Write(1, pos);
            }


            head.Write("o");
            tail.Write("+");
            point.Write("1");

            $"Score: {tail.Count()}".Write(size.Width + 7, 2);
        }

        private static void Move()
        {
            if (!Console.KeyAvailable) 
            { 
                return;
            }

            var key = Console.ReadKey(false).Key;

            if (key == ConsoleKey.UpArrow) 
            { 
                direction = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow) 
            { 
                direction = Direction.Down;
            }
            else if (key == ConsoleKey.LeftArrow) 
            { 
                direction = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow) 
            { 
                direction = Direction.Right; 
            }
            else if (key == ConsoleKey.Escape) 
            { 
                direction = Direction.Stop; 
            }
        }

        private static void Logica()
        {
            if (direction == Direction.Stop) 
            {
                return; 
            }

            if (tail.Contains(head))
            {
                lose = true;
                direction = Direction.Stop;
                return;
            }

            tail.Add(head.Copy());

            if (head == point) 
            { 
                point = RandomPoint(); 
            }
            else 
            { 
                tail.RemoveFirst();
            }

            if (direction == Direction.Up)
            {
                if (head.Y - 1 < 1) 
                {
                    End();
                }
                else 
                { 
                    head.Y--;
                }
            }
            else if (direction == Direction.Down)
            {
                if (head.Y + 1 > size.Height - 2) 
                {
                    End();
                }
                else 
                {
                    head.Y++; 
                }
            }
            else if (direction == Direction.Left)
            {
                if (head.X - 1 < 1) 
                {
                    End(); 
                }
                else 
                { 
                    head.X--; 
                }
            }
            else if (direction == Direction.Right)
            {
                if (head.X + 1 > size.Width - 2) 
                {
                    End();
                }
                else 
                { 
                    head.X++; 
                }
            }
        }

        private static void End()
        {
            $"GAME OVER".Write(size.Width + 3, 3);
            $"Для повторной игры нажмите Enter".Write(size.Width + 3, 4);

            if (Console.ReadKey(true).Key == ConsoleKey.Enter) 
            {
                Show();
                while (lose == false)
                {
                    Draw();
                    Move();
                    Logica();
                    Thread.Sleep(100);
                }
                End();
            }
        }

        public static Point RandomPoint()
        {
            var x = random.Next(1, size.Width - 1);
            var y = random.Next(1, size.Height - 1);
            var point = new Point(x, y);

            if (tail.Contains(point) || head == point) 
            { 
                return RandomPoint(); 
            }
            else 
            { 
                return point; 
            }
        }
    }

    
}