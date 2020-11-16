using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal class LinkWalkingState : LinkGenericAbstractState
    {
        private const int stepDistance = (int)(1 * Constants.GameScaler);

        public LinkWalkingState(LinkPlayer link, Constants.Direction direction, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            spawnOffset = Point.Zero;
            link.FacingDirection = direction;
            InitClass();
        }

        protected override void InitClass()
        {
            switch (link.FacingDirection)
            {
                case Constants.Direction.Up:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingUpLinkSprite();
                    link.Velocity = new Vector2(0, -1 * stepDistance);
                    break;
                case Constants.Direction.Down:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
                    link.Velocity = new Vector2(0, stepDistance);
                    break;
                case Constants.Direction.Left:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingLeftLinkSprite();
                    link.Velocity = new Vector2(-1 * stepDistance, 0);
                    break;
                case Constants.Direction.Right:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingRightLinkSprite();
                    link.Velocity = new Vector2(stepDistance, 0);
                    break;
            }
        }

        protected override void UpdateState()
        {
        }

        public override void Move(Constants.Direction direction)
        {
            if (direction == link.FacingDirection) return;
            base.Move(direction);
        }
    }
}
