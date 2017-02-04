using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat20170204
{
    class Size
    {
        private byte height;
        private byte width;

        public byte Height
        {
            get { return height; }
            set { height = value; }
        }
        public byte Width
        {
            get { return width; }
            set { width = value; }
        }

        public Size(byte height, byte width)
        {
            this.height = height;
            this.width = width;
        }
    }
}
