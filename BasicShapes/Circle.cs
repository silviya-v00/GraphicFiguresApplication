using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicShapes
{
    public class Circle : Shape
    {
        private int radius;
        public Circle(int r)
        {
            Radius = r;
        }
        public int Radius { get; set; }

        public override int Area()
        {
            return (int)(Math.PI * Radius * Radius);
        }
        public override int Perimeter()
        {
            return (int)(2 * Math.PI * Radius);
        }
        public override void Paint(Graphics graphics)
        {
            if (Solid)
                using (var brush = new SolidBrush(
                    Color.FromArgb(
                        Math.Min(byte.MaxValue, Color.R + 100),
                        Math.Min(byte.MaxValue, Color.G + 100),
                        Math.Min(byte.MaxValue, Color.B + 100))))
                    graphics.FillEllipse(brush, Location.X, Location.Y, Radius, Radius);

            using (var pen = new Pen(Color, 2))
                graphics.DrawEllipse(pen, Location.X, Location.Y, Radius, Radius);
        }

        public override bool Contains(Point point)
        {
            return
                Location.X < point.X && point.X < Location.X + Radius &&
                Location.Y < point.Y && point.Y < Location.Y + Radius;
        }
    }
}
