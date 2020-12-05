using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class PickingUpTriforceLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int currentFrame;
        private int bufferFrame;
        private int delayCounter;
        private readonly int totalFrames;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private const int numRows = 1;
        private const int numColumns = 2;
        private readonly bool pokemonOn;

        public PickingUpTriforceLinkSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            delayCounter = 0;
            totalFrames = numRows * numColumns;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
            this.pokemonOn = pokemonOn;
        }

        public void Update()
        {
            animationIsDone = delayCounter >= LinkConstants.PickUpItemPauseTicks;
            if (FinishedAnimation()) return;
            delayCounter++;

            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            if (++damageColorCounter == LinkConstants.DamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, false, Constants.DrawLayer.LinkDead);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool drawWithDamage, float layer)
        {
            if (FinishedAnimation()) return;

            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.TrainerScaler), (int)(frameHeight * Constants.TrainerScaler));
            }

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White, Constants.DrawLayer.LinkDead);
        }

        public bool FinishedAnimation()
        {
            return false;
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
