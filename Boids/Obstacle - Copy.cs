using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    public class Obstacle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int r { get; set; }

        public Obstacle()
        {
            
        }
        public Obstacle(Random rnd, Form1 forma)
        {
            x = rnd.Next(forma.Width);
            y = rnd.Next(forma.Height);
            r = rnd.Next(50)+10;
        }
        public Obstacle(int X, int Y, int R)
        {
            x = X;
            y = Y;
            r = R;
        }
    }
}
