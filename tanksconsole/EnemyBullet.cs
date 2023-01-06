using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanksconsole
{
    class EnemyBullet : Bullet
    {
        //inherits Bullet properties just has different class to be able to tell if enemy kills player
        public EnemyBullet(int x, int y, Constants.Direction dir) : base(x, y, dir) 
        {

        }
    }
}
