using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Goriya : INpc
    {
        private IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private readonly ISpawnableManager itemSpawner;
        private IProjectile boomer;
        private readonly int velocity;
        private int updateCount = 0;
        private const int boomerangVelocity = 3;
        private Constants.Direction direction = Constants.Direction.Down;
        private Constants.Direction knockbackOrigin = Constants.Direction.Down;
        private readonly int changeDirection = 75;
        private bool boomerangActive = false;
        private int boomerangIndex = 9999;
        private readonly int attackWaitTime = 200;
        private double health = 3 * Constants.HeartValue;
        private bool inKnockback = false;
        private int knockbackDist = 0;
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;

        private readonly Random rand = RoomConstants.RandomGenerator;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        public Goriya(SpriteBatch spriteBatch, Point spawnPosition, ISpawnableManager itemSpawner)
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            this.itemSpawner = itemSpawner;
            velocity = 1;
            Position = spawnPosition;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawning = true;
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            SafeToDespawn = SafeToDespawn || health <= 0;
            if (SafeToDespawn)
            {
                SoundFactory.Instance.CreateEnemyDieSound().Play();
                if (boomerangActive)
                    itemSpawner.Spawn(new BoomerangItem(spriteBatch, boomer.Position));
                if (boomer != null)
                    boomer.Despawn();
            }
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
            else
            {
                if (!inKnockback)
                {
                    updateCount++;
                    if (updateCount >= 1000)
                        updateCount = 0;

                    if (!boomerangActive)
                        Move();

                    KeepInBounds();

                    if (updateCount % attackWaitTime == 0 && !boomerangActive)
                        Attack();

                    boomerangActive = boomer != null && !boomer.SafeToDespawn;
                }
                else
                {
                    knockbackDist++;
                    if (knockbackDist > 40)
                    {
                        knockbackDist = 0;
                        SetKnockBack(false, Constants.Direction.None);
                    }
                    else
                    {
                        MoveKnockback(knockbackOrigin);
                    }
                }

                sprite.Update();
            }
        }

        public void ClockUpdate()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            SafeToDespawn = SafeToDespawn || health <= 0;
            if (SafeToDespawn)
            {
                SoundFactory.Instance.CreateEnemyDieSound().Play();
                if (boomerangActive)
                    itemSpawner.Spawn(new BoomerangItem(spriteBatch, boomer.Position));
                if (boomer != null)
                    boomer.Despawn();
            }
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
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

        private void Move()
        {
            if ((updateCount % changeDirection) == 0)
                ChangeDirection();

            switch (direction)
            {
                case Constants.Direction.Up: // Up
                    position.Y -= velocity;
                    break;
                case Constants.Direction.Down: // Down
                    position.Y += velocity;
                    break;
                case Constants.Direction.Left: // Left
                    position.X -= velocity;
                    break;
                case Constants.Direction.Right: // Right
                    position.X += velocity;
                    break;
                default:
                    break;
            }

        }
        private void MoveKnockback(Constants.Direction direction)
        {
            inKnockback = true;
            switch (direction)
            {
                case Constants.Direction.Up: // Up
                    position.Y -= velocity * 4;
                    break;
                case Constants.Direction.Down: // Down
                    position.Y += velocity * 4;
                    break;
                case Constants.Direction.Left: // Left
                    position.X -= velocity * 4;
                    break;
                case Constants.Direction.Right: // Right
                    position.X += velocity * 4;
                    break;
                default:
                    break;
            }

        }

        private void ChangeDirection()
        {
            int newDirection = rand.Next(0, 4);

            switch (newDirection)
            {
                case 0: // Up
                    SetUpSprite();
                    direction = Constants.Direction.Up;
                    break;
                case 1: // Down
                    SetDownSprite();
                    direction = Constants.Direction.Down;
                    break;
                case 2: // Left
                    SetLeftSprite();
                    direction = Constants.Direction.Left;
                    break;
                case 3: // Right
                    SetRightSprite();
                    direction = Constants.Direction.Right;
                    break;
                default:
                    break;
            }
        }

        private void ChangeDirection(Constants.Direction dir)
        {
            direction = dir;

            switch (direction)
            {
                case Constants.Direction.Up: // Up
                    SetUpSprite();
                    direction = Constants.Direction.Up;
                    break;
                case Constants.Direction.Down: // Down
                    SetDownSprite();
                    direction = Constants.Direction.Down;
                    break;
                case Constants.Direction.Left: // Left
                    SetLeftSprite();
                    direction = Constants.Direction.Left;
                    break;
                case Constants.Direction.Right: // Right
                    SetRightSprite();
                    direction = Constants.Direction.Right;
                    break;
                default:
                    break;
            }
        }

        private void Attack()
        {
            boomerangActive = true;
            Vector2 v = new Vector2(0, 0);
            switch (direction)
            {
                case Constants.Direction.Up: // Up
                    v = new Vector2(0, -1 * boomerangVelocity);
                    break;
                case Constants.Direction.Down: // Down
                    v = new Vector2(0, boomerangVelocity);
                    break;
                case Constants.Direction.Left: // Left
                    v = new Vector2(-1 * boomerangVelocity, 0);
                    break;
                case Constants.Direction.Right: // Right
                    v = new Vector2(boomerangVelocity, 0);
                    break;
                default:
                    break;
            }

            boomer = new BoomerangFlyingProjectile(spriteBatch, Position, Constants.ProjectileOwner.Enemy, this, v);
            boomerangIndex = itemSpawner.ProjectileList.Count;
            itemSpawner.Spawn(boomer);
            SoundFactory.Instance.CreateArrowBoomerangSound().Play();
        }

        private void KeepInBounds()
        {
            if (position.X < Constants.MinXPos)
            {
                position.X += velocity;
                ChangeDirection(Constants.Direction.Right); // Right
            }

            else if (position.X > Constants.MaxXPos)
            {
                position.X -= velocity;
                ChangeDirection(Constants.Direction.Left); // Left
            }

            if (position.Y < Constants.MinYPos)
            {
                position.Y += velocity;
                ChangeDirection(Constants.Direction.Down); // Down
            }

            else if (position.Y > Constants.MaxYPos)
            {
                position.Y -= velocity;
                ChangeDirection(Constants.Direction.Up); // Up
            }

        }

        private void SetUpSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
        }

        private void SetDownSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
        }

        private void SetLeftSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
        }

        private void SetRightSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
        }
        public void Move(Vector2 distance)
        {
            ChangeDirection();
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
        
        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public void TakeDamage(double damage)
        {
            if (!damaged)
            {
                damaged = true;
                health -= damage;
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.EnemyDamageEffectTimeMs);
                SoundFactory.Instance.CreateEnemyHitSound().Play();
            }
        }

        public void Despawn()
        {
            SafeToDespawn = true;
        }
        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            inKnockback = changeKnockback;
            if (inKnockback)
            {
                knockbackOrigin = knockDirection;
            }
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
