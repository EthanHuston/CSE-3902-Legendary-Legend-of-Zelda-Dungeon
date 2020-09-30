using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Link.Interface
{
    interface ILinkItemSprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        bool FinishedAnimation();
    }
}
