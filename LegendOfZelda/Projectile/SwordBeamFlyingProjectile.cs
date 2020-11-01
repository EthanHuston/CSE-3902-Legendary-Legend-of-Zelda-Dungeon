using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class SwordBeamFlyingProjectile : GenericProjectile
    {
        private bool stopMovingAndExplode;
        private bool updatedSprite;
        private const int moveDistanceVelocity = 3;

        public SwordBeamFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner, Constants.Direction direction) : base(spriteBatch, spawnPosition, owner)
        {
            projectileType = LinkConstants.ProjectileType.SwordBeam;
            updatedSprite = false; // true we update sword beam to be exploding -- just so we don't update it more than once
            stopMovingAndExplode = false; // true the sword beam hits an enemy or gets to edge of screen
            switch (direction)
            {
                case Constants.Direction.Down:
                    Velocity = new Vector2(0, moveDistanceVelocity);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamDownSprite();
                    break;
                case Constants.Direction.Up:
                    Velocity = new Vector2(0, -1 * moveDistanceVelocity);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamUpSprite();
                    break;
                case Constants.Direction.Right:
                    Velocity = new Vector2(moveDistanceVelocity, 0);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamRightSprite();
                    break;
                case Constants.Direction.Left:
                    Velocity = new Vector2(-1 * moveDistanceVelocity, 0);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamLeftSprite();
                    break;
            }
        }

        public override void Update()
        {
            sprite.Update();
            if (!stopMovingAndExplode)
            {
                Mover.Update();
            }
            else if (stopMovingAndExplode && !updatedSprite) // initial setup of sword beam explosion
            {
                sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamExplodingSprite();
                updatedSprite = true;
            }
            CheckItemIsExpired();
        }

        protected void CheckItemIsExpired()
        {
            itemIsExpired = sprite.FinishedAnimation();
        }

        public void ExplodeSword()
        {
            stopMovingAndExplode = true;
        }

        public override double DamageAmount()
        {
            return Constants.SwordBeamDamage;
        }
    }
}
