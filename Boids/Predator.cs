using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;

namespace Boids
{
    public class Predator : Bird
    {
        public static double predatorSpeed = 1;
        public Predator(Random rnd, Form forma): base(rnd, forma)
        {

        }

        public override void CalculateNewPosition(int maxWidth, int maxHeight)
        {
            var allBirds = Form1.AllBirds;
            double closestDistance = 9999999;
            Bird closestBird = null;
            foreach (var bird in allBirds)
            {
                if (closestDistance >= CalculateDistance(bird))
                {
                    closestBird = bird;
                    closestDistance = CalculateDistance(bird);
                }
            }
            if (closestBird != null)
            {
                List<Bird> neighbors = GetNeighbors();
                Vector obstacleAvoidans = calculateObstacleAvoidanceVector(neighbors);
                var newHeading = new Vector(closestBird.PositionX - PositionX, closestBird.PositionY - PositionY);
                if (obstacleAvoidans.X != 0 || obstacleAvoidans.Y != 0)
                {
                    Heading.X = Heading.X + obstacleAvoidans.X;
                    Heading.Y = Heading.Y + obstacleAvoidans.Y;
                }
                else
                {
                    Heading.X = Heading.X + newHeading.X;
                    Heading.Y = Heading.Y + newHeading.Y;
                }
                if (Heading.X != 0 || Heading.Y != 0)
                    Heading.Normalize();
            }
            PositionX = PositionX + Convert.ToInt32(Heading.X * predatorSpeed);
            PositionY = PositionY + Convert.ToInt32(Heading.Y * predatorSpeed);
            PositionX = PositionX <= 0 ? maxWidth : (PositionX >= maxWidth ? 0 : PositionX);
            PositionY = PositionY <= 0 ? maxHeight : (PositionY >= maxHeight ? 0 : PositionY);
        }
    }
}
