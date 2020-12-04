using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class SpikeTrapSprite : IDamageableSprite
    {
        private readonly Texture2D sprite;
        private bool pokemonOn;

        public SpikeTrapSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            this.pokemonOn = pokemonOn;
        }
        public void Update()
        {
            // no update needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Height));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.PokemonScaler * sprite.Width), (int)(Constants.PokemonScaler * sprite.Height));
            }

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged, float layer)
        {
            Draw(spriteBatch, position, false, Constants.DrawLayer.Enemy);
        }

        public Rectangle GetPositionRectangle()
        {
            Rectangle returning = new Rectangle(0, 0, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
            if (pokemonOn)
            {
                returning = new Rectangle(0, 0, (int)(sprite.Width * Constants.PokemonScaler), (int)(sprite.Height * Constants.PokemonScaler));
            }
            return returning;
        }
    }
}
