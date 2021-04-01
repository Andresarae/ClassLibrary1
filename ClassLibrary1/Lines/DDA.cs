using System;
using System.Drawing;

namespace Cg.Lines
{
    public class DDA : ILine
    {
        public void DrawLine(Graphics g, Point2D p1, Point2D p2)
        {
            if (p1 != null && p2 != null)
            {
                int x1 = (int)Math.Round(p1.X);
                int y1 = (int)Math.Round(p1.Y);
                int x2 = (int)Math.Round(p2.X);
                int y2 = (int)Math.Round(p2.Y);

                int deltaX = Math.Abs(x1 - x2);
                int deltaY = Math.Abs(y1 - y2);

                int length = Math.Max(deltaX, deltaY);

                double dx = (p2.X - p1.X) * 1.0 / length;
                double dy = (p2.Y - p1.Y) * 1.0 / length;

                double x = p1.X;
                double y = p1.Y;

                while (length > 0)
                {
                    x += dx;
                    y += dy;
                    g.FillRectangle(Brushes.Black, (int)x, (int)y, 1, 1);
                    length--;
                }
            }
        }
    }
}
