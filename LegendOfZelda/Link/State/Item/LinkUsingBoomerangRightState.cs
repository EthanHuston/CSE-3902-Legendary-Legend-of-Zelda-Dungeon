using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBoomerangRightState : LinkLazyAbstractState
    {
        public LinkUsingBoomerangRightState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBoomerangRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.SpawnItem(new BoomerangFlyingProjectile(link.Game.SpriteBatch, link.Position, Constants.ItemOwner.Link, link, new Vector2(Constants.BoomerangVelocity, 0)));
            link.Velocity = (Vector2.Zero);
        }

        public override void Update()
        {
            link.Mover.Update();
            StopMoving(); // because after we spawn the boomerang return to non-moving state
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position, damaged);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillRightState(link, damaged, healthyDateTime);
        }
    }
}
