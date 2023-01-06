using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class Brick : Entity //inheritance
    {
        public Brick(int x, int y)
        {
            this.x = x;
            this.y = y;
            icon.Add(new Icon(' ', ConsoleColor.Black, ConsoleColor.DarkRed));
        }
    }
}
