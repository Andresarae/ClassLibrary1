using Cg;
using System;
using System.Windows.Forms;
using Cg.Lines;
using System.Drawing;

namespace Forms
{
    public partial class Form3 : Form
    {
        private Graphics _g;
        private Bitmap _myBitmap;
        public Form3()
        {
            InitializeComponent();

            numericUpDown1.Maximum = pictureBox1.Width - 15;
            numericUpDown2.Maximum = pictureBox1.Height - 15;
            numericUpDown3.Maximum = pictureBox1.Width - 15;
            numericUpDown4.Maximum = pictureBox1.Height - 15;
            numericUpDown5.Maximum = pictureBox1.Width - 15;
            numericUpDown6.Maximum = pictureBox1.Height - 15;
            numericUpDown7.Maximum = pictureBox1.Width - 15;
            numericUpDown8.Maximum = pictureBox1.Height - 15;

            numericUpDown9.Maximum = 4;
            numericUpDown9.Minimum = 3; 
        }

        private void Create_Click(object sender, EventArgs e)
        {
            _myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _g = Graphics.FromImage(_myBitmap);

            if (numericUpDown9.Value == 3)
            {
                BezierCurve curve = new BezierCurve(new Point2D((double)numericUpDown1.Value, (double)numericUpDown2.Value),
                    new Point2D((double)numericUpDown4.Value, (double)numericUpDown3.Value), 
                    new Point2D((double)numericUpDown6.Value, (double)numericUpDown5.Value),0.00005);
                curve.DrawCurve(_g);
            }
            else
            {
                BezierCurve curve = new BezierCurve(new Point2D((double)numericUpDown1.Value, (double)numericUpDown2.Value),
                    new Point2D((double)numericUpDown4.Value, (double)numericUpDown3.Value),
                    new Point2D((double)numericUpDown6.Value, (double)numericUpDown5.Value),
                    new Point2D((double)numericUpDown8.Value, (double)numericUpDown7.Value), 0.00005);
                curve.DrawCurve(_g);
            }
            pictureBox1.Image = _myBitmap;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
