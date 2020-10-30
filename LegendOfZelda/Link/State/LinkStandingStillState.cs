using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    class LinkStandingStillState : LinkGenericAbstractState
    {
        public LinkStandingStillState(LinkPlayer link) : base(link)
        {
        }

        public LinkStandingStillState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            switch (link.FacingDirection)
            {
                case Constants.Direction.Up:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkUpSprite();
                    break;
                case Constants.Direction.Down:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
                    break;
                case Constants.Direction.Left:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkLeftSprite();
                    break;
                case Constants.Direction.Right:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkRightSprite();
                    break;
            }
            link.Velocity = (Vector2.Zero);
        }

        protected override void UpdateState()
        {
            // no updates to do-- handled by parent
        }
    }
}
