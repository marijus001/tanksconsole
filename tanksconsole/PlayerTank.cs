using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class PlayerTank : Tank
    {
        public PlayerTank(int x, int y) : base(x, y)
        {
            icon.Add(new Icon('▲', ConsoleColor.Yellow, ConsoleColor.DarkYellow));
            icon.Add(new Icon('►', ConsoleColor.Yellow, ConsoleColor.DarkYellow));
            icon.Add(new Icon('▼', ConsoleColor.Yellow, ConsoleColor.DarkYellow));
            icon.Add(new Icon('◄', ConsoleColor.Yellow, ConsoleColor.DarkYellow));
            direction = Constants.Direction.Up;
        }

        public void Act(ConsoleKeyInfo key)
        {
            switch (key.KeyChar)
            {
                case 'w':
                    if (Constants.ticks - moveTime > Constants.MOVE_SPEED / 3) // TO TANK
                    {
                        moveTime = Constants.ticks;
                        Step(Constants.Direction.Up);
                    }

                    break;
                case 'd':
                    if (Constants.ticks - moveTime > Constants.MOVE_SPEED / 3)  // TO TANK
                    {
                        moveTime = Constants.ticks;
                        Step(Constants.Direction.Right);
                    }
                    break;
                case 's':
                    if (Constants.ticks - moveTime > Constants.MOVE_SPEED / 3)
                    {
                        moveTime = Constants.ticks;
                        Step(Constants.Direction.Down);
                    }
                    break;
                case 'a':
                    if (Constants.ticks - moveTime > Constants.MOVE_SPEED / 3)
                    {
                        moveTime = Constants.ticks;
                        Step(Constants.Direction.Left);
                    }
                    break;
                case 'v':
                    Shot();
                    break;
                default:
                    break;
            }
        }
    }
}