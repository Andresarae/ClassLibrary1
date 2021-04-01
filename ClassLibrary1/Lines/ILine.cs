using System.Drawing;

namespace Cg.Lines
{
    public interface ILine
    {
        void DrawLine(Graphics g, Point2D p1, Point2D p2);
    }
}
