using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Merchant : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        protected bool itemIsExpired;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Merchant(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void ResetPosition()
        {

        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            itemIsExpired = true;
        }

        public void TakeDamage(double damage)
        {
            // ye merchant knoweth no concept of health
        }

        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            // cannot be knocked back
        }
    }
}
