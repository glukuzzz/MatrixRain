using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain4
{
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Coordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        static public Coordinate operator -(Coordinate ob1, Coordinate ob2)
        {
            Coordinate res = new Coordinate(10, 10);

            res.X = ob1.X - ob2.X;
            res.Y = ob1.Y - ob2.Y;

            return res;
        }
        static public Coordinate operator +(Coordinate ob1, Coordinate ob2)
        {
            Coordinate res = new Coordinate(10, 10);

            res.X = ob1.X + ob2.X;
            res.Y = ob1.Y + ob2.Y;

            return res;
        }

        public override bool Equals(object obj)
        {
            var k = obj as Coordinate;
            if (k != null)
            {
                if (this.X == k.X && this.Y == k.Y)
                    return true;
            }
            return base.Equals(obj);
        }


        public override int GetHashCode()
        {

            int a = X * 10 + Y;
            return a.GetHashCode();
        }


    }
}
