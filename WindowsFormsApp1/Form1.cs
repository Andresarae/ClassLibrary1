using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cg;
using Cg.Lines;

namespace Forms
{
    public partial class Form1 : Form
    {
        private Graphics _g;
        private Bitmap _myBitmap;
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = pictureBox1.Width - 15;
            numericUpDown2.Maximum = pictureBox1.Height - 15;
            numericUpDown3.Maximum = pictureBox1.Width - 15;
            numericUpDown4.Maximum = pictureBox1.Height - 15;

            numericUpDown1.Minimum = 15;
            numericUpDown2.Minimum = 15;
            numericUpDown3.Minimum = 15;
            numericUpDown4.Minimum = 15;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _g = Graphics.FromImage(_myBitmap);
            WuLine wu = new WuLine();
            Point2D p1 = new Point2D((double)numericUpDown1.Value, (double)numericUpDown2.Value);
            Point2D p2 = new Point2D((double)numericUpDown3.Value, (double)numericUpDown4.Value);
            wu.DrawLine(_g, p1, p2);
            pictureBox1.Image = _myBitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _g = Graphics.FromImage(_myBitmap);
            Bresenham br = new Bresenham();
            Point2D p1 = new Point2D((double)numericUpDown1.Value, (double)numericUpDown2.Value);
            Point2D p2 = new Point2D((double)numericUpDown3.Value, (double)numericUpDown4.Value);
            br.DrawLine(_g, p1, p2);
            pictureBox1.Image = _myBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _g = Graphics.FromImage(_myBitmap);
            DDA dda = new DDA();
            Point2D p1 = new Point2D((double)numericUpDown1.Value, (double)numericUpDown2.Value);
            Point2D p2 = new Point2D((double)numericUpDown3.Value, (double)numericUpDown4.Value);
            dda.DrawLine(_g, p1, p2);
            pictureBox1.Image = _myBitmap;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
