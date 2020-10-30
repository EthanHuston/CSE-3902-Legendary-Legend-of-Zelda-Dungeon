using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    class LinkWalkingState : LinkGenericAbstractState
    {
        private int distanceWalked;

        public LinkWalkingState(LinkPlayer link, Constants.Direction direction) : base(link)
        {
            link.FacingDirection = direction;
        }

        public LinkWalkingState(LinkPlayer link, Constants.Direction direction, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
            link.FacingDirection = direction;
        }

        protected override void InitClass()
        {
            distanceWalked = 0;

            switch (link.FacingDirection)
            {
                case Constants.Direction.Up:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
                    link.Velocity = new Vector2(0, -1 * Constants.LinkWalkStepDistanceInterval);
                    break;
                case Constants.Direction.Down:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
                    link.Velocity = new Vector2(0, Constants.LinkWalkStepDistanceInterval);
                    break;
                case Constants.Direction.Left:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
                    link.Velocity = new Vector2(0, -1 * Constants.LinkWalkStepDistanceInterval);
                    break;
                case Constants.Direction.Right:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
                    link.Velocity = new Vector2(0, Constants.LinkWalkStepDistanceInterval);
                    break;
            }
        }

        protected override void UpdateState()
        {
            distanceWalked += (int)link.Velocity.Length();
            if (distanceWalked > Constants.LinkWalkDistanceInterval)
            {
                StopMoving();
            }
        }

        public override void Move(Constants.Direction direction) {
            // TODO: see what happens if we start moving from here
            // Link can only start moving from the LinkStandingStill state
        }
    }
}
