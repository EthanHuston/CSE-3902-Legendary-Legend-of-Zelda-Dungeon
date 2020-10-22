using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.NotMoving
{
    class LinkStandingStillUpState : LinkActiveAbstractState
    {

        public LinkStandingStillUpState(LinkPlayer link) : base(link)
        {
        }

        public LinkStandingStillUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkUpSprite();
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
            link.SetState(new LinkAttackingUpState(link, damaged, healthyDateTime));
        }

        public override void UseBow()
        {
            link.SetState(new LinkUsingBowUpState(link, damaged, healthyDateTime));
        }

        public override void UseBomb()
        {
            link.SetState(new LinkUsingBombUpState(link, damaged, healthyDateTime));
        }

        public override void UseBoomerang()
        {
            link.SetState(new LinkUsingBoomerangUpState(link, damaged, healthyDateTime));
        }

        public override void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamUpState(link, damaged, healthyDateTime));
        }
    }
}
