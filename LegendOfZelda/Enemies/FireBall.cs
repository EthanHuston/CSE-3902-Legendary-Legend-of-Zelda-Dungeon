using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Fireball : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int posX, posY, vx, vy;

        public Fireball(SpriteBatch spriteBatch, int posX, int posY, int vy)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateFireballSprite();
            this.posX = posX;
            this.posY = posY;
            this.vy = vy;
            this.vx = -5;
        }

        public void Update()
        {
            posX += vx;
            posY += vy;
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, posX, posY);
        }
        public void ResetPosition()
        {

        }
    }
}
