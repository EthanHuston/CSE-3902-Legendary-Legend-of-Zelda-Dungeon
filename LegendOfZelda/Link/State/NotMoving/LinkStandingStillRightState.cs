﻿using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
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
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkRightSprite();
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
            link.SetState(new LinkAttackingRightState(link, damaged, healthyDateTime));
        }

        public override void UseBomb()
        {
            link.SetState(new LinkUsingBombRightState(link, damaged, healthyDateTime));
        }

        public override void UseBoomerang()
        {
            link.SetState(new LinkUsingBoomerangRightState(link, damaged, healthyDateTime));
        }

        public override void UseBow()
        {
            link.SetState(new LinkUsingBowRightState(link, damaged, healthyDateTime));
        }

        public override void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamRightState(link, damaged, healthyDateTime));
        }
    }
}
