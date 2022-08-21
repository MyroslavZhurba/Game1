using System;
using System.Threading;
using System.Timers;

namespace tetris99
{
    class Program
    {
        static FigureGenerator generator;
        static System.Timers.Timer timer;
        static Figure curF;
        static private Object _lockObject = new object();
        const int TIMER_INTERWAL=500;

        static void Main()
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);
            
            generator = new FigureGenerator(Field.Width/2, 0, Drawer.DEF_SYM);
            SetTimer();

            curF = generator.GetNewFigure();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Monitor.Enter(_lockObject);
                    var key = Console.ReadKey();
                    var result = HandleKey(key);

                    ProcessResult(ref curF, result);
                    Monitor.Exit(_lockObject);
                }
               
            }
        }

        private static void ProcessResult(ref Figure  curF, Result result)
        {
           if(result == Result.DOWN_BORDER_STOP || result == Result.HEAP_STOP)
           {
                Field.AddFigure(curF);
                Field.CheckLines();
                if (curF.IsOnTop())
                {
                    WriteGameOver();
                    timer.Elapsed -= OnTimedEvent;
                    return;
                }
                curF = generator.GetNewFigure();
           }
          
        }

        private static void WriteGameOver()
        {
            Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
            Console.Write("G A M E    O V E R");
        }

        private static Result HandleKey(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return curF.TryMove(Direction.Left);
                case ConsoleKey.RightArrow:
                    return curF.TryMove(Direction.Right);
                case ConsoleKey.DownArrow:
                    return curF.TryMove(Direction.Down);
                case ConsoleKey.Spacebar:
                    return curF.TryRotate();
            }
            return Result.SUCCESS;
        }

        private static void SetTimer()
        {
            
            timer = new System.Timers.Timer(TIMER_INTERWAL); 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = curF.TryMove(Direction.Down);
            ProcessResult(ref curF, result);
            Monitor.Exit(_lockObject);
        }
    }
}
