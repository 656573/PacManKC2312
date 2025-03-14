using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Enemie : GameObject
    {
        private Level _level;
        private Player _player;
        private int _direction;
        private int _oldDirection;

        public Enemie(Level level, Player player) : base(level.PositionEnemis, 'S')
        {
            _player = player;
            _level = level;
            _direction = 1;
            _oldDirection = _direction;
        }

        public override void Update(Level level)
        {
            if(_player.Position == Position)
            {
                if (_player.IsBonus)
                    GetStartPosition();
                else
                    _player.TakeDamage();

                SetPosition(ChooseDirection(level), level);
            }
        }

        private Vector ChooseDirection(Level level)
        {
            Vector MoveUp = new Vector(0,-1);
            Vector MoveDown = new Vector(0,1);


            Vector move = new Vector();

            ChooseDirectionHorisontal();
            


            return move;
        }

        private Vector ChooseDirectionHorisontal()
        {
            Vector MoveLeft = new Vector(-1, 0);
            Vector MoveRigth = new Vector(1, 0);

            if (_oldDirection == KayMoveLeft)
                return MoveLeft;
            if (_oldDirection == KayMoveRigth)
                return MoveRigth;

            return new Vector();
        }
    }
}
