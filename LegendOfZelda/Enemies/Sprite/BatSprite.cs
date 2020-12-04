using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class BatSprite : IDamageableSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 2;
        private const int numColumns = 1;
        private const int frameDelay = 20;
        private int currentFrame;
        private int bufferFrame;
        private readonly int totalFrames;
        private bool flashRed;
        private int damageColorCounter;
        private readonly int width;
        private readonly int height;

        public BatSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
            flashRed = false;
            damageColorCounter = 0;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
        }

        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == frameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            if (++damageColorCounter == Constants.EnemyDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, false, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged, float layer)
        {
            int row = (int)(currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * width), (int)(Constants.GameScaler * height));

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, flashRed && damaged ? Color.Red : Color.White, layer);
        }
        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));
        }
    }
}
