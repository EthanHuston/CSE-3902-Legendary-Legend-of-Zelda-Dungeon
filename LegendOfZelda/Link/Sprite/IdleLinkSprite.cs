using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class IdleLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool flashRed;
        private int damageColorCounter;
        private readonly bool pokemonOn;

        public IdleLinkSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
            this.pokemonOn = pokemonOn;
        }

        public void Update()
        {
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
            Rectangle destinationRectangle = new Rectangle(position, new Point((int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Height)));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position, new Point((int)(Constants.TrainerScaler * sprite.Width), (int)(Constants.TrainerScaler * sprite.Height)));
            }
            Rectangle sourceRectangle = sprite.Bounds;
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return true; // because animation can be exited at any time
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
