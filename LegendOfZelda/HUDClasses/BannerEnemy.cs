using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class BannerEnemy
    {
        private readonly ISprite sprite;
        private Point pos;
        private Point velocity = new Point(-3, 0);
        private readonly int largestSpriteWidth = (int)(24 * Constants.GameScaler);

        public BannerEnemy(ISprite enemySprite, Point startingPos)
        {
            sprite = enemySprite;
            pos = startingPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, pos, 8);
        }

        public void Update()
        {
            pos += velocity;
            if (pos.X <= 0 - largestSpriteWidth)
            {
                pos = new Point(HUDConstants.hudWidth, pos.Y);
            }
            sprite.Update();
        }
    }
}
