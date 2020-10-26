using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.Remoting.Messaging;

namespace LegendOfZelda.Enemies
{
    class Goriya : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private ISpawnableManager itemSpawner;
        private IProjectile boomer;
        private int velocity;
        private int updateCount = 0;
        private Constants.Direction direction = Constants.Direction.Down;
        private Constants.Direction knockbackOrigin = Constants.Direction.Down;
        private int changeDirection = 100;
        private bool boomerangInitialized = false;
        private bool boomerangActive = false;
        private int attackWaitTime = 150;
        private double health = 3;
        private bool inKnockback = false;
        private bool safeToDespawn = false;
        
        private Random rand = new Random();

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Goriya(SpriteBatch spriteBatch, Point spawnPosition, ISpawnableManager itemSpawner)
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            this.spriteBatch = spriteBatch;
            this.itemSpawner = itemSpawner;
            velocity = 1;
            Position = spawnPosition;
        }

        public void Update()
        {
            if (!inKnockback)
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
            }
            else {
                MoveKnockback(knockbackOrigin);
            }

            sprite.Update();
            safeToDespawn = !safeToDespawn && health <= 0;
        }

        public void Draw()
        {
            if (inKnockback)
            {
                sprite.Draw(spriteBatch, position, true);
                if (boomerangActive)
                    boomer.Draw();
            }
            else
            {
                sprite.Draw(spriteBatch, position);
                if (boomerangActive)
                    boomer.Draw();
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
            if(direction == this.direction)
            {
                inKnockback = true;
                switch (direction){
                    case Constants.Direction.Up: // Up
                        position.Y += velocity;
                        break;
                    case Constants.Direction.Down: // Down
                        position.Y -= velocity;
                        break;
                    case Constants.Direction.Left: // Left
                        position.X += velocity;
                        break;
                    case Constants.Direction.Right: // Right
                        position.X -= velocity;
                        break;
                    default:
                        break;
                }
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
                    this.direction = Constants.Direction.Up;
                    break;
                case Constants.Direction.Down: // Down
                    SetDownSprite();
                    this.direction = Constants.Direction.Down;
                    break;
                case Constants.Direction.Left: // Left
                    SetLeftSprite();
                    this.direction = Constants.Direction.Left;
                    break;
                case Constants.Direction.Right: // Right
                    SetRightSprite();
                    this.direction = Constants.Direction.Right;
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
                case Constants.Direction.Up: // Up
                    v = new Vector2(0, -5);
                    break;
                case Constants.Direction.Down: // Down
                    v = new Vector2(0, 5);
                    break;
                case Constants.Direction.Left: // Left
                    v = new Vector2(-5, 0);
                    break;
                case Constants.Direction.Right: // Right
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
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
        public bool SafeToDespawn()
        {
            return safeToDespawn;
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
            safeToDespawn = true;
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
    }
}
