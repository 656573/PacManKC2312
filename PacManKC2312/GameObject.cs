using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public abstract class GameObject
    {
        protected const int KayMoveUp = 1;
        protected const int KayMoveDown = 2;
        protected const int KayMoveLeft = 3;
        protected const int KayMoveRigth = 4;

        private Vector _startPosition;

        public GameObject(Vector position, char symbol)
        {
            Position = position;
            Symbol = symbol;
            _startPosition = position;

            MoveForward = 1;
            MoveStop = 0;
            MoveBack = -1;
        }

        public Vector Position { get; private set;}

        public char Symbol { get; private set; }

        protected int MoveForward { get; private set; }

        protected int MoveStop { get; private set; }

        protected int MoveBack { get; private set; }

        public abstract void Update(Level level);

        public void Draw()
        {
            Console.SetCursorPosition(Position.X,Position.Y);
            Console.Write(Symbol);
        }

        protected void SetPosition(Vector move, Level level)
        {
            Vector oldPosition = Position;
            Position += move;

            if (level.IsWall(Position))
                Position = oldPosition;
        }

        protected void GetStartPosition() => Position = _startPosition;
    }
}
