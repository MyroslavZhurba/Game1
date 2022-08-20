using System;

namespace tetris99
{
    internal class Drawer
    {
        public const char DEF_SYM = '*';

        internal static void DrawPoint(int i, int j, char c = DEF_SYM)
        {
            Console.SetCursorPosition(j, i);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        internal static void HidePoint(int i, int j)
        {
            Console.SetCursorPosition(j, i);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }
    }
}