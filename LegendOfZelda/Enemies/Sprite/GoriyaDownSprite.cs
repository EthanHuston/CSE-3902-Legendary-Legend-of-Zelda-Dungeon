using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    class GoriyaDownSprite : IDamageableSprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        private int spriteScaler = Constants.SpriteScaler;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private bool flashRed;
        private int damageColorCounter;

        public GoriyaDownSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = Columns * Rows;
            flashRed = false;
            damageColorCounter = 0;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 6)
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

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            sourceRectangle = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle(position.X, position.Y, spriteScaler * width, spriteScaler * height);

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && damaged ? Color.Red : Color.White);

        }
        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

    }
}
