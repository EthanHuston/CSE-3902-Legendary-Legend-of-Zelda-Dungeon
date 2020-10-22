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
        }

        public override void Update()
        {
            Point position = link.GetPosition();
            if (position.Y < Constants.MaxYPos)
            {
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
                link.Mover.Update();
                distanceWalked += (int)link.Mover.GetVelocity().Length();
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
            link.SetState(new LinkStandingStillLeftState(link, damaged, healthyDateTime));
        }

        public override void UseSword()
        {
            link.SetState(new LinkAttackingLeftState(link, damaged, healthyDateTime));
        }

        public override void UseBow()
        {
            link.SetState(new LinkUsingBowLeftState(link, damaged, healthyDateTime));
        }

        public override void UseBomb()
        {
            link.SetState(new LinkUsingBombLeftState(link, damaged, healthyDateTime));
        }

        public override void UseBoomerang()
        {
            link.SetState(new LinkUsingBoomerangLeftState(link, damaged, healthyDateTime));
        }

        public override void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamLeftState(link, damaged, healthyDateTime));
        }
    }
}
