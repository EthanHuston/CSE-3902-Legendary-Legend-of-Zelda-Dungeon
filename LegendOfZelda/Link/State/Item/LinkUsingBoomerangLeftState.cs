using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBoomerangLeftState : LinkLazyAbstractState
    {
        public LinkUsingBoomerangLeftState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBoomerangLeftState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.SpawnItem(new BoomerangFlyingProjectile(link, Constants.Direction.Left));
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
            link.SetState(new LinkStandingStillLeftState(link, damaged, healthyDateTime));
        }
    }
}
