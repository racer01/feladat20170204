using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat20170204
{
    class Point
    {
        private byte x;
        private byte y;

        public byte X
        {
            get { return x; }
            set { x = value; }
        }
        public byte Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", x, y);
        }
    }
}
