using System;
using System.Threading;

namespace tetris99
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20,0,'*');
            Figure cur_f = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(cur_f, key);
                }
            }
            
            
            Console.ReadLine();
        }

        private static void HandleKey(Figure cur_f, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    cur_f.TryMove(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    cur_f.TryMove(Direction.Right);
                    break;
                case ConsoleKey.DownArrow:
                    cur_f.TryMove(Direction.Down);
                    break;
            }
        }

    }
}
