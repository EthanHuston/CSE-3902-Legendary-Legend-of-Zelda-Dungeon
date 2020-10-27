using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Attacking
{
    internal class LinkAttackingUpState : LinkLazyAbstractState
    {
        private const int spawnOffsetX = 0;
        private const int spawnOffsetY = -16;

        public LinkAttackingUpState(LinkPlayer link) : base(link)
        {
        }

        public LinkAttackingUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingUpLinkSprite();
            link.Velocity = (Vector2.Zero);
            link.SpawnItem(new SwordAttackingProjectile(link.Game.SpriteBatch, new Point(link.Position.X, link.Position.Y), Constants.Direction.Up, Constants.ItemOwner.Link));
        }

        public override void Update()
        {
            if (link.CurrentSprite.FinishedAnimation())
            {
                link.BlockStateChange = false;
                StopMoving();
            }
            else
            {
                link.BlockStateChange = true;
            }
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            link.Mover.Update();
        }

        public override void Draw()
        {
            int posX = link.Position.X;
            int posY = link.Position.Y;
            link.CurrentSprite.Draw(link.Game.SpriteBatch, new Point(posX, posY), damaged);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillUpState(link, damaged, healthyDateTime);
        }
    }
}
