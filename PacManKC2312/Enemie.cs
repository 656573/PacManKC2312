using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Enemie : GameObject
    {
        private char[,] _map;
        private Level _level;
        private Player _player;
        private int _direction;
        private int _oldDirection;

        private Vector moveUp = new Vector(0, -1);
        private Vector moveDown = new Vector(0, 1);
        private Vector moveLeft = new Vector(-1, 0);
        private Vector moveRigth = new Vector(1, 0);

        public Enemie(Level level, Player player) : base(level.PositionEnemis, 'S')
        {
            _player = player;
            _level = level;
            _map = level.GetMap();
            _direction = KeyMoveUp;
            _oldDirection = KeyMoveDown;
        }

        public override void Update(Level level)
        {
            

            if(Position == _player.Position)
            {

            }

            switch (_direction)
            {
                case KeyMoveUp:
                    SetPosition(moveUp, _level);
                    break;
                case KeyMoveDown:
                    SetPosition(moveDown, _level);
                    break;
                case KeyMoveLeft:
                    SetPosition(moveLeft, _level);
                    break;
                case KeyMoveRigth:
                    SetPosition(moveRigth, _level);
                    break;
            }

            UpdateOldDirection();
            UpdateDirection();
        }

        private void UpdateDirection()
        {
            int countFreePaths = 4;

            SetOldDirection(_level.IsWall(new Vector(Position.X, Position.Y - 1)), ref countFreePaths);
            SetOldDirection(_level.IsWall(new Vector(Position.X, Position.Y + 1)), ref countFreePaths);
            SetOldDirection(_level.IsWall(new Vector(Position.X - 1, Position.Y)), ref countFreePaths);
            SetOldDirection(_level.IsWall(new Vector(Position.X + 1, Position.Y)), ref countFreePaths);

            if(countFreePaths == 2)
            {
                switch (_oldDirection)
                {
                    case KeyMoveDown:
                        GetMoveDirection(moveUp, moveRigth, KeyMoveLeft, KeyMoveRigth, KeyMoveUp);
                        break;
                    case KeyMoveUp:
                        GetMoveDirection(moveDown, moveRigth, KeyMoveLeft, KeyMoveRigth, KeyMoveDown);
                        break;
                    case KeyMoveLeft:
                        GetMoveDirection(moveRigth, moveUp, KeyMoveDown, KeyMoveUp, KeyMoveRigth);
                        break;
                    case KeyMoveRigth:
                        GetMoveDirection(moveLeft,moveUp,KeyMoveDown,KeyMoveUp,KeyMoveLeft);
                        break;
                }
            }
            else 
            {
                int direction = _oldDirection;

                while (direction == _oldDirection)
                    direction = GameSeting.GetRandomNumber(4);

                _direction = direction;
            }
        }

        private void GetMoveDirection(Vector vectorOne, Vector vectorTwo,int keyOne, int keyTwo,int keyFre)
        {
            if (_level.IsWall(Position + vectorOne))
                if (_level.IsWall(Position + vectorTwo))
                    _direction = keyOne;
                else
                    _direction = keyTwo;
            else
                _direction = keyFre;
        }

        private void UpdateOldDirection()
        {
            int countFreePaths = 4;

            switch (_direction)
            {
                case KeyMoveUp:
                    _oldDirection = KeyMoveDown;
                    break;
                case KeyMoveDown:
                    _oldDirection = KeyMoveUp;
                    break;
                case KeyMoveLeft:
                    _oldDirection = KeyMoveRigth;
                    break;
                case KeyMoveRigth:
                    _oldDirection = KeyMoveLeft;
                    break;
            }

            SetOldDirection(_level.IsWall(new Vector(Position.X, Position.Y - 1)), ref countFreePaths);
            SetOldDirection(_level.IsWall(new Vector(Position.X, Position.Y + 1)), ref countFreePaths);
            SetOldDirection(_level.IsWall(new Vector(Position.X - 1, Position.Y)), ref countFreePaths);
            SetOldDirection(_level.IsWall(new Vector(Position.X + 1, Position.Y)), ref countFreePaths);

            if (countFreePaths == 1)
                _direction = _oldDirection;
        }

        private void SetOldDirection(bool isWall, ref int countFreePaths)
        {
            if (isWall)
                countFreePaths--;
        }
    }
}
