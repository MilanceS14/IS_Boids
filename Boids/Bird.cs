using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Linq;

namespace Boids
{
    public class Bird
    {
        public static double NeighbourRadius = 30;
        public static double SeparateRadius;
        public static double SeparationWeight = 1;
        public static double AlignmentWeight = 1;
        public static double CohesionWeight = 1;
        public static double Speed = 1;
        public Vector Heading;


        public Bird(Random rnd, Form forma)
        {
            PositionX = rnd.Next(forma.Width);
            PositionY = rnd.Next(forma.Height);
            Heading = new Vector((rnd.Next(4) + 1) * Math.Pow(-1, rnd.Next(3)),
                (rnd.Next(4) + 1) * Math.Pow(-1, rnd.Next(3)));
        }

        public Bird(int x, int y, Vector heading)
        {
            PositionX = x;
            PositionY = y;
            Heading = heading;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public double CalculateDistance(Bird secondBird)
        {
            return Math.Sqrt((secondBird.PositionX - PositionX) * (secondBird.PositionX - PositionX)
                             + (secondBird.PositionY - PositionY) * (secondBird.PositionY - PositionY));
        }

        public List<Bird> GetNeighbors(double toleranceAngle = 20)
        {
            var allBirds = Form1.GetAllBirds();
            var neighbors = new List<Bird>();
            double toleranceAngleRadian = Math.PI / 360 * toleranceAngle; // calculation of half an angle in radian

            double inverseAngle = Math.Atan2(-Heading.X, -Heading.Y); // getting inverse vector angle to determine blind spot vector
            foreach (var bird in allBirds)
            {
                if ((PositionX == bird.PositionX && PositionY == bird.PositionY) || CalculateDistance(bird) > NeighbourRadius)
                    continue;

                double angle = Math.Atan2(PositionX - bird.PositionX, PositionY - bird.PositionY); // at what angle is bird seen
                if (inverseAngle - toleranceAngleRadian > angle && inverseAngle + toleranceAngleRadian < angle)
                {
                    // Atan2 returns a number from -Pi to Pi, here we are calculating if the angle is in blind spot
                    continue;
                }

                neighbors.Add(bird);
            }
            return neighbors;
        }

        public Vector calculateSeparationForce(List<Bird> neigbours)
        {
            int x = 0, y = 0;

            x = (neigbours.Sum(bird => bird.PositionX) - neigbours.Count * PositionX) / neigbours.Count;
            y = (neigbours.Sum(bird => bird.PositionY) - neigbours.Count * PositionY) / neigbours.Count;

            var separation = new Vector(-x, -y);
            if (separation.X != 0 || separation.Y != 0)
                separation.Normalize();
            return separation;
        }

        public Vector calculateAlignmentForce(List<Bird> neigbours)
        {
            var aligment = new Vector();
            foreach (var bird in neigbours)
            {
                aligment += bird.Heading;
            }
            aligment /= neigbours.Count;
            if (aligment.X != 0 || aligment.Y != 0)
                aligment.Normalize();
            return aligment;
        }

        public Vector calculateCohesionForce(List<Bird> neigbours)
        {
            int x, y;
            x = neigbours.Sum(bird => bird.PositionX) / neigbours.Count;
            y = neigbours.Sum(bird => bird.PositionY) / neigbours.Count;

            var cohesion = new Vector(x - PositionX, y - PositionY);
            if (cohesion.X != 0 || cohesion.Y != 0)
                cohesion.Normalize();
            return cohesion;
        }

        public Vector calculateAvoidensVector()
        {
            int i = 0, x = 0, y = 0;
            var allPredators = Form1.AllPredators;

            foreach (var bird in allPredators)
            {
                if (CalculateDistance(bird) < 2 * NeighbourRadius)
                {
                    i++;
                    x += bird.PositionX - PositionX;
                    y += bird.PositionY - PositionY;
                }
            }
            if (i == 0)
                return new Vector(0, 0);
            x /= i;
            y /= i;
            return new Vector(-x, -y);
        }

        public Vector calculateObstacleAvoidanceVector(List<Bird> neighbors)
        {
            Obstacle nearestObstacle = null;
            var allObstacles = Form1.AllObstacles;
            double closestDistance = 999999;
            foreach (var obstacle in allObstacles)
            {
                var distance = Math.Sqrt((obstacle.x - PositionX) * (obstacle.x - PositionX) +
                                         (obstacle.y - PositionY) * (obstacle.y - PositionY));
                if (distance <= 3 * NeighbourRadius && distance <= closestDistance)
                {
                    closestDistance = distance;
                    nearestObstacle = obstacle;
                }
            }
            if (nearestObstacle == null)
                return new Vector(0, 0);

            var deadBird = new Bird(PositionX, PositionY, Heading);
            {
                deadBird.PositionX = deadBird.PositionX + Convert.ToInt32(deadBird.Heading.X * 3);
                deadBird.PositionY = deadBird.PositionY + Convert.ToInt32(deadBird.Heading.Y * 3);
            }
            var newDistance =
                Math.Sqrt((nearestObstacle.x - deadBird.PositionX) * (nearestObstacle.x - deadBird.PositionX) +
                          (nearestObstacle.y - deadBird.PositionY) * (nearestObstacle.y - deadBird.PositionY));
            if (newDistance > closestDistance || newDistance > nearestObstacle.r + Form1.BirdWidth)
                return new Vector(0, 0);

            var avoidanceObstacleVector =
                new Vector(nearestObstacle.x - PositionX, nearestObstacle.y - PositionY);

            var perpundicularVector = new Vector(avoidanceObstacleVector.Y, -avoidanceObstacleVector.X);
            if (perpundicularVector.X != 0 || perpundicularVector.Y != 0)
                perpundicularVector.Normalize();
            perpundicularVector = perpundicularVector * (nearestObstacle.r + Form1.BirdWidth / 2);

            avoidanceObstacleVector = avoidanceObstacleVector + perpundicularVector;
            return avoidanceObstacleVector;
        }

        public virtual void CalculateNewPosition(int maxWidth, int maxHeight)
        {
            var neighbors = GetNeighbors();
            if (neighbors.Count != 0)
            {
                var avoidance = calculateAvoidensVector();
                var obstacleAvoidance = calculateObstacleAvoidanceVector(neighbors);

                if (obstacleAvoidance.X != 0 || obstacleAvoidance.Y != 0)
                {
                    Heading += obstacleAvoidance;
                }
                else
                {
                    if (avoidance.X != 0 || avoidance.Y != 0)
                    {
                        Heading += avoidance;
                    }
                    else
                    {
                        var sep = SeparationWeight * calculateSeparationForce(neighbors);
                        var align = AlignmentWeight * calculateAlignmentForce(neighbors);
                        var coh = CohesionWeight * calculateCohesionForce(neighbors);
                        Heading = Heading + sep + align + coh;
                    }
                }

                if (Heading.X != 0 || Heading.Y != 0)
                    Heading.Normalize();
            }

            PositionX = PositionX + Convert.ToInt32(Heading.X * Speed);
            PositionY = PositionY + Convert.ToInt32(Heading.Y * Speed);
            PositionX = PositionX <= 0 ? maxWidth : (PositionX >= maxWidth ? 0 : PositionX);
            PositionY = PositionY <= 0 ? maxHeight : (PositionY >= maxHeight ? 0 : PositionY);
        }
    }
}