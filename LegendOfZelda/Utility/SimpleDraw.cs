using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Utility
{
    internal static class SimpleDraw
    {
        public static void Draw(SpriteBatch spriteBatch, Texture2D sprite, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color, float rotation, Vector2 rotationOrigin, SpriteEffects effects, float layer)
        {
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, color, rotation, rotationOrigin, effects, layer / 10f);
        }

        public static void Draw(SpriteBatch spriteBatch, Texture2D sprite, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color, float layer)
        {
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, color, 0, Vector2.Zero, default, layer / 10f);
        }
    }
}
