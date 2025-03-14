using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Player: GameObject
    {
        private int _direction;
       
        public Player(Vector position) : base(position, '@')
        {
            _direction = KayMoveRigth;
            CountLive = 3;
            IsBonus = false;
        }

        public bool IsBonus { get; private set; }

        public int CountLive { get; private set; }

        public bool IsLive => CountLive > 0;

        public override void Update(Level level)
        {
            switch (_direction)
            {
                case KayMoveUp:
                    SetPosition(new Vector(MoveStop, MoveBack), level);
                    break;
                case KayMoveDown:
                    SetPosition(new Vector(MoveStop, MoveForward), level);
                    break;
                case KayMoveLeft:
                    SetPosition(new Vector(MoveBack, MoveStop), level);
                    break;
                case KayMoveRigth:
                    SetPosition(new Vector(MoveForward, MoveStop), level);
                    break;
            }
        }

        public void Control()
        {
            const ConsoleKey KeyUp = ConsoleKey.UpArrow;
            const ConsoleKey KeyDown = ConsoleKey.DownArrow;
            const ConsoleKey KeyRight = ConsoleKey.RightArrow;
            const ConsoleKey KeyLeft = ConsoleKey.LeftArrow;

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case KeyUp:
                    _direction = KayMoveUp;
                    break;
                case KeyDown:
                    _direction = KayMoveDown;
                    break;
                case KeyLeft:
                    _direction = KayMoveLeft;
                    break;
                case KeyRight:
                    _direction = KayMoveRigth;
                    break;
            }
        }

        public void TakeDamage()
        {
            CountLive--;
            GetStartPosition();
        }
    }
}
