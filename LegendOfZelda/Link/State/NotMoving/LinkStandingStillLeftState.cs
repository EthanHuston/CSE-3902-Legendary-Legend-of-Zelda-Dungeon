using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using System;

namespace LegendOfZelda.Link.State.NotMoving
{
    class LinkStandingStillLeftState : LinkActiveAbstractState
    {
        public LinkStandingStillLeftState(LinkPlayer link) : base(link)
        {
        }

        public LinkStandingStillLeftState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkLeftSprite();
        }

        public override void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
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
