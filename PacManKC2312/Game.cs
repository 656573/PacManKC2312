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

        private Level _level;
        private Player _player;

        public Game()
        {
            _player = new Player(new Vector(2,2));
            _level = new Level("map.txt");
            _countPoint = 0;
        }

        public void Start()
        {
            Task.Run(() =>
            {
                while (_player.IsLive)
                {
                    _player.Control();
                }
            });

            Task.Run(() =>
            {
                while (_player.IsLive)
                {
                    Update();
                    Thread.Sleep(500);
                }
            });

            while (_player.IsLive)
            {
                Draw();
                Thread.Sleep(500);
            }
        }

        private void Update()
        {
            _player.Update(_level);

            if (_level.IsFood(_player.Position))
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
