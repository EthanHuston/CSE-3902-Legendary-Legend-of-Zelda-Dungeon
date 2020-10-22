using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Attacking
{
    class LinkAttackingLeftState : LinkLazyAbstractState
    {
        private const int spawnOffsetX = -16
        private const int spawnOffsetY = 0;
        public LinkAttackingLeftState(LinkPlayer link) : base(link)
        {
        }

        public LinkAttackingLeftState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingLeftLinkSprite();
            link.Velocity = (Vector2.Zero);
            link.SpawnItem(new SwordAttackingProjectile(link.Game.SpriteBatch, new Point(link.Position.X + spawnOffsetX, link.Position.Y + spawnOffsetY), Constants.Direction.Left, Constants.ItemOwner.Link));
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
            link.State = new LinkStandingStillLeftState(link, damaged, healthyDateTime);
        }
    }
}
