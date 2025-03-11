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
            
        }

        public void Draw()
        {
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for(int x = 0; x <  _map.GetLength(1); x++)
                    Console.Write(_map[y,x]);

                Console.WriteLine();
            }
        }

        public bool IsFood(Vector vector)
        {
            bool isFood = false;

            if(_map[vector.Y, vector.X] == _symboleFood)
            {
                _map[vector.Y, vector.X] = _symboleEmptyCell;
                isFood = true;
            }

            return isFood;
        }

        public bool IsWall(Vector vector)
        {
            return _map[vector.Y, vector.X] == _symboleWall;
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
