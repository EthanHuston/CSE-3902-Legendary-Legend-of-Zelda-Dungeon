using LegendOfZelda.Link;
using LegendOfZelda.Projectile.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class BombExplodingProjectile : GenericProjectile
    {
        private readonly SoundEffectInstance bomb_blow;
        public BombExplodingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            projectileType = LinkConstants.ProjectileType.Bomb;
            sprite = ProjectileSpriteFactory.Instance.CreateBombExplodingSprite();
            Position = new Point(Position.X - Constants.BombSpawnOffsetX, Position.Y - Constants.BombSpawnOffsetY);
            bomb_blow = SoundFactory.Instance.CreateBombBlowSound();
        }

        public override void Update()
        {
            Mover.Update();
            sprite.Update();
            CheckItemIsExpired();
            if (((BombExplodingSprite)sprite).IsExploding())
            {
                bomb_blow.Play();
            }
        }

        private void CheckItemIsExpired()
        {
            SafeToDespawn = sprite.FinishedAnimation();
        }

        public bool IsExploded()
        {
            return ((BombExplodingSprite)sprite).IsExploding();
        }

        public override double DamageAmount()
        {
            return Constants.BombDamage;
        }
    }
}
