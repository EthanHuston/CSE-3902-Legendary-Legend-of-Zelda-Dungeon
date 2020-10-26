using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    class FireballSprite : IProjectileSprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;

        public FireballSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 1;
            Columns = 4;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 3)
            {
                bufferFrame = 0;
                currentFrame++;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, Constants.SpriteScaler * width, Constants.SpriteScaler * height);

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            Draw(spriteBatch, position);
        }

        public Rectangle GetPositionRectangle()
        {
            throw new System.NotImplementedException();
        }

        public bool FinishedAnimation()
        {
            return false; // animation does not finish
        }
    }
}
