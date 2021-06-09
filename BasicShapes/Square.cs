using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicShapes
{
    public class Square : Shape
    {
        private int side;
        public Square(int s)
        {
            side = s;
        }

        public int Side { get; set; }

        public override int Area()
        {
            return (side * side);
        }
        public override int Perimeter()
        {
            return (4 * side);
        }
        public override void Paint(Graphics graphics)
        {
            if (Solid)
                using (var brush = new SolidBrush(
                    Color.FromArgb(
                        Math.Min(byte.MaxValue, Color.R + 100),
                        Math.Min(byte.MaxValue, Color.G + 100),
                        Math.Min(byte.MaxValue, Color.B + 100))))
                    graphics.FillRectangle(brush, Location.X, Location.Y, side, side);

            using (var pen = new Pen(Color, 2))
                graphics.DrawRectangle(pen, Location.X, Location.Y, side, side);
        }

        public override bool Contains(Point point)
        {
            return
                Location.X < point.X && point.X < Location.X + side &&
                Location.Y < point.Y && point.Y < Location.Y + side;
        }
    }
}
