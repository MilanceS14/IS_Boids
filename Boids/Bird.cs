using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Numerics;

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
        public Vector2 Heading;
        protected Random rnd;


        public Bird(Random rnd, Form forma)
        {
            PositionX = rnd.Next(forma.Width);
            PositionY = rnd.Next(forma.Height);
            Heading = new Vector2(rnd.Next(100) - 50, rnd.Next(100) - 50);
            Heading = Vector2.Normalize(Heading);
            this.rnd = rnd;
        }

        public Bird(int x, int y, Vector2 heading, Random rnd)
        {
            PositionX = x;
            PositionY = y;
            Heading = heading;
            this.rnd = rnd;
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

        public Vector2 CalculateSeparationForce(List<Bird> neigbours)
        {
            Vector2 separation = new Vector2(0, 0);
            foreach (Bird bird in neigbours)
            {
                Vector2 newVector = new Vector2(bird.PositionX - PositionX, bird.PositionY - PositionY);
                Vector2.Multiply(newVector, (float)(1 / CalculateDistance(bird)));
                separation -= newVector;
            }
            if (separation.X != 0 || separation.Y != 0)
                separation = Vector2.Normalize(separation);
            return separation;
        }

        public Vector2 CalculateAlignmentForce(List<Bird> neigbours)
        {
            var aligment = new Vector2();
            foreach (var bird in neigbours)
            {
                aligment += bird.Heading;
            }
            aligment /= neigbours.Count;
            if (aligment.X != 0 || aligment.Y != 0)
                aligment = Vector2.Normalize(aligment);
            return aligment;
        }

        public Vector2 CalculateCohesionForce(List<Bird> neigbours)
        {
            int x, y;
            x = neigbours.Sum(bird => bird.PositionX) / neigbours.Count - PositionX;
            y = neigbours.Sum(bird => bird.PositionY) / neigbours.Count - PositionY;

            var cohesion = new Vector2(x, y);
            if (cohesion.X != 0 || cohesion.Y != 0)
                cohesion = Vector2.Normalize(cohesion);
            return cohesion;
        }

        public Vector2 CalculateAvoidensVector()
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
                return new Vector2(0, 0);
            x /= i;
            y /= i;
            return new Vector2(-x, -y);
        }

        public virtual void CalculateNewPosition(int maxWidth, int maxHeight)
        {
            var neighbors = GetNeighbors();
            if (neighbors.Count != 0)
            {
                var avoidance = CalculateAvoidensVector();

                if (avoidance.X != 0 || avoidance.Y != 0)
                {
                    Heading += avoidance;
                }
                else
                {
                    var sep = CalculateSeparationForce(neighbors) * (float)SeparationWeight;
                    var align = CalculateAlignmentForce(neighbors) * (float)AlignmentWeight;
                    var coh = CalculateCohesionForce(neighbors) * (float)CohesionWeight;
                    Heading = Heading + sep + align + coh;
                }

                if ((Heading.X == 0 && Heading.Y == 0) || double.IsNaN(Heading.X) || Double.IsNaN(Heading.Y))
                    Heading = new Vector2(rnd.Next(100) - 50, rnd.Next(100) - 50);
                Heading = Vector2.Normalize(Heading);
            }

            PositionX += (int)(Heading.X * Speed);
            PositionY += (int)(Heading.Y * Speed);
            PositionX = PositionX <= 0 ? maxWidth : (PositionX >= maxWidth ? 0 : PositionX);
            PositionY = PositionY <= 0 ? maxHeight : (PositionY >= maxHeight ? 0 : PositionY);
        }
    }
}