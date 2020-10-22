using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class MovableSquare : INpc
    {
        private ISprite blockSprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private Point velocity;
        private bool safeToDespawn;
        private bool isPushed;

        public MovableSquare(SpriteBatch spriteBatch, Point spawnPosition)
        {
            blockSprite = EnvironmentSpriteFactory.Instance.CreateBlockSprite();
            this.spriteBatch = spriteBatch;
            position = spawnPosition;
            velocity = Point.Zero;
            safeToDespawn = false;
            isPushed = false;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            blockSprite.Draw(spriteBatch, position);
            spriteBatch.End();
        }

        public void Update()
        {
            if (isPushed)
            {
                position.X += velocity.X;
                position.Y += velocity.Y;
            }
            blockSprite.Update();
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return blockSprite.GetPositionRectangle();
        }

        public Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
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
        void Move(int distance, Vector2 velocity) {
            // do something
        }

        // 0=Up, 1=Down, 2=Left, 3=Right
        public void Push(int direction)
        {
            isPushed = true;
            if (direction == 0)
                velocity.Y = -1 * Constants.MovableSquareVelocity;
            else if (direction == 1)
                velocity.Y = Constants.MovableSquareVelocity;
            else if (direction == 2)
                velocity.X = -1 * Constants.MovableSquareVelocity;
            else if (direction == 3)
                velocity.X = Constants.MovableSquareVelocity;
            else
                isPushed = false;
        }

        public void EndPush()
        {
            isPushed = false;
            velocity = Point.Zero;
        }

        public void ResetPosition()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(double damage)
        {
            throw new System.NotImplementedException();
        }

        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}
