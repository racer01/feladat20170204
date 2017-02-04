using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat20170204
{
    class RGB : IEquatable<RGB>
    {
        private byte red;
        private byte green;
        private byte blue;

        public byte Red
        {
            get { return red; }
            set { red = value; }
        }
        public byte Green
        {
            get { return green; }
            set { green = value; }
        }
        public byte Blue
        {
            get { return blue; }
            set { blue = value; }
        }

        public RGB(byte r, byte g, byte b)
        {
            red = r;
            green = g;
            blue = b;
        }
        public RGB(byte[] colors)
        {
            red = colors[0];
            green = colors[1];
            blue = colors[2];
        }
        public RGB(String str) : this(stringToByteArr(str))
        { }

        public bool Equals(RGB other)
        {
            return (this.red == other.red) && (this.green == other.green) && (this.blue == other.blue);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", red, green, blue);
        }

        private static byte[] stringToByteArr(String str)
        {
            try
            {
                return Array.ConvertAll(str.Split(' '), s => byte.Parse(s));
            }
            catch (FormatException)
            {
                return new byte[] { 0, 0, 0};
            }
        }
    }
}
