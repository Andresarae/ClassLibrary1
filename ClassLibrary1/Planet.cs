using Cg.Lines;
using System;
using System.Drawing;

namespace Cg
{
    public class Planet
    {
        public int Length { get; set; }
        public float Radius { get; set; }
        public float Angle { get; set; }
        public Color Color { get; set; }
        public double Speed { get; set; }
        public Point2D Point { get; set; }
        public Planet Parent { get; set; }
        public double Ellipse { get; set; }
        public Planet(int radius, Color c, Point2D point)
        {
            Color = c;
            Radius = radius;
            Point = point;
        }
        public Planet(Planet p, int length, int radius, float angle, Color c, double speed, double ellipse) // если не родитель
        {
            Parent = p;
            Length = length;
            Radius = radius;
            Angle = angle;
            Color = c;
            Speed = speed;
            Ellipse = ellipse;
        }
        public void ObjLocation()
        {
            Point2D P;

            if (Parent != null)
                P = Parent.Point;
            else
                P = Point;

            double x = P.X + (Length * Ellipse * Math.Cos(Angle));
            double y = P.Y + (Length * Math.Sin(Angle));
            Point = new Point2D((float)x, (float)y);
        }
        public PlanetParameters ObjParameters()
        {
            return null;
        }

        public void Update(double dt)
        {
            Angle += (float)(Speed / dt);
        }

        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color);
            g.FillEllipse(brush, (float)(Point.X - Radius), (float)(Point.Y - Radius), (float)(Radius * 2), (float)(Radius * 2));

            g.FillEllipse(new SolidBrush(Color.FromArgb(5, Color.R, Color.G, Color.B)), (float)(Point.X - Radius * 2), (float)(Point.Y - Radius * 2),
                Radius * 4, Radius * 4);
            g.FillEllipse(new SolidBrush(Color.FromArgb(50, Color.R, Color.G, Color.B)), (float)(Point.X - Radius * 1.5f), (float)(Point.Y - Radius * 1.5f),
                Radius * 3, Radius * 3);
        }
    }
}
