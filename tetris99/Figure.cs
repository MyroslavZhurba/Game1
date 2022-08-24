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
                Drawer.DrawPoint(p.Y, p.X);
            }
        }

        internal Result TryMove(Direction dir)
        {
            Hide();
            Move(dir);
            var result = CheckPos();

            if (result!=Result.SUCCESS)
            { 
                Move(Reverse(dir));
                if (dir==Direction.Left || dir == Direction.Right)
                {
                    result = Result.BORDER_STOP;
                }
            }

            Draw();
            return result;
        }

        private Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    return Direction.Up;

                case Direction.Right:
                    return Direction.Left;

                case Direction.Left:
                    return Direction.Right;
            }
            return dir;
        }

        private Result CheckPos()
        {
            foreach (var p in points)
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

        internal bool IsOnTop()
        {
            if (points[0].Y == 0)
            {
                return true;
            }
            return false;
        }

        public void Move(Direction dir)
        {
            foreach (var p in points)
            {
                p.Move(dir);
            }
        }

        internal Result TryRotate()
        {
            Hide();
            Rotate();

            var result = CheckPos();
            if (result != Result.SUCCESS) 
            {
                for(int i = 0; i < 3; ++i)
                {
                    Rotate();
                }

                if (result == Result.HEAP_STOP)
                {
                    result = Result.BORDER_STOP;
                }
            }

            Draw();
            return result;
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                Drawer.HidePoint(p.Y,p.X);
            }
        }

        public abstract void Rotate();

    }
}
