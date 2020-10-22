using Microsoft.Xna.Framework;

namespace LegendOfZelda.Utility
{
    public class SpawnableMover
    {
        private Vector2 velocity;
        private Vector2 movingVelocity;
        private Point position;
        private bool movingDistanceRightNow;
        private int distanceToMove;
        private int totalDistanceMoved;

        public SpawnableMover(Point position, Vector2 velocity)
        {
            this.position = new Point(position.X, position.Y);
            this.velocity = new Vector2(velocity.X, velocity.Y);
            movingDistanceRightNow = false;
            this.totalDistanceMoved = 0;
        }

        public void MoveDistance(int distanceToMove, Vector2 movingVelocity)
        {
            movingDistanceRightNow = true;
            this.distanceToMove = distanceToMove;
            this.movingVelocity = movingVelocity;
            totalDistanceMoved = 0;
        }

        public void Update()
        {
            position.X += (int)(!movingDistanceRightNow ? velocity.X : movingVelocity.X);
            position.Y += (int)(!movingDistanceRightNow ? velocity.Y : movingVelocity.Y);

            totalDistanceMoved += !movingDistanceRightNow ? 0 : (int)movingVelocity.Length();
            movingDistanceRightNow = totalDistanceMoved > distanceToMove;
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Vector2 GetVelocity()
        {
            return new Vector2(velocity.X, velocity.Y);
        }

        public void ChangeVelocity(Vector2 newVelocity)
        {
            velocity = new Vector2(newVelocity.X, newVelocity.Y);
        }

        public void SetPosition(Point newPosition)
        {
            position = new Point(newPosition.X, newPosition.Y);
        }

        public void MoveOnce(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
    }
}