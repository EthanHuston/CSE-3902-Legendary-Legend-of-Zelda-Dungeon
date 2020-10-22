using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBowUpState : LinkLazyAbstractState
    {
        public LinkUsingBowUpState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBowUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            this.link.SpawnItem(new ArrowFlyingProjectile(link.Game.SpriteBatch, link.GetPosition(), Constants.Direction.Up, Constants.ItemOwner.Link));
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
            link.SetState(new LinkStandingStillUpState(link, damaged, healthyDateTime));
        }
    }
}
