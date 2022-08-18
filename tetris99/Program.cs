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


            int steps = 10;

            for(int i = 0; i < 5; ++i)
            {
                Figure f = generator.GetNewFigure();
                for(int j = 0; j < steps; ++j)
                {
                    f.Draw();
                    Thread.Sleep(500);
                    f.Hide();
                    f.Move(Direction.Down);
                    f.Draw();

                }
            }

           /* foreach(Figure fig  in f)
            {
                fig.Draw();
                Thread.Sleep(500);
                fig.Hide();
                fig.Rotate();
                fig.Draw();
                fig.Hide();
                fig.Move(Direction.Left);
                fig.Draw(); 
            }*/
            
            Console.ReadLine();
        }

        static void Fall(Figure f)
        {

        }

       
    }
}
