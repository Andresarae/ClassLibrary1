using System;
using System.Drawing;

namespace Cg.Lines
{
    public class WuLine : ILine
    {
        public void DrawLine(Graphics g, Point2D p1, Point2D p2)
        {
            int x1 = (int)p1.X;
            int y1 = (int)p1.Y;
            int x2 = (int)p2.X;
            int y2 = (int)p2.Y;

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            float gradient;

            if (dx > dy)
            {
                gradient = (float)dy / dx;
                float intersectY = y1 + gradient;
                g.FillRectangle(new SolidBrush(Color.Black), x1, y1, 1, 1);
                for (int i = x1; i < x2; i++)
                {
                    int argb = (int)(255 - Fractional(intersectY) * 255);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(CheckArgb(argb), Color.Black)),
                        i, (int)intersectY, 1, 1); //Меняем прозрачность
                    argb = (int)(Fractional(intersectY) * 255);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(CheckArgb(argb), Color.Black)),
                        i, (int)intersectY + 1, 1, 1);
                    intersectY += gradient;
                }
                g.FillRectangle(new SolidBrush(Color.Black), x2, y2, 1, 1);
            }
            else
            {
                gradient = (float)dx / dy;
                float intersectX = x1 + gradient;
                g.FillRectangle(new SolidBrush(Color.Black), x1, y1, 1, 1); // первая точка
                for (int i = y1; i < y2; i++)
                {
                    int argb = (int)(255 - Fractional(intersectX) * 255);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(CheckArgb(argb), Color.Black)),
                        (int)intersectX, i, 1, 1); //Меняем прозрачность    
                    argb = (int)(Fractional(intersectX) * 255);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(CheckArgb(argb), Color.Black)),
                        (int)intersectX + 1, i, 1, 1);
                    intersectX += gradient;
                }
            }
            g.FillRectangle(new SolidBrush(Color.Black), x2, y2, 1, 1); // вторая точка
        }
        private int CheckArgb(int v)
        {
            if (v > 255)
                return 255;
            if (v < 0)
                return 0;
            return v;
        }
        private float Fractional(float x)
        {
            int temp = (int)x;
            return x - temp; // получаем число после запятой
        }

    }
}
