using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal class LinkAttackingState : LinkGenericAbstractState
    {
        public LinkAttackingState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
            // handled by parent constructor
        }

        protected override void InitClass()
        {
            Point spawnOffset = Point.Zero;
            switch (link.FacingDirection)
            {
                case Constants.Direction.Up:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingUpLinkSprite();
                    spawnOffset = LinkConstants.UsingSwordUpSpawnOffset;
                    break;
                case Constants.Direction.Down:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingDownLinkSprite();
                    spawnOffset = LinkConstants.UsingSwordDownSpawnOffset;
                    break;
                case Constants.Direction.Left:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingLeftLinkSprite();
                    spawnOffset = LinkConstants.UsingSwordLeftSpawnOffset;
                    break;
                case Constants.Direction.Right:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingRightLinkSprite();
                    spawnOffset = LinkConstants.UsingSwordRightSpawnOffset;
                    break;
            }
            link.Velocity = Vector2.Zero;
            link.SpawnItem(new SwordAttackingProjectile(link.Game.SpriteBatch, new Point(link.Position.X, link.Position.Y) + spawnOffset, link.FacingDirection, Constants.ProjectileOwner.Link));

            if (link.CurrentHealth >= link.MaxHealth && link.CanSpawnProjectile(LinkConstants.ProjectileType.SwordBeam))
            {
                link.SpawnItem(new SwordBeamFlyingProjectile(link.Game.SpriteBatch, link.Position + LinkConstants.ShootingSwordBeamSpawnOffset, Constants.ProjectileOwner.Link, link.FacingDirection));
                SoundFactory.Instance.CreateSwordCombinedSound().Play();
            }
        }

        protected override void UpdateState()
        {
            if (link.CurrentSprite.FinishedAnimation())
            {
                link.BlockStateChange = false;
                StopMovingLocal();
            }
            else
            {
                link.BlockStateChange = true;
            }
        }

        public override void Move(Constants.Direction direction)
        {
            // cannot move during this state
        }

        public override void UseSword()
        {
            // cannot use sword
        }

        private void StopMovingLocal()
        {
            link.State = new LinkStandingStillState(link, damaged, healthyDateTime);
        }

        public override void StopMoving()
        {
        }
    }
}
