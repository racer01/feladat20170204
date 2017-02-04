using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat20170204
{
    class Picture
    {
        // [row, column]
        private RGB[,] pixels;
        private Size size;

        public Size Size
        { get { return size; } }

        public Picture(Size size, RGB[,] pixels)
        {
            this.size = size;
            this.pixels = pixels;
        }

        public RGB getPixel(byte row, byte column)
        {
            return pixels[row, column];
        }

        public static Picture readPicture(string filename, Size s)
        {
            RGB[,] pixels = new RGB[s.Height, s.Width];
            using (StreamReader sr = new StreamReader(filename))
            {
                for (int row = 0; row < s.Height; row++)
                {
                    for (int col = 0; col < s.Width; col++)
                    {
                        pixels[row, col] = new RGB(sr.ReadLine());
                    }
                }
            }
            return new Picture(s, pixels);
        }

        public void writePicture(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int row = 0; row < size.Height; row++)
                {
                    for (int col = 0; col < size.Width; col++)
                    {
                        RGB p = pixels[row, col];
                        sw.WriteLine(p.ToString());
                    }
                }
            }
        }

        public bool isOnPicture(RGB pixel)
        {
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    if (pixels[row, col].Equals(pixel))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int countPixel(RGB pixel)
        {
            int count = 0;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    if (pixels[row, col].Equals(pixel))
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

        public void drawBorder(byte px)
        {
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    if (row <= px ||
                        row >= size.Height - px ||
                        col <= px ||
                        col >= size.Width - px)
                    {
                        pixels[row, col] = new RGB(0, 0, 0);
                    }
                }
            }
        }

        public Point[] searchRect(RGB pixel)
        {
            Point[] points = new Point[2];
            bool tr = true;
            for (int row = 0; row < size.Height && tr; row++)
            {
                for (int col = 0; col < size.Width && tr; col++)
                {
                    if (pixels[row, col].Equals(pixel))
                    {
                        points[0] = new Point((byte)col, (byte)row);
                        tr = false;
                    }
                }
            }
            bool bl = true;
            for (int row =size.Height - 1; row >= 0 && bl; row--)
            {
                for (int col = size.Width - 1; col >= 0 && bl; col--)
                {
                    if (pixels[row, col].Equals(pixel))
                    {
                        points[1] = new Point((byte)col, (byte)row);
                        bl = false;
                    }
                }
            }
            return points;
        }
    }
}
