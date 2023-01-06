using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class Tank : MovableObject
    {
        public long shotTime;
        public long moveTime;



        public Constants.Direction GetDirection()
        {
            return direction;
        }

        public Tank()
        {
            throw new Exception("No tank coordinates.");
        }

        public Tank(int x, int y)
        {
            this.x = x;
            this.y = y;
            direction = Constants.Direction.Down;
        }

        public void Shot()
        {
            if (Constants.ticks - shotTime > Constants.SHOT_SPEED)
            {
                shotTime = Constants.ticks;
                Bullet bullet = new Bullet(x, y, direction);
                Constants.roomObjects.Add(bullet);
            }
        }

        protected void UpdateIcon()
        {
            switch (direction)
            {
                case Constants.Direction.Up:
                    numIcon = 0;
                    break;
                case Constants.Direction.Right:
                    numIcon = 1;
                    break;
                case Constants.Direction.Down:
                    numIcon = 2;
                    break;
                case Constants.Direction.Left:
                    numIcon = 3;
                    break;
                default:
                    throw new Exception("Tank icon updating error.");
            }
        }

        protected void SetDirection(Constants.Direction newDir)
        {
            direction = newDir;
        }

        public void Step(Constants.Direction dir)
        {

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