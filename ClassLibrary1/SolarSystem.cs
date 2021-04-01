using Cg.Lines;
using System.Collections.Generic;
using System.Drawing;

namespace Cg
{
    public class SolarSystem
    {
        public Planet Planet { get; set; }
        public List<Planet> Planets { get; set; }
        public Size Size { get; set; }
        public List<Brush> Colors { get; set; }
        public SolarSystem(List<Planet> planets)
        {
            Planets = planets;
        }
        public void Add(Planet p)
        {
            Planets.Add(p);
        }
        public void Remove(Planet p)
        {
            Planets.Remove(p);
        }
        public void DrawSystem(Graphics g)
        {
            foreach (Planet p in Planets)
            {
                p.ObjLocation();
                p.Draw(g);
            }
        }
        public void UpdateSystem()
        {
            Planets[0].Point = new Point2D(Size.Width / 2, Size.Height / 2);
            foreach (Planet p in Planets)
            {
                p.Update(1000);
            }
        }
        public void CreateSolarSystem()
        {
            Planet sun = new Planet(60, Color.Yellow, new Point2D(Size.Width / 2, Size.Height / 2));
            Planet mercury = new Planet(sun, 80, 8, 0.5f, Color.Red, 10, 1);
            Planet venus = new Planet(sun, 110, 9, 0.1f, Color.DarkOrange, 15, 1);
            Planet earth = new Planet(sun, 150, 12, 0.2f, Color.Green, 18, 1);
            Planet moon = new Planet(earth, 17, 3, 0.2f, Color.Gray, 55, 1);
            Planet mars = new Planet(sun, 225, 10, 0.7f, Color.Red, 17, 1);
            Planet upiter = new Planet(sun, 275, 25, 0.9f, Color.RosyBrown, 13, 1);
            Planet cerera = new Planet(upiter, 45, 6, 0.2f, Color.Gray, 45, 1);
            Planet saturn = new Planet(sun, 350, 45, 0.3f, Color.SandyBrown, 10, 1);
            Planet titan = new Planet(saturn, 56, 7, 0.2f, Color.BlueViolet, 35, 1);
            Planet uran = new Planet(sun, 435, 20, 0.9f, Color.Cyan, 12, 1);
            Planet neptune = new Planet(sun, 500, 18, 0.4f, Color.Blue, 7, 1);
            Planets.Add(sun);
            Planets.Add(mercury);
            Planets.Add(venus);
            Planets.Add(earth);
            Planets.Add(moon);
            Planets.Add(mars);
            Planets.Add(upiter);
            Planets.Add(cerera);
            Planets.Add(saturn);
            Planets.Add(titan);
            Planets.Add(uran);
            Planets.Add(neptune);
        }
    }
}
