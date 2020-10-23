using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingLeftState : LinkActiveAbstractState
    {
        int distanceWalked;

        public LinkWalkingLeftState(LinkPlayer link) : base(link)
        {
        }

        public LinkWalkingLeftState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            distanceWalked = 0;
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingLeftLinkSprite();
            link.Velocity = new Vector2(-1 * Constants.LinkWalkStepDistanceInterval, 0);
        }

        public override void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.Mover.Update();
            distanceWalked += (int)link.Mover.Velocity.Length();
            link.CurrentSprite.Update();

            if (distanceWalked > Constants.LinkWalkDistanceInterval)
            {
                StopMoving();
            }
        }
        public override void MoveLeft()
        {
            // Already moving left, do nothing
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position, damaged);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillLeftState(link, damaged, healthyDateTime);
        }

        public override void UseSword()
        {
            link.State = new LinkAttackingLeftState(link, damaged, healthyDateTime);
        }

        public override void UseBow()
        {
            link.State = new LinkUsingBowLeftState(link, damaged, healthyDateTime);
        }

        public override void UseBomb()
        {
            link.State = new LinkUsingBombLeftState(link, damaged, healthyDateTime);
        }

        public override void UseBoomerang()
        {
            link.State = new LinkUsingBoomerangLeftState(link, damaged, healthyDateTime);
        }

        public override void UseSwordBeam()
        {
            link.State = new LinkUsingSwordBeamLeftState(link, damaged, healthyDateTime);
        }
    }
}
