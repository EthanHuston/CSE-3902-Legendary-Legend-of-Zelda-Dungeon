using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Merchant : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;
        protected bool itemIsExpired;

        public Merchant(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            this.spriteBatch = spriteBatch;
            position = spawnPosition;

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

        public void SetPosition(Point position)
        {
            this.position = new Point(position.X, position.Y);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Point GetPosition()
        {
            return position;
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
            throw new System.NotImplementedException();
        }
    }
}
