using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class BannerEnemy
    {
        private ISprite sprite;
        private Point pos;
        private Point velocity = new Point(-3, 0);

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
            if (pos.X <= 0 - sprite.GetPositionRectangle().Width)
            {
                pos = new Point(HUDConstants.hudWidth, pos.Y);
            }
            sprite.Update();
        }
    }
}
