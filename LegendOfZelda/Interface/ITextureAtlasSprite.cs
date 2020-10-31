using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interface
{
    internal interface ITextureAtlasSprite : ISprite
    {
        void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation);
    }
}
