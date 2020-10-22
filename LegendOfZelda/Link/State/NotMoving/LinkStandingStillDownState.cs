using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.NotMoving
{
    class LinkStandingStillDownState : LinkActiveAbstractState
    {
        public LinkStandingStillDownState(LinkPlayer link) : base(link)
        {
        }

        public LinkStandingStillDownState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
            link.SetVelocity(Vector2.Zero);
        }

        public override void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            link.Mover.Update();
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public override void StopMoving()
        {
            // Already not moving, do nothing
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
