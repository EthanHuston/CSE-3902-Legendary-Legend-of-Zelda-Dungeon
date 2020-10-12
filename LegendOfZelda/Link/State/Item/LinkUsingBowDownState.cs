using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBowDownState : LinkLazyAbstractState
    {
        public LinkUsingBowDownState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBowDownState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            this.link.SpawnItem(new ArrowFlyingItem(link, Constants.Direction.Down));
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
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }
    }
}
