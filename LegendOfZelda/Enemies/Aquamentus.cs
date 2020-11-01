using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Aquamentus : INpc
    {
        private IDamageableSprite sprite;
        private readonly SpriteBatch spriteBatch;
        private readonly int vx = 1;
        private int updateCount = 0;
        private readonly int switchDirection = 90;
        private readonly int attackTime = 90;
        private int attackUpdate = 0;
        private bool attacked = false;
        private double health = 6;
        private const int xVelocity = -2;
        private readonly ISpawnableManager itemSpawner;
        private bool safeToDespawn;
        private DateTime healthyDateTime;
        private bool damaged;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Aquamentus(SpriteBatch spriteBatch, Point spawnPosition, ISpawnableManager itemSpawner)
        {
            sprite = EnemySpriteFactory.Instance.CreateAquamentusWalkingSprite();
            this.spriteBatch = spriteBatch;
            this.itemSpawner = itemSpawner;
            Position = spawnPosition;
            safeToDespawn = false;
            healthyDateTime = DateTime.Now;
            damaged = false;
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged

            updateCount++;
            if (updateCount % 3 == 0)
            {
                if (!attacked)
                    UpdateDirection();
            }

            if (updateCount % attackTime == 0)
                Attack();

            UpdateSprite();

            sprite.Update();

            CheckSafeToDespawn();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position, damaged);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void CheckSafeToDespawn()
        {
            safeToDespawn = !safeToDespawn && health <= 0;
        }

        private void Attack()
        {
            Point spawnPosition = new Point(position.X, position.Y);
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, new Vector2(xVelocity, -1), Constants.ProjectileOwner.Enemy));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, new Vector2(xVelocity, 0), Constants.ProjectileOwner.Enemy));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, new Vector2(xVelocity, 1), Constants.ProjectileOwner.Enemy));
            attacked = true;
            attackUpdate = updateCount;
        }

        private void UpdateDirection()
        {
            if (updateCount < switchDirection)
                position.X -= vx;
            else if (updateCount < 2 * switchDirection)
                position.X += vx;
            else
                updateCount = 1;
        }

        private void UpdateSprite()
        {
            if (updateCount - attackUpdate <= 16 && updateCount - attackUpdate >= 0)
            {
                SetBreathingSprite();
            }
            else if (attacked)
            {
                SetWalkingSprite();
                attacked = false;
            }
        }

        private void SetBreathingSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateAquamentusBreathingSprite();
        }

        private void SetWalkingSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateAquamentusWalkingSprite();
        }

        public void TakeDamage(double damage)
        {
            if (!damaged)
            {
                damaged = true;
                health -= damage;
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.EnemyDamageEffectTimeMs);
            }
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            // no knockback
        }

        public double GetDamageAmount()
        {
            return Constants.LinkEnemyCollisionDamage;
        }
    }
}
