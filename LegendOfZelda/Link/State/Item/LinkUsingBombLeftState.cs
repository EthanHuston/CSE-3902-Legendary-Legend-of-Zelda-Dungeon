using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBombLeftState : LinkLazyAbstractState
    {
        public LinkUsingBombLeftState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBombLeftState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.SpawnItem(new BoomerangFlyingProjectile(link.Game.SpriteBatch, link.GetPosition(), Constants.ItemOwner.Link, link, new Vector2(-1 * Constants.BoomerangVelocity, 0)));
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
