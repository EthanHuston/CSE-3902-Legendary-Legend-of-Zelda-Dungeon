using LegendOfZelda.Enemies;
using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class MovableSquare : INpc
    {
        private ISprite blockSprite;
        private SpriteBatch spriteBatch;
        private Vector2 velocity;
        private bool safeToDespawn;
        private bool isPushed;
        private int totalDistanceTravelled;
        private const int travelDistance = 20;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public MovableSquare(SpriteBatch spriteBatch, Point spawnPosition)
        {
            blockSprite = EnvironmentSpriteFactory.Instance.CreateBlockSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            velocity = Vector2.Zero;
            safeToDespawn = false;
            isPushed = false;
        }

        public void Draw()
        {
            blockSprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            if (isPushed)
            {
                position.X += (int) velocity.X;
                position.Y += (int) velocity.Y;
                totalDistanceTravelled += (int) velocity.Length();
                if (totalDistanceTravelled >= travelDistance) EndPush();
            }
            blockSprite.Update();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, blockSprite.GetPositionRectangle().X, blockSprite.GetPositionRectangle().Y);
        }

        public Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        // 0=Up, 1=Down, 2=Left, 3=Right
        public void Push(Constants.Direction direction)
        {
            isPushed = true;
            if (direction == Constants.Direction.Up)
                velocity.Y = -1 * Constants.MovableSquareVelocity;
            else if (direction == Constants.Direction.Down)
                velocity.Y = Constants.MovableSquareVelocity;
            else if (direction == Constants.Direction.Left)
                velocity.X = -1 * Constants.MovableSquareVelocity;
            else if (direction == Constants.Direction.Right)
                velocity.X = Constants.MovableSquareVelocity;
            else
                isPushed = false;
        }

        public void EndPush()
        {
            isPushed = false;
            velocity = Vector2.Zero;
        }

        public void TakeDamage(double damage)
        {
            //Do Nothing
        }

        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            //Do Nothing
        }

        public double GetDamageAmount()
        {
            return 0.0;
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
    }
}
