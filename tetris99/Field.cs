using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    static class Field
    {
        private static int _width = 40;
        private static int _height = 30;
        public static int Width
       {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(value, Field.Height);
                Console.SetBufferSize(value, Field.Height);
            }
       }
        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                Console.SetWindowSize(Field.Width, value) ;
                Console.SetBufferSize(Field.Width, value);
            }
        }

        private static bool[,] _heap;

       static Field()
        {
            _heap = new bool[Height, Width];
        }

        internal static bool CheckStrike(Point p)
        {
            return _heap[p.X, p.Y];
        }

        internal static void AddFigure(Figure curF)
        {
             foreach (var p in curF.points)
            {
                _heap[p.X, p.Y] = true;
            }
        }
    }
}
