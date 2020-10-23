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

        public static Constants.Direction GetCollisionDirection(Rectangle mainSpawnable, Rectangle secondarySpawnable, Rectangle collisionFound)
        {
            // return the side the collision is on
            if (collisionFound.Height > collisionFound.Width) // will be a right or left collision -- check by comparing X values of spawnables
            {
                return mainSpawnable.X > secondarySpawnable.Y ? Constants.Direction.Right : Constants.Direction.Left;
            } else // else width > height -- so up or down collision -- check by comparing Y values of spawnables
            {
                return mainSpawnable.Y > secondarySpawnable.Y ? Constants.Direction.Down : Constants.Direction.Up;
            }
        }

        public static Constants.Direction InvertDirection(Constants.Direction direction)
        {
            switch(direction)
            {
                case Constants.Direction.Right:
                    return Constants.Direction.Left;
                case Constants.Direction.Left:
                    return Constants.Direction.Right;
                case Constants.Direction.Down:
                    return Constants.Direction.Up;
                case Constants.Direction.Up:
                    return Constants.Direction.Down;
            }

            return Constants.Direction.Right;
        }
    }
}
