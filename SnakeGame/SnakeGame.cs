using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeGame
    {
        public bool IsAlive { get; set; }
        public int Direction { get; set; }

        public Random random = new Random();
        public List<List<int>> SnakeParts { get; set; }
        public List<int> Food { get; set; }
        public SnakeGame()
        {
            SnakeParts = new List<List<int>>();

            Food = new List<int>()
            {
                0,0
            };

            RespawnFood();

            int snakeX = random.Next(1, 10);
            int snakeY = random.Next(1, 10);

            for (int i = 4; i > 0; i--)     //Initalize snake position
            {
                SnakeParts.Add(new List<int> { snakeX + i, snakeY });
            }

            IsAlive = true;
            Direction = 90;
        }

       

        public void SnakeDraw()
        {
            if (SnakeParts[0][0] == Food[0] && SnakeParts[0][1] == Food[1])
            {

                if (Direction == 90)
                {
                    int EndX = SnakeParts[SnakeParts.Count - 1][0] + 1;
                    int EndY = SnakeParts[SnakeParts.Count - 1][1];
                    SnakeParts.Add(new List<int> { EndX, EndY });
                    RespawnFood();
                }

                if (Direction == 180)
                {
                    int EndX = SnakeParts[SnakeParts.Count - 1][0];
                    int EndY = SnakeParts[SnakeParts.Count - 1][1] + 1;
                    SnakeParts.Add(new List<int> { EndX, EndY });
                    RespawnFood();
                }

                if (Direction == 0)
                {
                    int EndX = SnakeParts[SnakeParts.Count - 1][0];
                    int EndY = SnakeParts[SnakeParts.Count - 1][1] - 1;
                    SnakeParts.Add(new List<int> { EndX, EndY });
                    RespawnFood();
                }

                if (Direction == 270)
                {
                    int EndX = SnakeParts[SnakeParts.Count - 1][0] - 1;
                    int EndY = SnakeParts[SnakeParts.Count - 1][1];
                    SnakeParts.Add(new List<int> { EndX, EndY });
                    RespawnFood();

                }
            }
            foreach (List<int> subList in SnakeParts)
            {
                draw(subList[0], subList[1], ConsoleColor.Blue);
            }
            draw(Food[0], Food[1], ConsoleColor.Red);
            
        }

        public void RespawnFood()
        {

            Food[0] = random.Next(1, 25);
            Food[1] = random.Next(1, 25);
        }

        public void draw(int X, int Y, ConsoleColor Color)
        {
            Console.CursorLeft = X * 2; // To use up less horizontal space, we draw each block as 2 characters
            Console.CursorTop = Y;
            Console.ForegroundColor = Color;
            //Console.Write("██");
            Console.Write("██");
        }
        /*
        public void DrawSnake()
        {
            for (int i = 0; i < SnakeLength; i++)
            {
                draw(SnakeX, SnakeY + i, ConsoleColor.Blue);
            }
        }
        */

        public void CheckCollision()
        {
            if (SnakeParts[0][0] == 0 || SnakeParts[0][1] == 0)
            {
                // Console.Clear();
                IsAlive = false;

            }
            // (80, 25);
            if (SnakeParts[0][0] == 28 || SnakeParts[0][1] == 25)
            {
                // Console.Clear();
                IsAlive = false;

            }


            for (int i = 1; i < SnakeParts.Count; i++)
            {
                if (SnakeParts[0][0] == SnakeParts[i][0] && SnakeParts[0][1] == SnakeParts[i][1])
                {
                    // Console.Clear();
                    IsAlive = false;

                }
            }
        }
        public void Move()
        {
            
            if (Direction == 90)
            {
                int HeadX = SnakeParts[0][0] + 1;
                int HeadY = SnakeParts[0][1];
                SnakeParts.Insert(0, (new List<int> { HeadX, HeadY }));
                CheckCollision();
                SnakeParts.RemoveAt(SnakeParts.Count - 1);
            }

            if (Direction == 180)
            {
                int HeadX = SnakeParts[0][0];
                int HeadY = SnakeParts[0][1] + 1;
                SnakeParts.Insert(0, (new List<int> { HeadX, HeadY }));
                CheckCollision();
                SnakeParts.RemoveAt(SnakeParts.Count - 1);

            }

            if (Direction == 0)
            {
                int HeadX = SnakeParts[0][0];
                int HeadY = SnakeParts[0][1] -1;
                SnakeParts.Insert(0, (new List<int> { HeadX, HeadY }));
                CheckCollision();
                SnakeParts.RemoveAt(SnakeParts.Count - 1);

            }

            if (Direction == 270)
            {
                int HeadX = SnakeParts[0][0] - 1;
                int HeadY = SnakeParts[0][1];
                SnakeParts.Insert(0, (new List<int> { HeadX, HeadY }));
                CheckCollision();
                SnakeParts.RemoveAt(SnakeParts.Count - 1);

            }


        }


        
    }
    
}

