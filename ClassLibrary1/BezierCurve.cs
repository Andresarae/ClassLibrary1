using Cg.Lines;
using System;
using System.Drawing;

namespace Cg
{
    public class BezierCurve
    {
        public Point2D p1 { get; set; }
        public Point2D p2 { get; set; }
        public Point2D p3 { get; set; }
        public Point2D p4 { get; set; }
        public double t { get; set; }

        private WuLine _line = new WuLine();

        public BezierCurve(Point2D p1, Point2D p2, Point2D p3, double t)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.t = t;
        }

        public BezierCurve(Point2D p1, Point2D p2, Point2D p3, Point2D p4, double t)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.t = t;
        }

        public void DrawCurve(Graphics g)
        {
            if (p4 == null)
            {
                double x = p1.X; double y = p1.Y;
                Point2D oldPoint = p1;
                for (double i = 0; i < 1; i += t)
                {
                    _line.DrawLine(g, oldPoint, new Point2D((int)x, (int)y));
                    oldPoint = new Point2D((int)x, (int)y);
                    x = Math.Pow((1 - i), 2) * p1.X + 2 * i * (1 - i) * p2.X + Math.Pow(i, 2) * p3.X;
                    y = Math.Pow((1 - i), 2) * p1.Y + 2 * i * (1 - i) * p2.Y + Math.Pow(i, 2) * p3.Y;
                }
            }
            else
            {
                double x = p1.X; double y = p1.Y;
                Point2D oldPoint = p1;
                for (double i = 0; i < 1; i += t)
                {
                    _line.DrawLine(g, oldPoint, new Point2D((int)x, (int)y));
                    oldPoint = new Point2D((int)x, (int)y);
                    double v = Math.Pow(-i, 3) + 3 * Math.Pow(i, 2);
                    x = p1.X * (v - 3 * i + 1)
                            + 3 * p2.X * i * (Math.Pow(i, 2) - 2 * i + 1)
                            + 3 * p3.X * Math.Pow(i, 2) * (1 - i) + p4.X * Math.Pow(i, 3);
                    y = p1.Y * (v - 3 * i + 1)
                            + 3 * p2.Y * i * (Math.Pow(i, 2) - 2 * i + 1)
                            + 3 * p3.Y * Math.Pow(i, 2) * (1 - i) + p4.Y * Math.Pow(i, 3);
                }
            }
        }

        private double CountLen(Point2D p1, Point2D p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
