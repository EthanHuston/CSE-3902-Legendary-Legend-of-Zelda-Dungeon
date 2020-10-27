using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.NotMoving
{
    class LinkStandingStillState : LinkActiveAbstractState
    {
        public LinkStandingStillState(LinkPlayer link) : base(link)
        {
        }

        public LinkStandingStillState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        public LinkStandingStillState(LinkPlayer link, bool damaged, DateTime healthyDateTime, bool walkingToggle) : base(link, damaged, healthyDateTime)
        {
            this.walkingToggle = walkingToggle;
        }

        public LinkStandingStillState(LinkPlayer link, bool damaged, DateTime healthyDateTime, DateTime lastDraggedTime) : this(link, damaged, healthyDateTime)
        {
            this.lastDraggedTime = lastDraggedTime;
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

        public override void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            link.Mover.Update();
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position, damaged);
        }

        public override void StopMoving()
        {
            // Already not moving, do nothing
        }

        public override void UseSword()
        {
            link.State = new LinkAttackingDownState(link, damaged, healthyDateTime);
        }

        public override void UseBow()
        {
            link.State = new LinkUsingBowDownState(link, damaged, healthyDateTime);
        }

        public override void UseBomb()
        {
            link.State = new LinkUsingBombDownState(link, damaged, healthyDateTime);
        }

        public override void UseBoomerang()
        {
            link.State = new LinkUsingBoomerangDownState(link, damaged, healthyDateTime);
        }

        public override void UseSwordBeam()
        {
            link.State = new LinkUsingSwordBeamDownState(link, damaged, healthyDateTime);
        }
    }
}
