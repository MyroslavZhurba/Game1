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

        public override void Rotate(Point[] pList)
        {
            if (pList[0].X == points[1].X)
            { 
                RotateHorisontal(pList);
            }
            else
            {
                RotateVertical(pList);
            }
        }

        private void RotateVertical(Point[] pList)
        {
            for (int i = 0; i < Length; ++i)
            {
                pList[i].X = points[0].X;
                pList[i].Y = points[0].Y + i;
            }
        }

        private void RotateHorisontal(Point[] pList)
        {
            for(int i = 0; i < Length; ++i)
            {
                pList[i].Y = pList[0].Y;
                pList[i].X = pList[0].X + i;
            }
        }
    }
}
