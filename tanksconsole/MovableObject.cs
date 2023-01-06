using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class MovableObject : Entity
    {
        public Constants.Direction direction = new Constants.Direction();

        public Constants.Direction OppositeDirection()
        {
            switch (direction)
            {
                case Constants.Direction.Up:
                    return Constants.Direction.Down;
                case Constants.Direction.Right:
                    return Constants.Direction.Left;
                case Constants.Direction.Down:
                    return Constants.Direction.Up;
                case Constants.Direction.Left:
                    return Constants.Direction.Right;
                default:
                    break;
            }
            throw new Exception("OppositeDirection method error.");
        }

        protected Constants.Direction RandomDirection()
        {

            switch (Constants.rand.Next(1, 5))
            {
                case 1:
                    return Constants.Direction.Up;
                case 2:
                    return Constants.Direction.Right;
                case 3:
                    return Constants.Direction.Down;
                case 4:
                    return Constants.Direction.Left;
                default:
                    break;
            }
            return Constants.Direction.Up;
        }

        public Constants.CollisionType Collision(int x, int y, Constants.Direction dir)
        {
            for (int i = 0; i < Constants.roomObjects.Count; i++)
            {
                switch (dir)
                {
                    case Constants.Direction.Up:
                        if (Constants.roomObjects[i].GetY() == y - 1 && Constants.roomObjects[i].GetX() == x)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (y < 1)
                            return Constants.CollisionType.Solid;
                        break;
                    case Constants.Direction.Right:
                        if (Constants.roomObjects[i].GetX() == x + 1 && Constants.roomObjects[i].GetY() == y)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (x > Constants.FIELD_SIZE - 2)
                            return Constants.CollisionType.Solid;
                        break;
                    case Constants.Direction.Down:
                        if (Constants.roomObjects[i].GetY() == y + 1 && Constants.roomObjects[i].GetX() == x)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (y > Constants.FIELD_SIZE - 2)
                            return Constants.CollisionType.Solid;
                        break;
                    case Constants.Direction.Left:
                        if (Constants.roomObjects[i].GetX() == x - 1 && Constants.roomObjects[i].GetY() == y)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (x < 1)
                            return Constants.CollisionType.Solid;
                        break;
                    default:
                        break;
                }
            }
            return Constants.CollisionType.NoCollision;
        }

        public Constants.CollisionType Collision(int x, int y, Constants.Direction dir, Constants.CollisionType interestingType) //poly
        {
            for (int i = 0; i < Constants.roomObjects.Count; i++)
            {
                switch (interestingType)
                {
                    case Constants.CollisionType.Bullet:
                        if (Constants.roomObjects[i] is Bullet)
                            break;
                        else
                            continue;
                    case Constants.CollisionType.Tank:
                        if (Constants.roomObjects[i] is Tank)
                            break;
                        else
                            continue;
                    default:
                        break;
                }

                switch (dir)
                {
                    case Constants.Direction.Up:
                        if (Constants.roomObjects[i].GetY() == y - 1 && Constants.roomObjects[i].GetX() == x)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (y < 1)
                            return Constants.CollisionType.Solid;
                        break;
                    case Constants.Direction.Right:
                        if (Constants.roomObjects[i].GetX() == x + 1 && Constants.roomObjects[i].GetY() == y)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (x > Constants.FIELD_SIZE - 2)
                            return Constants.CollisionType.Solid;
                        break;
                    case Constants.Direction.Down:
                        if (Constants.roomObjects[i].GetY() == y + 1 && Constants.roomObjects[i].GetX() == x)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (y > Constants.FIELD_SIZE - 2)
                            return Constants.CollisionType.Solid;
                        break;
                    case Constants.Direction.Left:
                        if (Constants.roomObjects[i].GetX() == x - 1 && Constants.roomObjects[i].GetY() == y)
                        {
                            return Constants.RoomObjectCollisionType(i);
                        }
                        if (x < 1)
                            return Constants.CollisionType.Solid;
                        break;
                    default:
                        break;
                }
            }

            return Constants.CollisionType.NoCollision;
        }


    }


}