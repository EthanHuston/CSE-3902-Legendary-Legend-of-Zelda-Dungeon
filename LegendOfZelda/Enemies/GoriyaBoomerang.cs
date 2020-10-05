using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class GoriyaBoomerang : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Vector2 pos, velocity;
        public int retractRang = 20;
        private int updateCount = 0;

        public GoriyaBoomerang(SpriteBatch spriteBatch, Vector2 pos, Vector2 velocity)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateGoriyaBoomerangSprite();
            this.pos = pos;
            this.velocity = velocity;
        }

        public void Update()
        {
            updateCount++;
            if (updateCount < retractRang)
            {
                pos.X += velocity.X;
                pos.Y += velocity.Y;
            }
            else if (updateCount < 2 * retractRang)
            {
                pos.X -= velocity.X;
                pos.Y -= velocity.Y;
            }

        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, (int)pos.X, (int)pos.Y);
        }
        public void ResetPosition()
        {

        }

    }
}
