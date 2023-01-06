using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    abstract class MapEnitityPrototype : Entity
    {
        int x, y;
        Icon iconTemp = new Icon();
        public MapEnitityPrototype(int x, int y, Icon iconTemp)
        {
            this.x = x;
            this.y = y;
            icon.Add(iconTemp);
        }
        public abstract MapEnitityPrototype Clone();
    }
}
