using Microsoft.Xna.Framework;

namespace LegendOfZelda.Utility
{
    public class SpawnableMover
    {
        private bool movingDistanceRightNow;
        private int distanceToMove;
        private int totalDistanceMoved;
        private Vector2 movingVelocity;
        private bool overrideNextUpdate;

        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return new Vector2(velocity.X, velocity.Y); }
            set { velocity = new Vector2(value.X, value.Y); }
        }

        private Point position;
        public Point Position
        {
            get { return new Point(position.X, position.Y); }
            set { position = new Point(value.X, value.Y); }
        }

        public SpawnableMover(Point position, Vector2 velocity)
        {
            this.position = new Point(position.X, position.Y);
            this.velocity = new Vector2(velocity.X, velocity.Y);
            movingDistanceRightNow = false;
            totalDistanceMoved = 0;
            overrideNextUpdate = false;
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
            if (overrideNextUpdate)
            {
                overrideNextUpdate = false;
                return;
            }

            position.X += (int)(!movingDistanceRightNow ? velocity.X : movingVelocity.X);
            position.Y += (int)(!movingDistanceRightNow ? velocity.Y : movingVelocity.Y);

            totalDistanceMoved += !movingDistanceRightNow ? 0 : (int)movingVelocity.Length();
            movingDistanceRightNow = totalDistanceMoved > distanceToMove;
        }

        public void MoveOnce(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public void ForceMoveToPoint(Point position)
        {
            Position = position;
            overrideNextUpdate = true;
        }
    }
}