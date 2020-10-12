using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    static class Utility
    {
        public static bool ItemIsOutOfBounds(Point position)
        {
            return position.X > Constants.MaxXPos || position.X < Constants.MinXPos || position.Y > Constants.MaxYPos || position.Y < Constants.MinYPos;
        }

        public static double GetDistance(Point position1, Point position2)
        {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }
    }
}
