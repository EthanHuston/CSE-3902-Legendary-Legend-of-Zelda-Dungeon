using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Menu.Sprite
{
    internal class TopLeftSelectorSprite : ISprite
    {
        private const int numRows = 1;
        private const int numColumns = 2;
        private const int frameUpdateDelay = 30;
        private readonly Texture2D sprite;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private int frameBuffer;
        private int currentFrame;

        public TopLeftSelectorSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            frameBuffer = 0;
            currentFrame = 0;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
        }

        public void Update()
        {
            if (frameBuffer++ > frameUpdateDelay)
            {
                currentFrame = currentFrame == 1 ? 0 : 1;
                frameBuffer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle sourceRectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * frameWidth), (int)(RoomConstants.SpriteMultiplier * frameHeight));
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, Constants.DrawLayer.MenuButtonSelector);
        }

        public Rectangle GetPositionRectangle()
        {
            return Rectangle.Empty;
        }
    }
}
