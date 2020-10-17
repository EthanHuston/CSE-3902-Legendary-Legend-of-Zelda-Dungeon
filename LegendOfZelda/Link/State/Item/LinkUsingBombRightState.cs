using LegendOfZelda.Link.Item;
using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBombRightState : LinkLazyAbstractState
    {
        public LinkUsingBombRightState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBombRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            this.link.SpawnItem(new BombExplodingProjectile(link));
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
