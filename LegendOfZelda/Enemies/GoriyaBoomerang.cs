using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class GoriyaBoomerang : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Vector2 pos, velocity;
        public int retractRang = 30;
        private int updateCount = 0;
        public bool isActive;

        public GoriyaBoomerang(SpriteBatch spriteBatch, Vector2 pos, Vector2 velocity)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateGoriyaBoomerangSprite();
            this.pos = pos;
            this.velocity = velocity;
            isActive = true;
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
            else
                isActive = false;

            sprite.Update();

        }

        public void Draw()
        {
            if (isActive)
                sprite.Draw(spriteBatch, (int)pos.X, (int)pos.Y);
        }
        public void ResetPosition()
        {

        }

    }
}
