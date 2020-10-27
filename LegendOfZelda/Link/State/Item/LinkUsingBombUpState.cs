using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    internal class LinkUsingBombUpState : LinkLazyAbstractState
    {
        private const int spawnOffsetX = 0 * Constants.SpriteScaler;
        private const int spawnOffsetY = -16 * Constants.SpriteScaler;
        public LinkUsingBombUpState(LinkPlayer link) : base(link)
        {
        }

        public LinkUsingBombUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.SpawnItem(new BombExplodingProjectile(link.Game.SpriteBatch, new Point(link.Position.X + spawnOffsetX, link.Position.Y + spawnOffsetY), Constants.ItemOwner.Link));
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
            link.State = new LinkStandingStillUpState(link, damaged, healthyDateTime);
        }
    }
}
