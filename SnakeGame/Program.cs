using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(56, 25);
            SnakeGame snake = new SnakeGame();
            while (snake.IsAlive)
            {
                //Task clock;
                
                //Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                //snake.DrawSnake();
                snake.SnakeDraw();
                snake.Move();
                Thread.Sleep(120);
                if (Console.KeyAvailable)
                 {
                     ConsoleKeyInfo key = Console.ReadKey();

                     if (key.Key == ConsoleKey.RightArrow)
                         snake.Direction = 90;
                     if (key.Key == ConsoleKey.LeftArrow)
                        snake.Direction = 270;
                     if (key.Key == ConsoleKey.DownArrow)
                        snake.Direction = 180;
                     if (key.Key == ConsoleKey.UpArrow)
                        snake.Direction = 0;
                 }
                
            }
            Console.Clear();
            Console.WriteLine("Game over");
        }
    }
}
