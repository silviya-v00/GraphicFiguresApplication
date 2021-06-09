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
    public partial class CircleForm : Form
    {
        private bool _tracingMouse = false;
        private Point _mouseDownLocation;

        private List<Shape> shapes = new List<Shape>();
        private List<Shape> selectedShapaes = new List<Shape>();
        public CircleForm()
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

        private void CircleForm_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in shapes)
            {
                shape.Paint(e.Graphics);
            }
        }

        private void CircleForm_MouseDown(object sender, MouseEventArgs e)
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

        private void CircleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_tracingMouse)
                return;
            var width = Math.Abs(e.Location.X - _mouseDownLocation.X);
            var height = Math.Abs(e.Location.Y - _mouseDownLocation.Y);
            if (width > 0 && height > 0)
            {
                var x = Math.Min(_mouseDownLocation.X, e.Location.X);
                var y = Math.Min(_mouseDownLocation.Y, e.Location.Y);


                Circle frameCircle = new Circle(40);
                frameCircle.Color = Color.Gray;
                frameCircle.Location = new Point(x, y);

                foreach (var shape in shapes)
                    shape.Color =
                       frameCircle.Location.X < shape.Location.X + frameCircle.Radius &&
                       frameCircle.Location.X + frameCircle.Radius > shape.Location.X &&
                       frameCircle.Location.Y < shape.Location.Y + frameCircle.Radius &&
                       frameCircle.Location.Y + frameCircle.Radius > shape.Location.Y
                           ? Color.Red
                           : Color.Blue;

                Invalidate();
                Application.DoEvents();

                using (var graphics = CreateGraphics())
                    frameCircle.Paint(graphics);
            }
        }

        private void CircleForm_MouseUp(object sender, MouseEventArgs e)
        {
            _tracingMouse = false;

            CreateCircle(e);

            CalculatePerimeter();
            CalculateArea();
            Invalidate();
        }
        private void RemoveCircle(KeyEventArgs e)
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
        private void CreateCircle(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var width = Math.Abs(e.Location.X - _mouseDownLocation.X);
                var height = Math.Abs(e.Location.Y - _mouseDownLocation.Y);
                var x = Math.Min(_mouseDownLocation.X, e.Location.X);
                var y = Math.Min(_mouseDownLocation.Y, e.Location.Y);

                Circle newCircle = new Circle(40);
                newCircle.Location = new Point(x, y);
                newCircle.Color = Color.Red;
                newCircle.Solid = true;
                newCircle.Order = shapes
                    .Select(s => s.Order)
                    .OrderBy(o => o)
                    .LastOrDefault() + 1;

                shapes.Add(newCircle);

                foreach (var selectedCircle in selectedShapaes)
                    selectedCircle.Color = Color.Blue;

                selectedShapaes.Clear();
                selectedShapaes.Add(newCircle);
            }
            else if (e.Button == MouseButtons.Left)
            {
                selectedShapaes = shapes
                    .Where(c => c.Color == Color.Red)
                    .ToList();
            }
        }

        private void CircleForm_KeyDown(object sender, KeyEventArgs e)
        {
            RemoveCircle(e);
        }

        private void CircleForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
