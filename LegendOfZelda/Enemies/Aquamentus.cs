using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Aquamentus : INpc
    {
        private IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private readonly int vx = 1;
        private int updateCount = 0;
        private readonly int switchDirection = 90;
        private readonly int attackTime = 90;
        private int attackUpdate = 0;
        private bool attacked = false;
        private double health = 8 * Constants.HeartValue;
        private const int xVelocity = -6;
        private readonly ISpawnableManager itemSpawner;
        private bool safeToDespawn;
        public bool SafeToDespawn { get => safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;
        private readonly IPlayer link;
        private double attackAngle;
        private readonly double angleOffset = Math.PI / 6;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Aquamentus(SpriteBatch spriteBatch, Point spawnPosition, ISpawnableManager itemSpawner)
        {
            sprite = EnemySpriteFactory.Instance.CreateAquamentusWalkingSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            this.itemSpawner = itemSpawner;
            Position = spawnPosition;
            SafeToDespawn = false;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawning = true;
            link = itemSpawner.GetPlayer(0);
            attackAngle = Math.PI;
        }

        public void Update()
        {
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
            else
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
            if (SafeToDespawn)
            {
                SoundFactory.Instance.CreateBossScreamSound().Play();
            }
        }

        public void ClockUpdate()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            CheckSafeToDespawn();
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
            if (SafeToDespawn)
            {
                SoundFactory.Instance.CreateBossScreamSound().Play();
            }
        }

        public void Draw()
        {
            if (spawning)
            {
                spawnSprite.Draw(spriteBatch, position, Constants.DrawLayer.EnemySpawnSprite);
            }
            else
            {
                sprite.Draw(spriteBatch, position, damaged, Constants.DrawLayer.Enemy);
            }
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
        
        private void CheckSafeToDespawn()
        {
            SafeToDespawn = SafeToDespawn || health <= 0;
        }

        private void UpdateAttackAngle()
        {
            double x = position.X - link.Position.X;
            double y = position.Y - link.Position.Y;
            if (x < 0)
                attackAngle = Math.Atan(y / x) + Math.PI;
            else
                attackAngle = Math.Atan(y / x);
        }

        private void Attack()
        {
            UpdateAttackAngle();
            Point spawnPosition = new Point(position.X, position.Y);
            Vector2 fireballVelocity1 = new Vector2(xVelocity * (float)Math.Cos(attackAngle), xVelocity * (float)Math.Sin(attackAngle));
            Vector2 fireballVelocity2 = new Vector2(xVelocity * (float)Math.Cos(attackAngle + angleOffset), xVelocity * (float)Math.Sin(attackAngle + angleOffset));
            Vector2 fireballVelocity3 = new Vector2(xVelocity * (float)Math.Cos(attackAngle - angleOffset), xVelocity * (float)Math.Sin(attackAngle - angleOffset));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, fireballVelocity1, Constants.ProjectileOwner.Enemy));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, fireballVelocity2, Constants.ProjectileOwner.Enemy));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, fireballVelocity3, Constants.ProjectileOwner.Enemy));
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
                SoundFactory.Instance.CreateBossHitSound().Play();
            }
        }
        
        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            // no knockback
        }

        public double GetDamageAmount()
        {
            return Constants.LinkEnemyCollisionDamage;
        }
        public void ResetSpawnCloud()
        {
            spawning = true;
        }
    }
}
