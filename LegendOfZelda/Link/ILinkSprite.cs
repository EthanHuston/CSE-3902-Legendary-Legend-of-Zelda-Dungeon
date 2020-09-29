using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Link
{
    interface ILinkSprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage);
        bool finishedAnimation();
    }
}
