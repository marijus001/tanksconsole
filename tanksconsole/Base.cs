using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class Base : Entity
    {
        public Base(int x, int y)
        {
            this.x = x;
            this.y = y;
            icon.Add(new Icon('*', ConsoleColor.DarkMagenta, ConsoleColor.Magenta));
        }
    }
}
