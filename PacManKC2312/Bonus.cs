using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Bonus : GameObject
    {
        private Vector _position;
        private Player _player;

        public Bonus(Level level, Player player): base('*')
        {
            _player = player;
            _isLive = true;
            _position = GetRandomPosition(level);
        }

        private bool _isLive;

        public override void Update(Level level)
        {
            if (_isLive)
            {
                if(_position == _player.Position)
                {
                    _player.ActivateBonus();
                    _isLive = false;
                }
            }
        }

        public override void Draw()
        {
            if (_isLive)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(_position.X, _position.Y);
                Console.Write(Symbol);
            }
        }

        private Vector GetRandomPosition(Level level)
        {
            Vector position = _player.Position;
            char[,] map = level.GetMap();

            while (level.IsWall(position) || position == _player.Position)
                position = new Vector(GameSeting.GetRandomNumber(map.GetLength(1))-1, GameSeting.GetRandomNumber(map.GetLength(0))-1);

            return position;
        }
    }
}
