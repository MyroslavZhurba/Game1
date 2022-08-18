using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    class Stick : Figure
    {
        
        public Stick(int x, int y , char sym)
        {
            for(int i = 0; i < points.Length; ++i)
            {
                points[i] = new Point(x, y++, sym);
            }
        }

        public override void Rotate()
        {
            if (points[0].x == points[1].x)
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
            for (int i = 0; i < points.Length; ++i)
            {
                points[i].x = points[0].x;
                points[i].y = points[0].y + i;
            }
        }

        private void RotateHorisontal()
        {
            for(int i = 0; i < points.Length; ++i)
            {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i;
            }
        }
    }
}
