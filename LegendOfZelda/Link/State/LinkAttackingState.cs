using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    class LinkAttackingState : LinkGenericAbstractState
    {
        public LinkAttackingState(LinkPlayer link) : base(link)
        {
            // handled by parent constructor
        }

        public LinkAttackingState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
            // handled by parent constructor
        }

        protected override void InitClass()
        {
            switch(link.FacingDirection)
            {
                case Constants.Direction.Up:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingUpLinkSprite();
                    break;
                case Constants.Direction.Down:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingDownLinkSprite();
                    break;
                case Constants.Direction.Left:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingLeftLinkSprite();
                    break;
                case Constants.Direction.Right:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingRightLinkSprite();
                    break;
            }
            link.Velocity = Vector2.Zero;
            link.SpawnItem(new SwordAttackingProjectile(link.Game.SpriteBatch, new Point(link.Position.X, link.Position.Y), link.FacingDirection, Constants.ProjectileOwner.Link));
        }

        protected override void UpdateState()
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
        }
    }
}
