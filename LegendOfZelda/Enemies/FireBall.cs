using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Fireball : GenericProjectile
    {
        // TODO: needs converted to generic projectile item and moved to items folder I think
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
            this.vx = -5; // make constant within class
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
