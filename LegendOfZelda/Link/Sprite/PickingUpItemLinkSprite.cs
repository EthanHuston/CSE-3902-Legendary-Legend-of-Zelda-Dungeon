using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class PickingUpItemLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int delayCounter;
        private bool pokemonOn;

        public PickingUpItemLinkSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            delayCounter = 0;
            this.pokemonOn = pokemonOn;
        }

        public void Update()
        {
            animationIsDone = delayCounter >= LinkConstants.PickUpItemPauseTicks;
            if (FinishedAnimation()) return;
            delayCounter++;

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
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position.X, position.Y, (int)(sprite.Width * Constants.TrainerScaler), (int)(sprite.Height * Constants.TrainerScaler));
            }
            Rectangle sourceRectangle = sprite.Bounds;
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            Rectangle returning = new Rectangle(0, 0, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
            if (pokemonOn)
            {
                returning = new Rectangle(0, 0, (int)(sprite.Width * Constants.TrainerScaler), (int)(sprite.Height * Constants.TrainerScaler));
            }
            return returning;
        }
    }
}
