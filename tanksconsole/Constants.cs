using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    static class Constants
    {
        public static List<Entity> roomObjects = new List<Entity>();
        public static int FIELD_SIZE = 26;
        public static int SHOT_SPEED = 40;
        public static int MOVE_SPEED = 10;
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        public enum CollisionType
        {
            NoCollision,
            Solid,
            Bullet,
            Tank,
            Opaque
        }
        public static Random rand = new Random();
        public static long ticks = 0;
        public static bool gameOver = false;
        public static bool SpaceEmpty(int x, int y)
        {
            for (int i = 0; i < roomObjects.Count; i++)
            {
                if (roomObjects[i].GetX() == x && roomObjects[i].GetY() == y)
                    return false;
            }
            return true;
        }
        public static bool NoOthers(Entity obj)
        {
            return true;
        }

        public static CollisionType RoomObjectCollisionType(int numRoomObj)
        {
            if (Constants.roomObjects[numRoomObj] is Bullet)
                return Constants.CollisionType.Bullet;
            if (Constants.roomObjects[numRoomObj] is Brick)
                return Constants.CollisionType.Solid;
            if (Constants.roomObjects[numRoomObj] is Water)
                return Constants.CollisionType.Opaque;
            if (Constants.roomObjects[numRoomObj] is Tank)
                return Constants.CollisionType.Tank;


            return CollisionType.NoCollision;
        }
    }
}
