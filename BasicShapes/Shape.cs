using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicShapes
{
     public abstract class Shape
    {
        protected Point location;
        protected Color color;
        protected bool solid;
        protected int order;
        public Point Location { get; set; }
        public Color Color { get; set; }
        public bool Solid { get; set; }
        public int Order { get; set; }

        public virtual int Area()
        {
            return 0;
        }
        public virtual int Perimeter()
        {
            return 0;
        }
        public abstract void Paint(Graphics graphics);
        public abstract bool Contains(Point point);
    }
}
