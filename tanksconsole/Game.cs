using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tanksconsole
{
    class Game
    {
        public Game()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.WriteLine("press key to start game");
            Console.ReadKey();
            Console.Clear();
            //write tick based tank game loop here

            //Constants.roomObjects[0].Draw(0);

            List<Entity> bricks = new List<Entity>();
            

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\marij\source\repos\tanksconsole\tanksconsole\1.txt");
            for(int i = 0; i < Constants.FIELD_SIZE; i++)
            {
                for (int y = 0; y < Constants.FIELD_SIZE; y++)
                {
                    if (lines[i][y] == '#')
                    {
                        bricks.Add(new Brick(y, i));
                    }
                    if (lines[i][y] == '@')
                    {
                        bricks.Add(new Water(y, i));
                    }
                    if (lines[i][y] == '%')
                    {
                        bricks.Add(new Base(y, i));
                    }
                }
            }

            DrawBorders();

            Constants.roomObjects.Add(new PlayerTank(13, 22));
            DrawAllList(bricks);

            Constants.roomObjects = Constants.roomObjects.Concat(bricks).ToList();
            
            Constants.roomObjects.Add(new EnemyTank(0, 0)); //initial enemy

            while (!Constants.gameOver)
            {
                while (!Console.KeyAvailable)
                {
                    if (Constants.gameOver)
                        break;

                    Thread.Sleep(20);
                    Constants.ticks++;

                    if (Constants.ticks % 3 == 0)
                        BulletsFly();

                    if (Constants.ticks % 200 == 0)
                        Constants.roomObjects.Add(new EnemyTank(Constants.rand.Next(0, 25), 0));

                    EnemiesStep();
                    EnemiesShoot();

                }

                if (Constants.gameOver)
                    break;

                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey(true);
                (Constants.roomObjects[0] as PlayerTank).Act(key);

            }
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
        private void EnemiesStep()
        {
            for (int i = 0; i < Constants.roomObjects.Count; i++)
            {
                if (Constants.roomObjects[i] is EnemyTank)
                {
                    (Constants.roomObjects[i] as EnemyTank).Step();

                }
            }
        }
        private void EnemiesShoot()
        {
            for (int i = 0; i < Constants.roomObjects.Count; i++)
            {
                if (Constants.roomObjects[i] is EnemyTank)
                {

                    (Constants.roomObjects[i] as EnemyTank).Shot();

                }
            }
        }
        
        private void BulletsFly()
        {
            for (int i = 0; i < Constants.roomObjects.Count; i++)
            {
                if (Constants.roomObjects[i] is Bullet)
                {
                    (Constants.roomObjects[i] as Bullet).Step();
                }
            }
        }
        
        private void DrawAllList(List<Entity> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw();
            }
        }
        
        private void DrawBorders()
        {
            for (int i = 0; i <= Constants.FIELD_SIZE; i++)
            {
                Console.SetCursorPosition(Constants.FIELD_SIZE, i);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(' ');
            }
            for (int i = 0; i < Constants.FIELD_SIZE; i++)
            {
                Console.SetCursorPosition(i, Constants.FIELD_SIZE);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(' ');
            }
            Console.BackgroundColor = ConsoleColor.Black;
            //fix borders
        }
    }
}
