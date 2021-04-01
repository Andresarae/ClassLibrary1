using Cg.Lines;
using System.Drawing;

namespace Cg
{
    public class Graph
    {
        private int UnitSegment;
        private int Width;
        private int Height;
        private WuLine _line = new WuLine();

        public Graph(int unitSegment, int width, int height)
        {
            UnitSegment = unitSegment;
            Width = width;
            Height = height;
        }

        public void CreateA(Graphics g)
        {
            CreateAxis(g);
            int unitSegmentLine = UnitSegment / 2;
            for (int i = Height / 2 + unitSegmentLine; i < Height; i += UnitSegment)
            {
                _line.DrawLine(g, new Point2D(Width / 2 - unitSegmentLine / 2, i), new Point2D(Width / 2 + unitSegmentLine / 2, i));
            }
            for (int i = Width / 2 + unitSegmentLine; i < Width; i += UnitSegment)
            {
                _line.DrawLine(g, new Point2D(i, Height / 2 - unitSegmentLine / 2), new Point2D(i, Height / 2 + unitSegmentLine / 2));
            }
            for (int i = Height / 2 - unitSegmentLine; i >= 0; i -= UnitSegment)
            {
                _line.DrawLine(g, new Point2D(Width / 2 - unitSegmentLine / 2, i), new Point2D(Width / 2 + unitSegmentLine / 2, i));
            }
            for (int i = Width / 2 - unitSegmentLine; i >= 0; i -= UnitSegment)
            {
                _line.DrawLine(g, new Point2D(i, Height / 2 - unitSegmentLine / 2), new Point2D(i, Height / 2 + unitSegmentLine / 2));
            }
        }

        public void CreateGraph(Graphics g)
        {

        }

        private void CreateAxis(Graphics g)
        {
            _line.DrawLine(g, new Point2D(Width / 2, 0), new Point2D(Width / 2, Height));
            _line.DrawLine(g, new Point2D(0, Height / 2), new Point2D(Width, Height / 2));
        }
    }
}
