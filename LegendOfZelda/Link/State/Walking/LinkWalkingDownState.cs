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
        }

        public override void Update()
        {
            Point position = link.GetPosition();
            if (position.Y < Constants.MaxYPos)
            {
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
                position.Y = position.Y + Constants.LinkWalkStepDistanceInterval;
                distanceWalked += Constants.LinkWalkStepDistanceInterval;
                link.SetPosition(position);

                link.CurrentSprite.Update();
            }

            if (distanceWalked > Constants.LinkWalkDistanceInterval)
            {
                StopMoving();
            }
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public override void StopMoving()
        {
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }

        public override void UseSword()
        {
            link.SetState(new LinkAttackingDownState(link, damaged, healthyDateTime));
        }

        public override void UseBow()
        {
            link.SetState(new LinkUsingBowDownState(link, damaged, healthyDateTime));
        }

        public override void UseBomb()
        {
            link.SetState(new LinkUsingBombDownState(link, damaged, healthyDateTime));
        }

        public override void UseBoomerang()
        {
            link.SetState(new LinkUsingBoomerangDownState(link, damaged, healthyDateTime));
        }

        public override void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamDownState(link, damaged, healthyDateTime));
        }
    }
}
