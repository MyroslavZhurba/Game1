using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }

        public Point(int a, int b, char sym)
        {
            X = a;
            Y = b;
            C = sym;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }

        internal void Move(Direction dir)
        {
           switch (dir)
           {
                case Direction.Down:
                    Y++;
                    break;

                case Direction.Left:
                    X--;
                    break;

                case Direction.Right:
                    X++;
                    break;

                case Direction.Up:
                    Y--;
                    break;
           }
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        
    }
}
