using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Goriya : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private IItemSpawner itemSpawner;
        private IProjectile boomer;
        private int velocity;
        private int updateCount = 0;
        private int direction = 1;
        private int changeDirection = 100;
        private bool boomerangInitialized = false;
        private bool boomerangActive = false;
        private int attackWaitTime = 150;
        private double health = 3;

        private Random rand = new Random();

        public Goriya(Game1 game, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            spriteBatch = game.SpriteBatch;
            velocity = 2;
            position = spawnPosition;
            itemSpawner = game.SpawnedItems;
        }

        public void Update()
        {
            updateCount++;
            if (updateCount >= 1000)
                updateCount = 0;

            if (!boomerangActive)
                Move();

            KeepInBounds();

            if (updateCount % attackWaitTime == 0)
                Attack();

            if (boomerangInitialized)
            {
                boomer.Update();
                boomerangActive = boomer.SafeToDespawn();
            }


            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
            if (boomerangActive)
                boomer.Draw();
        }

        private void Move()
        {
            if ((updateCount % changeDirection) == 0)
                ChangeDirection();

            switch (direction)
            {
                case 0: // Up
                    position.Y -= velocity;
                    break;
                case 1: // Down
                    position.Y += velocity;
                    break;
                case 2: // Left
                    position.X -= velocity;
                    break;
                case 3: // Right
                    position.X += velocity;
                    break;
                default:
                    break;
            }

        }

        private void ChangeDirection()
        {
            direction = rand.Next(0, 4);

            switch (direction)
            {
                case 0: // Up
                    SetUpSprite();
                    break;
                case 1: // Down
                    SetDownSprite();
                    break;
                case 2: // Left
                    SetLeftSprite();
                    break;
                case 3: // Right
                    SetRightSprite();
                    break;
                default:
                    break;
            }
        }

        private void ChangeDirection(int dir)
        {
            direction = dir;

            switch (direction)
            {
                case 0: // Up
                    SetUpSprite();
                    break;
                case 1: // Down
                    SetDownSprite();
                    break;
                case 2: // Left
                    SetLeftSprite();
                    break;
                case 3: // Right
                    SetRightSprite();
                    break;
                default:
                    break;
            }
        }

        private void Attack()
        {
            boomerangActive = true;
            boomerangInitialized = true;
            Vector2 v = new Vector2(0, 0);
            switch (direction)
            {
                case 0: // Up
                    v = new Vector2(0, -5);
                    break;
                case 1: // Down
                    v = new Vector2(0, 5);
                    break;
                case 2: // Left
                    v = new Vector2(-5, 0);
                    break;
                case 3: // Right
                    v = new Vector2(5, 0);
                    break;
                default:
                    break;
            }

            boomer = new BoomerangFlyingProjectile(spriteBatch, position, Constants.ItemOwner.Enemy, this, v);
            itemSpawner.Spawn(boomer);
        }

        private void KeepInBounds()
        {
            if (position.X < Constants.MinXPos)
            {
                position.X += velocity;
                ChangeDirection(3); // Right
            }

            else if (position.X > Constants.MaxXPos)
            {
                position.X -= velocity;
                ChangeDirection(2); // Left
            }

            if (position.Y < Constants.MinYPos)
            {
                position.Y += velocity;
                ChangeDirection(1); // Down
            }

            else if (position.Y > Constants.MaxYPos)
            {
                position.Y -= velocity;
                ChangeDirection(0); // Up
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

        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
            boomerangInitialized = false;
            boomerangActive = false;
            updateCount = 0;
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
        }
        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public void SetPosition(Point position)
        {
            this.position = position;
        }
        public bool SafeToDespawn()
        {
            return health <= 0;
        }
        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void TakeDamage(double damage)
        {
            health -= damage;
        }

        public void Despawn()
        {
            throw new NotImplementedException();
        }
    }
}
