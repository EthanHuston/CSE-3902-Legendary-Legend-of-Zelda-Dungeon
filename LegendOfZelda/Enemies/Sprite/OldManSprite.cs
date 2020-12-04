using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class OldManSprite : ISprite
    {
        private readonly Texture2D sprite;

        public OldManSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            // no update needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            //o need to change scalar as sprite is already a good size.
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Width));
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
        }
    }
}
