using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKC2312
{
    public struct Vector
    {
        public Vector(int x,int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public static Vector operator +(Vector one, Vector two)
        {
            return new Vector(one.X+two.X,one.Y+two.Y);
        }

        public static Vector operator -(Vector one, Vector two)
        {
            return new Vector(one.X - two.X, one.Y - two.Y);
        }

        public static bool operator ==(Vector one, Vector two)
        {
            return one.X == two.X && one.Y == two.Y;
        }

        public static bool operator !=(Vector one, Vector two)
        {
            return one.X != two.X && one.Y != two.Y;
        }
    }
}
