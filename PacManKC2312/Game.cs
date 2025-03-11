using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Game
    {
        private int _countPoint;
        private int _delay;

        private Level _level;
        private Player _player;

        public Game()
        {
            _player = new Player(new Vector(2,2));
            _level = new Level("map.txt");
            _countPoint = 0;
            _delay = 500;
        }

        public void Start()
        {
            Task.Run(() =>
            {
                while (IsStart())
                {
                    _player.Control();
                }
            });

            Task.Run(() =>
            {
                while (IsStart())
                {
                    Update();
                    Thread.Sleep(_delay);
                }
            });

            while (IsStart())
            {
                Draw();
                Thread.Sleep(_delay);
            }
        }

        private bool IsStart()
        {
            return _player.IsLive && _countPoint != _level.CountFood;
        }

        private void Update()
        {
            _player.Update(_level);

            if (_level.IsFood(_player))
                _countPoint++;
        }

        private void Draw()
        {
            string lineSymbolPlayer = "";
            string info = "";

            Console.Clear();
            _level.Draw();

            for (int i = 0; i < _player.CountLive; i++)
                lineSymbolPlayer += _player.Symbol;

            info += $"{lineSymbolPlayer}        очки {_countPoint}";
            Console.WriteLine(info);   

            _player.Draw();
        }
    }
}
