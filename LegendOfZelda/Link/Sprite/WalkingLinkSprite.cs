using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class WalkingLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool flashRed;
        private bool animationIsDone;
        private int damageColorCounter;
        private int bufferFrame;
        private int currentFrame;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private const int totalFrames = 2;
        private const int numRows = 1;
        private const int numColumns = 2;
        private const int walkingFrameDelay = 10;
        private bool pokemonOn;

        public WalkingLinkSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
            bufferFrame = 0;
            currentFrame = 0;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
            this.pokemonOn = pokemonOn;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames;
            if (FinishedAnimation()) return;

            if (bufferFrame++ == walkingFrameDelay)
            {
                bufferFrame = 0;
                currentFrame = currentFrame == 1 ? 0 : 1;
            }

            if (++damageColorCounter == LinkConstants.DamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, false, Constants.DrawLayer.Player);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool drawWithDamage, float layer)
        {
            int currentRow = 0;
            int currentColumn = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.TrainerScaler), (int)(frameHeight * Constants.TrainerScaler));
            }

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            Rectangle returning = new Rectangle(0, 0, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
            if (pokemonOn)
            {
                returning = new Rectangle(0, 0, (int)(frameWidth * Constants.TrainerScaler), (int)(frameHeight * Constants.TrainerScaler));
            }
            return returning;
        }
    }
}
