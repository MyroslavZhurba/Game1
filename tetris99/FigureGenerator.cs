using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    class FigureGenerator
    {
        private int _x;
        private int _y;
        private char _c;

        private readonly Random _rand = new Random();
        public FigureGenerator(int x, int y , char c)
        {
            _x = x;
            _y = y;
            _c = c;
        }

        public Figure GetNewFigure()
        {
            switch(_rand.Next(0, 5))
            {
                case 0:
                    return new Square(_x, _y, _c);
                case 1:
                    return new Stick(_x, _y, _c);
                case 2:
                    return new TFigure(_x, _y, _c);
                case 3:
                    return new LFigure(_x, _y, _c);
            }
            return new SFigure(_x, _y, _c);
        }

    }

}
