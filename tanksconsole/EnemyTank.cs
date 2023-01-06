using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class EnemyTank : Tank
    {
        public EnemyTank(int x, int y) : base(x, y)
        {
            icon.Add(new Icon('▲', ConsoleColor.Red, ConsoleColor.DarkGray));
            icon.Add(new Icon('►', ConsoleColor.Red, ConsoleColor.DarkGray));
            icon.Add(new Icon('▼', ConsoleColor.Red, ConsoleColor.DarkGray));
            icon.Add(new Icon('◄', ConsoleColor.Red, ConsoleColor.DarkGray));
            direction = Constants.Direction.Up;
            Draw(3);
            moveTime = Constants.ticks;
        }

        public void Shot()
        {
            if (Constants.ticks - shotTime > Constants.SHOT_SPEED * 2)
            {
                shotTime = Constants.ticks;
                EnemyBullet bullet = new EnemyBullet(x, y, direction);
                Constants.roomObjects.Add(bullet);
            }
        }

        public void Step()
        {
            if (Constants.ticks - moveTime > Constants.MOVE_SPEED * 3)
            {
                moveTime = Constants.ticks;

                Constants.Direction dir;
                if (Constants.rand.Next(1, 3) == 1)
                    dir = RandomDirection();
                else
                {
                    if (Collision(x, y, direction) != Constants.CollisionType.NoCollision)
                        dir = RandomDirection();
                    else
                        dir = direction;
                }


                EmptySpace empty = new EmptySpace(x, y);
                empty.Draw(0);
                SetDirection(dir);

                switch (dir)
                {
                    case Constants.Direction.Up:
                        if (Collision(x, y, dir) == Constants.CollisionType.NoCollision)
                            y--;
                        break;
                    case Constants.Direction.Right:
                        if (Collision(x, y, dir) == Constants.CollisionType.NoCollision)
                            x++;
                        break;
                    case Constants.Direction.Down:
                        if (Collision(x, y, dir) == Constants.CollisionType.NoCollision)
                            y++;
                        break;
                    case Constants.Direction.Left:
                        if (Collision(x, y, dir) == Constants.CollisionType.NoCollision)
                            x--;
                        break;
                    default:
                        throw new Exception("Tank step error.");
                }
                UpdateIcon();
                this.Draw(numIcon);
            }


        }

    }
}
