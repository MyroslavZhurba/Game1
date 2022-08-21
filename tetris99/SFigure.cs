using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    class SFigure : Figure
    {
        public SFigure(int x, int y, char sym)
        {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x-1, y, sym);
            points[2] = new Point(x-1, y+1, sym);
            points[3] = new Point(x-2, y+1, sym);
            Draw();
        }

        public override void Rotate()
        {
            if (points[0].Y == points[1].Y)
            {
                RotateVertical();
            }
            else
            {
                RotateHorisontal();
            }
        }

        private void RotateVertical()
        {
            points[2].X = points[0].X;
            points[2].Y = points[0].Y;
            points[3].X = points[2].X;
            points[3].Y = points[2].Y + 1;
            points[0].X = points[1].X;
            points[0].Y = points[1].Y - 1;
        }

        private void RotateHorisontal()
        {
            points[0].X = points[2].X;
            points[0].Y = points[2].Y;
            points[2].X = points[1].X;
            points[2].Y = points[1].Y + 1;
            points[3].X = points[2].X - 1;
            points[3].Y = points[2].Y;
        }
    }
}

