using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Aquamentus : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private int vx = 1;
        private int updateCount = 0;
        private int switchDirection = 100;
        private int attackTime = 110;
        private int attackUpdate = 0;
        private bool attacked = false;
        private bool ballsInitialized = false;
        private double health = 6;
        private const int xVelocity = -5;
        private ISpawnableManager itemSpawner;
        private bool safeToDespawn;

        public Aquamentus(Game1 game, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateAquamentusWalkingSprite();
            spriteBatch = game.SpriteBatch;
            itemSpawner = game.SpawnedItems;
            position = spawnPosition;
            safeToDespawn = false;
        }

        public void Update()
        {
            //updateCount++;

            if (!attacked)
                UpdateDirection();

            if (updateCount % attackTime == 0)
                Attack();

            UpdateSprite();

            sprite.Update();

            updateCount++;

            CheckSafeToDespawn();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public void SetPosition(Point position)
        {
            this.position = new Point(position.X, position.Y);
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
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, new Vector2(xVelocity, -3), Constants.ItemOwner.Enemy));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, new Vector2(xVelocity, 0), Constants.ItemOwner.Enemy));
            itemSpawner.Spawn(new FireballProjectile(spriteBatch, spawnPosition, new Vector2(xVelocity, 3), Constants.ItemOwner.Enemy));
            ballsInitialized = true;
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
                updateCount = 0;
        }

        private void UpdateSprite()
        {
            if (updateCount - attackUpdate <= 4)
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
        public void ResetPosition()
        {
            updateCount = 0;
        }

        public void TakeDamage(double damage)
        {
            health -= damage;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}
