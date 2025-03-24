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

            UpdateDirection();
            UpdateOldDirection();
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
                        if (_level.IsWall(Position + moveUp))
                            if (_level.IsWall(Position + moveLeft))
                                _direction = KeyMoveRigth;
                            else
                                _direction = KeyMoveLeft;
                        else
                            _direction = KeyMoveUp;
                        break;
                    case KeyMoveUp:
                        if (_level.IsWall(Position + moveDown))
                            if (_level.IsWall(Position + moveLeft))
                                _direction = KeyMoveRigth;
                            else
                                _direction = KeyMoveLeft;
                        else
                            _direction = KeyMoveDown;
                        break;
                    case KeyMoveLeft:
                        if (_level.IsWall(Position + moveRigth))
                            if (_level.IsWall(Position + moveUp))
                                _direction = KeyMoveUp;
                            else
                                _direction = KeyMoveDown;
                        else
                            _direction = KeyMoveRigth;
                        break;
                    case KeyMoveRigth:
                        if (_level.IsWall(Position + moveRigth))
                            if (_level.IsWall(Position + moveUp))
                                _direction = KeyMoveUp;
                            else
                                _direction = KeyMoveDown;
                        else
                            _direction = KeyMoveLeft;
                        break;
                }
            }
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
