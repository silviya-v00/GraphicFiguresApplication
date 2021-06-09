using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicShapes
{
    public partial class RectangleForm : Form
    {
        private bool _tracingMouse = false;
        private Point _mouseDownLocation;

        private List<Shape> shapes = new List<Shape>();
        private List<Shape> selectedShapaes = new List<Shape>();

        public RectangleForm()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }
        private void CalculatePerimeter()
        {
            var perimeter = shapes
                .Select(s => s.Perimeter())
                .Sum();

            toolStripStatusLabelPerimeter.Text = "Total Perimeter: " + perimeter;
        }
        private void CalculateArea()
        {
            var area = shapes
                .Select(s => s.Area())
                .Sum();

           toolStripStatusLabelArea.Text = "Total Area: " + area;
        }
        private List<Shape> WhereContains(Point point)
        {
            var resultList = new List<Shape>();
            foreach (var shape in shapes)
            {
                if (shape.Contains(point))
                    resultList.Add(shape);
            }
            return resultList;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in shapes)
            {
                shape.Paint(e.Graphics);
            }
        }

        private void RectangleForm_Load(object sender, EventArgs e)
        {

        }

        private void RectangleForm_MouseDown(object sender, MouseEventArgs e)
        {
            _tracingMouse = true;
            _mouseDownLocation = e.Location;

            var clickedShape = e.Button == MouseButtons.Left
                ? shapes
                    .OrderByDescending(o => o.Order)
                    .Where(shape => shape.Contains(e.Location))
                    .FirstOrDefault()
                : null;

            foreach (var selectedRectangle in selectedShapaes)
                selectedRectangle.Color = Color.Blue;

            selectedShapaes.Clear();

            if (clickedShape != null)
            {
                clickedShape.Color = Color.Red;
                selectedShapaes.Add(clickedShape);
            }

            Invalidate();
        }

        private void RectangleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_tracingMouse)
                return;
            var width = Math.Abs(e.Location.X - _mouseDownLocation.X);
            var height = Math.Abs(e.Location.Y - _mouseDownLocation.Y);
            if (width > 0 && height > 0)
            {
                var x = Math.Min(_mouseDownLocation.X, e.Location.X);
                var y = Math.Min(_mouseDownLocation.Y, e.Location.Y);


                Rectangle frameRectangle = new Rectangle(width,height);
                frameRectangle.Color = Color.Gray;
                frameRectangle.Location = new Point(x, y);

                foreach (var shape in shapes)
                    shape.Color =
                       frameRectangle.Location.X < shape.Location.X + frameRectangle.Width &&
                       frameRectangle.Location.X + frameRectangle.Width > shape.Location.X &&
                       frameRectangle.Location.Y < shape.Location.Y + frameRectangle.Width &&
                       frameRectangle.Location.Y + frameRectangle.Height > shape.Location.Y
                           ? Color.Red
                           : Color.Blue;

                Invalidate();
                Application.DoEvents();

                using (var graphics = CreateGraphics())
                    frameRectangle.Paint(graphics);
            }
        }

        private void RectangleForm_MouseUp(object sender, MouseEventArgs e)
        {
            _tracingMouse = false;

            CreateRectangle(e);

            CalculatePerimeter();
            CalculateArea();
            Invalidate();
        }

        private void RemoveRectangle(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (var i = 0; i < selectedShapaes.Count(); i++)
                    shapes.Remove(selectedShapaes[i]);

                selectedShapaes.Clear();

                CalculatePerimeter();
                CalculateArea();
                Invalidate();
            }
        }
        private void CreateRectangle(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var width = Math.Abs(e.Location.X - _mouseDownLocation.X);
                var height = Math.Abs(e.Location.Y - _mouseDownLocation.Y);
                var x = Math.Min(_mouseDownLocation.X, e.Location.X);
                var y = Math.Min(_mouseDownLocation.Y, e.Location.Y);

                Rectangle newRectangle = new Rectangle(width,height);
                newRectangle.Location = new Point(x, y);
                newRectangle.Color = Color.Red;
                newRectangle.Solid = true;
                newRectangle.Order = shapes
                    .Select(s => s.Order)
                    .OrderBy(o => o)
                    .LastOrDefault() + 1;

                shapes.Add(newRectangle);

                foreach (var selectedRectangle in selectedShapaes)
                    selectedRectangle.Color = Color.Blue;

                selectedShapaes.Clear();
                selectedShapaes.Add(newRectangle);
            }
            else if (e.Button == MouseButtons.Left)
            {
                selectedShapaes = shapes
                    .Where(c => c.Color == Color.Red)
                    .ToList();
            }
        }

        private void RectangleForm_KeyDown(object sender, KeyEventArgs e)
        {
            RemoveRectangle(e);
        }
    }
}
