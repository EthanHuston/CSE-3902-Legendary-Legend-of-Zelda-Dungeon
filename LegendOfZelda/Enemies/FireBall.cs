using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Fireball : GenericProjectile
    {
        // TODO: needs converted to generic projectile item and moved to items folder I think
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int vx, vy;
        private Point position;

        public Fireball(SpriteBatch spriteBatch, int posX, int posY, int vy)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateFireballSprite();
            position.X = posX;
            position.Y = posY;
            this.vy = vy;
            this.vx = -5; // make constant within class
        }

        override public void Update()
        {
            position.X += vx;
            position.Y += vy;
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }
        public void ResetPosition()
        {

        }
    }
}
