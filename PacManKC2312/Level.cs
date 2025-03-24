using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public class Level
    {
        private char[,] _map;
        private char _symboleWall;
        private char _symboleFood;
        private char _symboleEmptyCell;

        public Level(string path)
        {
            _symboleWall = '#';
            _symboleFood = '.';
            _symboleEmptyCell = ' ';
            _map = ReadFileMap(path);
            PositionEnemis = DeterminePositionEnemis();
            CountFood = DetermineCountFood();
        }

        public Vector PositionEnemis { get; private set; }
        public int CountFood { get; private set; }

        public void Draw()
        {
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for(int x = 0; x <  _map.GetLength(1); x++)
                    Console.Write(_map[y,x]);

                Console.WriteLine();
            }
        }

        public char[,] GetMap() 
        {
            char[,] map = new char[_map.GetLength(0), _map.GetLength(1)];

            for (int y = 0; y < map.GetLength(0); y++)
                for (int x = 0; x < _map.GetLength(1); x++)
                    map[y, x] = _map[y, x];

            return map;
        }

        public bool IsFood(Player player)
        {
            bool isFood = false;
            Vector position = player.Position;

            if(_map[position.Y, position.X] == _symboleFood)
            {
                _map[position.Y, position.X] = _symboleEmptyCell;
                isFood = true;
            }

            return isFood;
        }

        public bool IsWall(Vector vector)
        {
            return _map[vector.Y, vector.X] == _symboleWall;
        }

        private Vector DeterminePositionEnemis()
        {
            int x = 0;
            int y = 0;

            for (int j = 0; j < _map.GetLength(0); j++)
            {
                for(int i = 0;i < _map.GetLength(1); i++)
                {
                    if (_map[i, j] == '$')
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            Vector position = new Vector(x,y);
            return position;
        }

        private int DetermineCountFood()
        {
            int countFood = 0;

            for (int y = 0; y < _map.GetLength(0); y++)
                for (int x = 0; x < _map.GetLength(1); x++)
                    if (_map[x, y] == _symboleFood)
                        countFood++;

                    return countFood;
        }

        private char[,] ReadFileMap(string path)
        {
            string[] linesFile = File.ReadAllLines(path);
            char[,] map = new char[GetMaxLengthOfLine(linesFile),linesFile.Length];

            for (int y = 0; y < linesFile.Length; y++)
                for (int x = 0; x < map.GetLength(0); x++)
                    map[x,y] = linesFile[y][x];

            return map;
        }

        private int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = 0;

            foreach (string line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }
    }
}
