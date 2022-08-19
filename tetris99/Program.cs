using System;
using System.Threading;

namespace tetris99
{
    class Program
    {
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Height, Field.Width);
            Console.SetBufferSize(Field.Height, Field.Width);

            generator = new FigureGenerator(20,0,'*');
            Figure curF = generator.GetNewFigure();
           
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(curF, key);
                    ProcessResult(ref curF, result);
                }
               
            }
            
            
            
            Console.ReadLine();
        }

        private static void ProcessResult(ref Figure  curF, Result result)
        {
           if(result == Result.DOWN_BORDER_STOP || result == Result.HEAP_STOP)
            {
                Field.AddFigure(curF);
                curF= generator.GetNewFigure();
           }
        }

        private static Result HandleKey(Figure cur_f, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return cur_f.TryMove(Direction.Left);
                case ConsoleKey.RightArrow:
                    return cur_f.TryMove(Direction.Right);
                case ConsoleKey.DownArrow:
                    return cur_f.TryMove(Direction.Down);
                case ConsoleKey.Spacebar:
                    return cur_f.TryRotate();
            }
            return Result.SUCCESS;
        }

    }
}
