using Microsoft.Xna.Framework;
using System;

namespace Sprint0
{
    static class Utility
    {
        public static bool ItemIsOutOfBounds(Vector2 position)
        {
            return position.X > Constants.MaxXPos || position.X < Constants.MinXPos || position.Y > Constants.MaxYPos || position.Y < Constants.MinYPos;
        }

        public class QuadraticCalculator
        {
            private double total;
            private double termA; // f(x) = **ax** + bx^2 + c
            private double termB; // f(x) = ax + **bx^2** + c
            private double termC; // f(x) = ax + bx^2 + **c**
            
            public QuadraticCalculator(Vector2 pointA, Vector2 pointB)
            {
                // calculate equation for point a
                double aY = pointA.Y;
                double aA = pointA.X;
                double aB = Math.Pow(pointA.X, 2);

                // calculate equation for point b
                double bY = pointB.Y;
                double bA = pointB.X;
                double bB = Math.Pow(pointB.X, 2);


            }
        }
    }
}
