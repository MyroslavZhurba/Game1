using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    class Stick : Figure
    {
        
        public Stick(int x, int y , char sym)
        {
            for(int i = 0; i < Length; ++i)
            {
                points[i] = new Point(x, y++, sym);
            }
            Draw();
        }

        public override void Rotate()
        {
            if (points[0].X == points[1].X)
            { 
                RotateHorisontal();
            }
            else
            {
                RotateVertical();
            }
        }

        private void RotateVertical()
        {
            for (int i = 0; i < Length; ++i)
            {
                points[i].X = points[0].X;
                points[i].Y = points[0].Y + i;
            }
        }

        private void RotateHorisontal()
        {
            for(int i = 0; i < Length; ++i)
            {
                points[i].Y = points[0].Y;
                points[i].X = points[0].X + i;
            }
        }
    }
}
