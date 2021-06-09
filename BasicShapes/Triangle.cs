using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicShapes
{
    public class Triangle : Shape
    {
        private int tbase;
        private int tside1;
        private int tside2;
        private int theight;
        Point[] points = new Point[]
        {
            new Point { X = 0, Y = 1 },
            new Point { X = 2, Y = 1 },
            new Point { X = 0, Y = 3 } };
        public Triangle(int b, int h, int a, int c)
        {
            tbase = b;
            theight = h;
            tside1 = a;
            tside2 = c;
        }

        public int Tbase { get; set; }
        public int Theight { get; set; }
        public int Tside1 { get; set; }
        public int Tside2 { get; set; }

        public override int Area()
        {
            return (int)(0.5 * tbase * theight);
        }
        public override int Perimeter()
        {
            return (tside1 + tside2 + tbase);
        }
        public override void Paint(Graphics graphics)
        {
            if (Solid)
                using (var brush = new SolidBrush(
                    Color.FromArgb(
                        Math.Min(byte.MaxValue, Color.R + 100),
                        Math.Min(byte.MaxValue, Color.G + 100),
                        Math.Min(byte.MaxValue, Color.B + 100))))
                    graphics.FillPolygon(brush, new Point[3]);

            using (var pen = new Pen(Color, 2))
                graphics.DrawPolygon(pen, new Point[3]);
        }

        public override bool Contains(Point point)
        {
            return
                Location.X < point.X && point.X < Location.X + tbase &&
                Location.Y < point.Y && point.Y < Location.Y + theight;
        }
    }
}
