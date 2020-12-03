using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    internal class MovableSquare : IBlock
    {
        private readonly ISprite blockSprite;
        private readonly SpriteBatch spriteBatch;
        private Vector2 velocity;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private bool hasBeenPushed;
        private bool pushingInProgress;
        private int totalDistanceTravelled;
        private Point originalPosition;
        private const int travelDistance = (int)(16 * Constants.GameScaler);

        public readonly Constants.Direction TriggerDirection = Constants.Direction.Left;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public MovableSquare(SpriteBatch spriteBatch, Point spawnPosition)
        {
            blockSprite = EnvironmentSpriteFactory.Instance.CreateSquareSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            originalPosition = spawnPosition;
            velocity = Vector2.Zero;
            SafeToDespawn = false;
            hasBeenPushed = false;
            pushingInProgress = false;
        }

        public void Draw()
        {
            blockSprite.Draw(spriteBatch, position, Constants.DrawLayer.Block);
        }

        public void Update()
        {
            if (pushingInProgress)
            {
                position.X += (int)velocity.X;
                position.Y += (int)velocity.Y;
                totalDistanceTravelled += (int)velocity.Length();
                if (totalDistanceTravelled >= travelDistance) EndPush();
            }
            blockSprite.Update();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, blockSprite.GetPositionRectangle().Width, blockSprite.GetPositionRectangle().Height);
        }
        
        

        // 0=Up, 1=Down, 2=Left, 3=Right
        public void Push(Constants.Direction direction)
        {
            if (hasBeenPushed) return;
            switch (direction)
            {
                case Constants.Direction.Up:
                    velocity.Y = -1 * Constants.MovableSquareVelocity;
                    break;
                case Constants.Direction.Down:
                    velocity.Y = Constants.MovableSquareVelocity;
                    break;
                case Constants.Direction.Left:
                    velocity.X = -1 * Constants.MovableSquareVelocity;
                    break;
                case Constants.Direction.Right:
                    velocity.X = Constants.MovableSquareVelocity;
                    break;
                default:
                    return;
            }

            hasBeenPushed = true;
            pushingInProgress = true;
        }

        public void EndPush()
        {
            hasBeenPushed = true;
            velocity = Vector2.Zero;
        }

        public bool HasBeenPushed()
        {
            return hasBeenPushed;
        }

        public void RoomReset()
        {
            hasBeenPushed = false;
            Position = originalPosition;
            pushingInProgress = false;
            totalDistanceTravelled = 0;
        }
    }
}
