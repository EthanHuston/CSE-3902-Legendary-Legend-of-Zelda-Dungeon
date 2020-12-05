using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.HUDClasses
{
    internal class BannerLink
    {

        private readonly Banner banner;
        private readonly ILinkSprite sprite;
        private Point pos;
        private Point velocity = new Point(-3, 0);
        private readonly int largestSpriteWidth = (int)(24 * Constants.GameScaler);

        public BannerLink(Banner banner, Point startingPos)
        {
            this.banner = banner;
            sprite = LinkSpriteFactory.Instance.CreateWalkingLeftLinkSprite();
            pos = startingPos;
        }

        public void Draw()
        {
            sprite.Draw(banner.spriteBatch, pos, false, 8);
        }

        public void Update()
        {
            pos += velocity;
            if (pos.X <= 0 - largestSpriteWidth)
            {
                pos = new Point(HUDConstants.hudWidth, pos.Y);
                banner.loopCount = banner.loopCount + 1;
            }
            sprite.Update();
        }
    }
}
