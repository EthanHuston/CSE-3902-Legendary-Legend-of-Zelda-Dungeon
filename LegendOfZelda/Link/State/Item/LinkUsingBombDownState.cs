using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBombDownState : LinkLazyAbstractState
    {
        public LinkUsingBombDownState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBombDownState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.SpawnItem(new BombExplodingProjectile(link.Game.SpriteBatch, link.GetPosition(), Constants.ItemOwner.Link));
            link.SetVelocity(Vector2.Zero);
        }

        public override void Update()
        {
            link.Mover.Update();
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
