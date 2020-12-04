using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class HandSprite : IDamageableSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 2;
        private const int numColumns = 2;
        private int currentFrame;
        private int bufferFrame;
        private readonly bool currentDir;
        private readonly int rightRow;
        private readonly int leftRow;
        private bool flashRed;
        private int damageColorCounter;
        private readonly int width;
        private readonly int height;
        private bool pokemonOn;

        public HandSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            currentDir = true;
            rightRow = 0;
            leftRow = 0;
            flashRed = false;
            damageColorCounter = 0;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
            this.pokemonOn = pokemonOn;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == 2)
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
            Draw(spriteBatch, position, false, Constants.DrawLayer.Enemy);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged, float layer)
        {
            int row;
            if (currentDir)
            {
                row = rightRow;
            }
            else
            {
                row = leftRow;
            }

            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * width), (int)(Constants.GameScaler * height));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.PokemonScaler * width), (int)(Constants.PokemonScaler * height));
            }

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, flashRed && damaged ? Color.Red : Color.White, layer);
        }
        public Rectangle GetPositionRectangle()
        {
            Rectangle returning = new Rectangle(0, 0, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));
            if (pokemonOn)
            {
                returning = new Rectangle(0, 0, (int)(width * Constants.PokemonScaler), (int)(height * Constants.PokemonScaler));
            }
            return returning;
        }
    }
}
