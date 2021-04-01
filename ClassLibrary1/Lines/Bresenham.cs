using System;
using System.Drawing;

namespace Cg.Lines
{
    public class Bresenham : ILine
    {
        public void DrawLine(Graphics g, Point2D p1, Point2D p2)
        {
            if (p1 != null && p2 != null)
            {
                int deltaX = Math.Abs((int)(p2.X - p1.X));
                int deltaY = Math.Abs((int)(p2.Y - p1.Y));
                int incX = Sign(deltaX);
                int incY = Sign(deltaY);

                int pdx, pdy, es, err, el;

                if (deltaX > deltaY)
                { // горизонталь
                    pdx = incX;
                    pdy = 0;
                    es = deltaY;
                    el = deltaX;
                }
                else
                { // вертикаль
                    pdx = 0;
                    pdy = incY;
                    es = deltaX;
                    el = deltaY;
                }
                int x = (int)p1.X;
                int y = (int)p1.Y;
                err = el / 2;
                g.FillRectangle(Brushes.Black, x, y, 1, 1);
                for (int i = 0; i < el; i++)
                {
                    err -= es;
                    if (err < 0)
                    { // сдвинуть
                        err += el;
                        x += incX;
                        y += incY;
                    }
                    else
                    { // тянуть
                        x += pdx;
                        y += pdy;
                    }
                    g.FillRectangle(Brushes.Black, x, y, 1, 1);
                }
            }
        }
        private static int Sign(int x)
        {
            return x.CompareTo(0);
        }
    }
}
