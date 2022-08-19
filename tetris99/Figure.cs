using System;
using System.Collections.Generic;
using System.Text;

namespace tetris99
{
    abstract class Figure
    {
        public const int Length = 4;
        protected Point[] points = new Point[Length];

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

        internal void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (CheckPos(clone))
            {
                points = clone;
            }
            Draw();
        }

        private bool CheckPos(Point[] pList)
        {
            foreach(var p in pList)
            {
                if(p.x < 0 || p.x >= 40 || p.y < 0 || p.y >= 30)
                {
                    return false;
                }
            }
            return true;
        }

        public void Move(Point[] pList, Direction dir)
        {
            foreach (var p in pList)
            {
                p.Move(dir);
            }
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.Hide();
            }
        }

        public abstract void Rotate();


    }
}
