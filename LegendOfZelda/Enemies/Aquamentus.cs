using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Aquamentus : INpc
    {
        private ISprite sprite;
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
        private IItemSpawner itemSpawner;

        public Aquamentus(Game1 game, Point spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
            spriteBatch = game.SpriteBatch;
            itemSpawner = game.SpawnedItems;
            position.X = spawnPosition.X;
            position.Y = spawnPosition.Y;
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

        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public Point GetPosition()
        {
            return position;
        }

        public Rectangle GetRectangle()
        {
            //Not implemented yet.
            return new Rectangle();
        }

        public void Move(Vector2 distance)
        {

        }
        public void SetPosition(Point position)
        {
            this.position = position;
        }

        public bool SafeToDespawn()
        {
            return health <= 0;
        }

        private void Attack()
        {
            Point spawnPosition = new Point(position.X, position.Y);
            itemSpawner.Spawn(new Fireball(spriteBatch, spawnPosition, new Vector2(xVelocity, -3), Constants.ItemOwner.Enemy));
            itemSpawner.Spawn(new Fireball(spriteBatch, spawnPosition, new Vector2(xVelocity, 0), Constants.ItemOwner.Enemy));
            itemSpawner.Spawn(new Fireball(spriteBatch, spawnPosition, new Vector2(xVelocity, 3), Constants.ItemOwner.Enemy));
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
            sprite = SpriteFactory.Instance.CreateAquamentusBreathingSprite();
        }

        private void SetWalkingSprite()
        {
            sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
        }
        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
            ballsInitialized = false;
            updateCount = 0;
        }
        public void TakeDamage(double damage)
        {
            health = health - damage;
        }
    }
}
