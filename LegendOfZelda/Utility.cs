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

        public static double GetDistance(Vector2 position1, Vector2 position2) {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }
    }
}
