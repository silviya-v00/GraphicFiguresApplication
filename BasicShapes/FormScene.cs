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
    public partial class FormScene : Form
    {
        public FormScene()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            var rectangleForm = new RectangleForm();
            rectangleForm.Show();
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            var circleForm = new CircleForm();
            circleForm.Show();
        }

        private void FormScene_Load(object sender, EventArgs e)
        {

        }
    }
}
