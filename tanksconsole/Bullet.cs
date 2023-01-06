using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class Bullet : MovableObject
    {
        protected int steps;
        protected int maxSteps = 0;
        public Bullet(int x, int y, Constants.Direction dir)
        {
            this.x = x;
            this.y = y;
            icon.Add(new Icon('.', ConsoleColor.White, ConsoleColor.Black));
            direction = dir;
            steps = 0;
        }

        public Entity CollisionObj(int x, int y, Constants.Direction dir)
        {
            for (int i = 0; i < Constants.roomObjects.Count; i++)
            {
                switch (dir)
                {
                    case Constants.Direction.Up:
                        if (Constants.roomObjects[i].GetY() == y - 1 && Constants.roomObjects[i].GetX() == x)
                        {
                            return Constants.roomObjects[i];
                        }
                        if (y < 1)
                            return new EmptySpace(x, y);
                        break;
                    case Constants.Direction.Right:
                        if (Constants.roomObjects[i].GetX() == x + 1 && Constants.roomObjects[i].GetY() == y)
                        {
                            return Constants.roomObjects[i];
                        }
                        if (x > Constants.FIELD_SIZE - 2)
                            return new EmptySpace(x, y);
                        break;
                    case Constants.Direction.Down:
                        if (Constants.roomObjects[i].GetY() == y + 1 && Constants.roomObjects[i].GetX() == x)
                        {
                            return Constants.roomObjects[i];
                        }
                        if (y > Constants.FIELD_SIZE - 2)
                            return new EmptySpace(x, y);
                        break;
                    case Constants.Direction.Left:
                        if (Constants.roomObjects[i].GetX() == x - 1 && Constants.roomObjects[i].GetY() == y)
                        {
                            return Constants.roomObjects[i];
                        }
                        if (x < 1)
                            return new EmptySpace(x, y);
                        break;
                    default:
                        break;
                }
            }
            return new EmptySpace(x, y);
        }
        public void Step()
        {

            if (Collision(x, y, direction) == Constants.CollisionType.Tank)
            {
                for (int i = 0; i < Constants.roomObjects.Count; i++)
                {
                    if (Constants.roomObjects[i] is Tank)
                    {

                        if ((Constants.roomObjects[i] as Tank).Collision(Constants.roomObjects[i].GetX(), Constants.roomObjects[i].GetY(), OppositeDirection(), Constants.CollisionType.Bullet) == Constants.CollisionType.Bullet)
                        {

                            if ((Constants.roomObjects[i] is PlayerTank && this is EnemyBullet) ||
                            (Constants.roomObjects[i] is EnemyTank && !(this is EnemyBullet)))
                            {
                                if (!(Constants.roomObjects[i] is PlayerTank))
                                    Constants.roomObjects[i].Destroy();
                                else
                                    if (Near(Constants.roomObjects[i]))
                                    Constants.roomObjects[i].Destroy();

                            }
                            Destroy();
                            return;
                        }
                    }
                }
            }

            if (steps > 0)
            {
                EmptySpace empty = new EmptySpace(x, y);
                empty.Draw(0);

            }
            steps++;
            switch (direction)
            {
                case Constants.Direction.Up:
                    if (Collision(x, y, direction) == Constants.CollisionType.NoCollision)
                        y--;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                case Constants.Direction.Right:
                    if (Collision(x, y, direction) == Constants.CollisionType.NoCollision)
                        x++;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                case Constants.Direction.Down:
                    if (Collision(x, y, direction) == Constants.CollisionType.NoCollision)
                        y++;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                case Constants.Direction.Left:
                    if (Collision(x, y, direction) == Constants.CollisionType.NoCollision)
                        x--;
                    else
                    {
                        if (CollisionObj(x, y, direction) is Bullet)
                            CollisionObj(x, y, direction).Destroy();
                        Destroy();
                        return;
                    }
                    break;
                default:
                    throw new Exception("Bullet step error.");
            }
            Draw();
        }
    }
}