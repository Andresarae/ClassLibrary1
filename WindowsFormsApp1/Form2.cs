using Cg;
using Cg.Lines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form2 : Form
    {
        private Graphics _g;
        private Bitmap _myBitmap;
        private int _width = 500;
        private int _height = 500;
        private WuLine _line = new WuLine();
        private int X = 250; 
        private int Y = 250;
        private Point2D _oldPoint;
        public Form2()
        {
            InitializeComponent();

            pictureBox1.Width = _width;
            pictureBox1.Height = _height;    

            _oldPoint = new Point2D(X, Y);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // y = x*2 + 4
            pictureBox1.Image = null;
            int[] arr = new int[] { 2,1,0,  1,1,4 };
            GoGraph(arr.ToList());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // y = x^2 + x*2 + 16
            pictureBox1.Image = null;
            int[] arr = new int[] { 1,2,0,  2,1,0,  1,1,16 };
            GoGraph(arr.ToList());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // y = x^2*56 -x^2 + x*2* + 89
            pictureBox1.Image = null;
            int[] arr = new int[] { 56,2,0,  1,2,0,  1,1,89 };
            GoGraph(arr.ToList());
        }

        private void GoGraph(List<int> listOfPoints)
        {
            _myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _g = Graphics.FromImage(_myBitmap);

            Graph gr = new Graph(10, pictureBox1.Width, pictureBox1.Height);
            gr.CreateA(_g);
            
            for (double x = -100; x < 100; x += 0.001)
            {
                Console.WriteLine("go x");
                X = (int)(x * 10) + _width / 2;

                if (listOfPoints != null)
                {
                    for (int i = 0; i < listOfPoints.Count; i += 3)
                    {
                        Y += (int)(listOfPoints[i] * Math.Pow(x, listOfPoints[i + 1]))
                            + listOfPoints[i + 2];
                    }
                    Y = _height / 2 - Y;
                    _line.DrawLine(_g, _oldPoint, new Point2D(X, Y));
                    _oldPoint = new Point2D(X, Y);
                    Y = 0;
                }
            }
            pictureBox1.Image = _myBitmap;
        }
    }
}
