using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal class LinkWalkingState : LinkGenericAbstractState
    {
        private const int stepDistance = (int)(1 * Constants.GameScaler);
        private bool stillMoving;

        public LinkWalkingState(LinkPlayer link, Constants.Direction direction, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            spawnOffset = Point.Zero;
            link.FacingDirection = direction;
            stillMoving = true;
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

        public override void Update()
        {
            if (!stillMoving) StopMoving();
            base.Update();
            stillMoving = false;
        }

        protected override void UpdateState() { }

        public override void Move(Constants.Direction direction)
        {
            if (direction == link.FacingDirection) stillMoving = true;
            else base.Move(direction);
        }
    }
}
