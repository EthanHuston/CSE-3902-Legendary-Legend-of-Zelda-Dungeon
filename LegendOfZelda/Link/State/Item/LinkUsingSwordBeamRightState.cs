using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingSwordBeamRightState : LinkLazyAbstractState
    {
        public LinkUsingSwordBeamRightState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingSwordBeamRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.SpawnItem(new SwordBeamFlyingProjectile(link.Game.SpriteBatch, link.GetPosition(), Constants.ItemOwner.Link, Constants.Direction.Right));
        }

        public override void Update()
        {
            StopMoving(); // because after we spawn the boomerang return to non-moving state
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public override void StopMoving()
        {
            link.SetState(new LinkStandingStillRightState(link, damaged, healthyDateTime));
        }
    }
}
