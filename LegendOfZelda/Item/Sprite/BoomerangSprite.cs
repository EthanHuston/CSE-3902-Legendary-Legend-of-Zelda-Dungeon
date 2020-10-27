using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item.Sprite
{
    internal class BoomerangSprite : ISprite
    {
        private readonly Texture2D sprite;
        private Rectangle destinationRectangle;

        public BoomerangSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = Rectangle.Empty;
        }
        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int width = (int)((float)sprite.Width / (float)3);
            destinationRectangle = new Rectangle(position.X, position.Y, Constants.SpriteScaler * width, Constants.SpriteScaler * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

        public bool FinishedAnimation()
        {
            return false; // animation never finishes
        }
    }
}
