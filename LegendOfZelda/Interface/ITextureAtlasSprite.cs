using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interface
{
    interface ITextureAtlasSprite : IItemSprite
    {
        void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation);
    }
}
