using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;

namespace Boids
{
    public class Predator : Bird
    {
        public static double predatorSpeed = 1;
        public Predator(Random rnd, Form forma) : base(rnd, forma)
        {

        }

        public override void CalculateNewPosition(int maxWidth, int maxHeight)
        {
            var allBirds = Form1.AllBirds;
            double closestDistance = 9999999;
            Bird closestBird = null;
            foreach (var bird in allBirds)
            {
                double distance = CalculateDistance(bird);
                if (closestDistance >= distance && distance < NeighbourRadius * 2)
                {
                    closestBird = bird;
                    closestDistance = distance;
                }
            }

            if (closestBird != null)
            {
                List<Bird> neighbors = GetNeighbors();
                var newHeading = new Vector2(closestBird.PositionX - PositionX, closestBird.PositionY - PositionY);
                Heading += newHeading;

                if ((Heading.X == 0 && Heading.Y == 0) || Double.IsNaN(Heading.X) || Double.IsNaN(Heading.Y))
                    Heading = new Vector2(rnd.Next(100) - 50, rnd.Next(100) - 50);
                Heading = Vector2.Normalize(Heading);
            }
            PositionX += (int)(Heading.X * predatorSpeed);
            PositionY += (int)(Heading.Y * predatorSpeed);
            PositionX = PositionX <= 0 ? maxWidth : (PositionX >= maxWidth ? 0 : PositionX);
            PositionY = PositionY <= 0 ? maxHeight : (PositionY >= maxHeight ? 0 : PositionY);
        }
    }
}
