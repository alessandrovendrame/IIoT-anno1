using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;

namespace ConsoleBitmap
{
    class Program
    {

        static ConsoleColor ColoriConsole(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }

        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "prova.bmp");
            var image = new Bitmap(path);

            var colorsDict = new Dictionary<Color, ConsoleColor>();
            colorsDict[Color.Red] = ConsoleColor.Red;
            colorsDict[Color.Blue] = ConsoleColor.Blue;

            char[] carattere = { '#', '*' };

            for (int i = 0; i < image.Height; i++)
            {
                for (int i1 = 0; i1 < image.Width; i1++)
                {
                    var pix = image.GetPixel(i1, i);
                    Console.ForegroundColor = ColoriConsole(pix.R, pix.G, pix.B);
                    Console.Write("#");

                }
                Console.WriteLine();
            }

        }
    }
}
