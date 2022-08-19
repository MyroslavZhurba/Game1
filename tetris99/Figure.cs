using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    abstract class Figure
    {
        public const int Length = 4;
        public Point[] points = new Point[Length];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        private Point[] Clone()
        {
            var NewPoints = new Point[Length];
            for (int i = 0; i < Length; ++i)
            {
                NewPoints[i] = new Point(points[i]);
            }
            return NewPoints;
        }

        internal Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            var result = CheckPos(clone);
            if (result==Result.SUCCESS)
            {
                points = clone;
            }
            
            Draw();
            return result;
        }

        private Result  CheckPos(Point[] pList)
        {
            foreach (var p in pList)
            {
                if (p.Y >= Field.Height)
                {
                    return Result.DOWN_BORDER_STOP;
                }
                else if(p.X < 0 || p.X >= Field.Width || p.Y < 0 )
                {
                    return Result.BORDER_STOP;
                }
                else if(Field.CheckStrike(p))
                {
                    return Result.HEAP_STOP;
                }
            }
            return Result.SUCCESS;
        }

        public void Move(Point[] pList, Direction dir)
        {
            foreach (var p in pList)
            {
                p.Move(dir);
            }
        }

        internal Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            var result = CheckPos(clone);
            if (result == Result.SUCCESS) 
            {
                points = clone;
            }
            Draw();

            return result;
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.Hide();
            }
        }

        public abstract void Rotate(Point[] pList);

    }
}
