namespace tetris99
{
    internal interface IRotateToDir
    {
        public Direction RotateDirection();

        public void RotateRight();

        public void  RotateUp();

        public void RotateLeft();

        public void RotateDown();
    }
}