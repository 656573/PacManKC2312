using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public static class GameSeting
    {
        private static Random _random = new Random();

        private static int _minRandom = 0;

        public static int GetRandomNumber(int maxRandom)
        {
            int minRandom = 1;
            return _random.Next(minRandom, maxRandom + 1);
        }
    }
}
