using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Interface
{
    interface ILinkItemSprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        bool FinishedAnimation();
    }
}
