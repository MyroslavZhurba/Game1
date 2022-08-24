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

        public Point(int a, int b, char sym)
        {
            X = a;
            Y = b;
            C = sym;
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
    }
}
