using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.NotMoving
{
    class LinkStandingStillRightState : LinkActiveAbstractState
    {
        public LinkStandingStillRightState(LinkPlayer link) : base(link)
        {
        }

        public LinkStandingStillRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkRightSprite();
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
            link.State = new LinkAttackingRightState(link, damaged, healthyDateTime);
        }

        public override void UseBomb()
        {
            link.State = new LinkUsingBombRightState(link, damaged, healthyDateTime);
        }

        public override void UseBoomerang()
        {
            link.State = new LinkUsingBoomerangRightState(link, damaged, healthyDateTime);
        }

        public override void UseBow()
        {
            link.State = new LinkUsingBowRightState(link, damaged, healthyDateTime);
        }

        public override void UseSwordBeam()
        {
            link.State = new LinkUsingSwordBeamRightState(link, damaged, healthyDateTime);
        }
    }
}
