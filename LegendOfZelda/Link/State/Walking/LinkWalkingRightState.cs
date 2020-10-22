using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingRightState : LinkActiveAbstractState
    {
        int distanceWalked;

        public LinkWalkingRightState(LinkPlayer link) : base(link)
        {
        }

        public LinkWalkingRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            distanceWalked = 0;
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingRightLinkSprite();
        }

        public override void Update()
        {
            Point position = link.Position;
            if (position.Y < Constants.MaxYPos)
            {
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
                link.Mover.Update();
                distanceWalked += (int)link.Mover.Velocity.Length();
                link.CurrentSprite.Update();
            }

            if (distanceWalked > Constants.LinkWalkDistanceInterval)
            {
                StopMoving();
            }
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position, damaged);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillRightState(link, damaged, healthyDateTime);
        }

        public override void UseSword()
        {
            link.State = new LinkAttackingRightState(link, damaged, healthyDateTime);
        }

        public override void UseBow()
        {
            link.State = new LinkUsingBowRightState(link, damaged, healthyDateTime);
        }

        public override void UseBomb()
        {
            link.State = new LinkUsingBombRightState(link, damaged, healthyDateTime);
        }

        public override void UseBoomerang()
        {
            link.State = new LinkUsingBoomerangRightState(link, damaged, healthyDateTime);
        }

        public override void UseSwordBeam()
        {
            link.State = new LinkUsingSwordBeamRightState(link, damaged, healthyDateTime);
        }
    }
}
