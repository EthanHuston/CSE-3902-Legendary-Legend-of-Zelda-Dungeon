using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingDownState : LinkActiveAbstractState
    {
        private int distanceWalked;

        public LinkWalkingDownState(LinkPlayer link) : base(link)
        {
        }

        public LinkWalkingDownState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            distanceWalked = 0;
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
            link.Velocity = new Vector2(0, Constants.LinkWalkStepDistanceInterval);
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

        public override void MoveDown()
        {
            // Already moving down, do nothing
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position, damaged);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillDownState(link, damaged, healthyDateTime);
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
