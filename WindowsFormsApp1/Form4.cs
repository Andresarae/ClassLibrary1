using Cg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form4 : Form
    {
        private SolarSystem FirstSystem;
        private Bitmap myBitmap;
        private Graphics g;
        public Form4()
        {
            InitializeComponent();

            FirstSystem = new SolarSystem(new List<Planet>());
            FirstSystem.Size = Size;
            FirstSystem.CreateSolarSystem();
            TimerStart();
            Paint += Form4_Paint;
        }
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            if (FirstSystem != null)
                FirstSystem.DrawSystem(g);
            pictureBox1.Image = myBitmap;
        }
        private void TimerStart()
        {
            Timer tmr = new Timer();
            tmr.Interval = 30;
            tmr.Tick += Tmr_Tick;
            tmr.Start();
        }
        private void Tmr_Tick(object sender, EventArgs e)
        {
            if (FirstSystem != null)
            {
                FirstSystem.Size = Size;
                pictureBox1.Size = Size;
                FirstSystem.UpdateSystem();
                Invalidate(true);
            }
        }
    }
}
