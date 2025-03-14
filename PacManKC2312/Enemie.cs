using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Enemie : GameObject
    {
        public Enemie(Level level) : base(level.PositionEnemis, 'S')
        {

        }

        public override void Update(Level level)
        {
            throw new NotImplementedException();
        }
    }
}
