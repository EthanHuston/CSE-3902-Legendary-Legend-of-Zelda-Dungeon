using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Utility
{
    static class UtilityMethods
    {
        public static bool ItemIsOutOfBounds(Point position)
        {
            return position.X > Constants.MaxXPos || position.X < Constants.MinXPos || position.Y > Constants.MaxYPos || position.Y < Constants.MinYPos;
        }

        public static double GetDistance(Point position1, Point position2)
        {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }

        public static Constants.Direction GetCollisionDirection(Rectangle rectangle1, Rectangle rectangle2, Rectangle collisionFound)
        {
            throw new NotImplementedException();
        }
    }
}
