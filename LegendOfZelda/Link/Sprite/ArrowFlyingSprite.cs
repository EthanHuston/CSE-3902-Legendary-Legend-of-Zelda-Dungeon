using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class ArrowFlyingSprite : ILinkItemSprite
    {
        private Texture2D sprite;
        public ArrowFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            // All updating is done in the class for this entity
        }

        public bool FinishedAnimation()
        {
            return false; // not used
        }
    }
}
