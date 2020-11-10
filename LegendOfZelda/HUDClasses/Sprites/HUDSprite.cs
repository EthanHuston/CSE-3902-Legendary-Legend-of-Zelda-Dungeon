using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.HUDClasses.Sprite
{
    class HUDSprite : ISprite
    {
        private readonly Texture2D sprite;

        public HUDSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Height));
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0,0,(int)(sprite.Width * Constants.GameScaler),(int)(sprite.Height * Constants.GameScaler));
        }
    }
}
