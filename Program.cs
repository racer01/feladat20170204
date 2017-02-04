using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat20170204
{
    class Program
    {
        public struct Count
        {
            public byte row;
            public byte column;
        }

        static void Main(string[] args)
        {
            // 1st task - read picture
            Size size = new Size(50, 50);
            // RGB[,] picture = readPicture(sr, size);
            Picture picture = Picture.readPicture("kep.txt", size);
            // 2nd task - is input pixel on picture
            Console.Write("Search pixel on picture (r g b, separated with spaces): ");
            RGB inputPixel = new RGB(Console.ReadLine());
            Console.WriteLine(picture.isOnPicture(inputPixel));
            // 3rd task - 35.row 8.col color count in 35.row & 8.col
            Count count = countRowCol(picture, 35, 8);
            Console.WriteLine(String.Format("Sorban: {0} Oszlopban: {1}", count.row, count.column));
            // 4th task - most frequent color from [255, 0, 0], [0, 255, 0], [0, 0, 255]
            int[] freq = new int[3];
            freq[0] = picture.countPixel(new RGB(255, 0, 0));
            freq[1] = picture.countPixel(new RGB(0, 255, 0));
            freq[2] = picture.countPixel(new RGB(0, 0, 255));
            byte mostFrequent = maxIndex(freq);
            switch (mostFrequent)
            {
                case 0:
                    Console.WriteLine("Piros");
                    break;
                case 1:
                    Console.WriteLine("Zöld");
                    break;
                case 2:
                    Console.WriteLine("Kék");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            // 5th task - 3px border
            picture.drawBorder(3);
            // 6th task - write new picture to "keretes.txt"
            picture.writePicture("keretes.txt");
            // 7th task - locate yellow rect top-left & bottom-right
            Point[] corners = picture.searchRect(new RGB(255, 255, 0));
            Console.WriteLine(String.Format("Kezd: {0}, {1}", corners[0].X, corners[0].Y));
            Console.WriteLine(String.Format("Vége: {0}, {1}", corners[1].X, corners[1].Y));
            int s = (corners[1].X - corners[0].X) * (corners[1].Y - corners[0].Y);
            Console.WriteLine(String.Format("Képpontok száma: {0}", s));
            Console.ReadKey();
        }

        public static Count countRowCol(Picture picture, byte row, byte column)
        {
            Count count = new Count();
            count.row = 0; count.column = 0;
            RGB pixel = picture.getPixel(row, column);
            for (byte c = 0; c < picture.Size.Width; c++)
            {
                if (picture.getPixel(row, c).Equals(pixel))
                {
                    count.row++;
                }
            }
            for (byte r = 0; r < picture.Size.Height; r++)
            {
                if (picture.getPixel(r, column).Equals(pixel))
                {
                    count.column++;
                }
            }
            return count;
        }

        public static byte maxIndex(int[] arr)
        {
            if (arr.Length < 1)
                return 0;
            byte index = 0;
            for (byte i = 1; i < arr.Length; i++)
            {
                if (arr[index] < arr[i])
                {
                    index = i;
                }
            }
            return index;
        }

    }
}
