using System;
using System.Collections.Generic;
using System.Text;


namespace tetris99
{ 
    static class Field
    {
        private static int _width = 20;
        private static int _height = 15;
        private static bool[,] _heap = new bool[Height, Width];
        
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(Field.Height, value);
                Console.SetBufferSize(Field.Height, value);
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
                Console.SetWindowSize(value, Field.Width) ;
                Console.SetBufferSize(value, Field.Width);
            }
        }

        internal static bool CheckStrike(Point p)
        {
            return _heap[p.Y, p.X];
        }

        internal static void CheckLines()
        {
            for (int i =Field.Height-1;i>=0;i--)
            {
                bool full = true;
                for (int j = 0; j < Field.Width; j++)
                {
                    if (!_heap[i,j])
                    {
                        full = false;
                        break;
                    }
                }
                if (full)
                {
                    DeleteLine(i);
                    DropLines(i);

                    Redraw();
                    CheckLines();
                    break;
                }
            }
        }

        private static void DropLines(int line)
        {
            for(int j = 0; j < Field.Width; ++j)
            {
                int curSpace = LowestSpace(j, line + 1);

                for(int i = line; i >= 0; i--)
                {
                    if (!_heap[i, j])
                    {
                        continue;
                    }

                    _heap[i, j] = false;
                    _heap[curSpace, j] = true;
                    curSpace--;
                }
            }
        }

        private static int LowestSpace(int x, int y)
        {
            while(y<Field.Height && !_heap[y, x])
            {
                y++;
            }
            return y - 1;
        }

        private static void Redraw()
        {
           for(int i = 0; i < Field.Height; ++i)
            {
                for(int j = 0; j < Field.Width; ++j)
                {
                    if (_heap[i, j])
                    {
                        Drawer.DrawPoint(i, j);
                    }
                    else
                    {
                        Drawer.HidePoint(i, j);
                    }
                }
            }
        }

        private static void DeleteLine(int line)
        {
            for (int i = line; i >= 0; i--)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (i == 0)
                    {
                        _heap[i, j] = false;
                    }
                    else
                    {
                        _heap[i, j] = _heap[i - 1, j];
                    }
                }
            }
        }

        internal static void AddFigure(Figure curF)
        {
             foreach (var p in curF.points)
             {
                _heap[p.Y, p.X] = true;
             }
        }
    }
}
