using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BasicShapes
{
    public class Rectangle : Shape
    {
        private int width;
        private int height;
        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        
        public override int Area()
        {
            return (Width * Height);
        }
        public override int Perimeter()
        {
            return (2 * (Width + Height));
        }
        public override void Paint(Graphics graphics)
        {
            if (Solid)
                using (var brush = new SolidBrush(
                    Color.FromArgb(
                        Math.Min(byte.MaxValue, Color.R + 100),
                        Math.Min(byte.MaxValue, Color.G + 100),
                        Math.Min(byte.MaxValue, Color.B + 100))))
                    graphics.FillRectangle(brush, Location.X, Location.Y, Width, Height);

            using (var pen = new Pen(Color, 2))
                graphics.DrawRectangle(pen, Location.X, Location.Y, Width, Height);
            
        }

        public override bool Contains(Point point)
        {
            return
                Location.X < point.X && point.X < Location.X + Width &&
                Location.Y < point.Y && point.Y < Location.Y + Height;
        }
    }
}
