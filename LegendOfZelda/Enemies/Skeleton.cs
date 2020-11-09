using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Skeleton : INpc
    {
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private int movementBuffer = 0;
        private double health = 2 * Constants.HeartValue;
        private Constants.Direction direction = Constants.Direction.Down;
        private Constants.Direction knockbackOrigin = Constants.Direction.Down;
        private bool safeToDespawn = false;
        private bool inKnockback = false;
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;
        private readonly Random rand = RoomConstants.RandomGenerator;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Skeleton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateSkeletonSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawning = true;
        }
        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) <= 0; // only compare if we're damaged
            safeToDespawn = safeToDespawn || health <= 0;
            if (safeToDespawn)
            {
                SoundFactory.Instance.CreateEnemyDieSound().Play();
            }
            if (spawning)
            {
                if (!spawnSprite.AnimationDone())
                {
                    spawnSprite.Update();
                }
                else
                {
                    spawning = false;
                }
            }
            else
            {
                if (!inKnockback)
                {
                    movementBuffer++;
                    if (movementBuffer == 20)
                    {
                        movementBuffer = 0;
                        ChooseDirection();
                    }
                    else
                    {
                        Move();
                        CheckBounds();
                    }
                }
                else
                {
                    MoveKnockback(knockbackOrigin);
                }
                sprite.Update();
            }
        }

        public void Draw()
        {
            if (spawning)
            {
                spawnSprite.Draw(spriteBatch, position);
            }
            else
            {
                sprite.Draw(spriteBatch, position, damaged);
            }
        }
        private void ChooseDirection()
        {
            int newDirection = rand.Next(0, 4);
            switch (newDirection)
            {
                case 0:
                    direction = Constants.Direction.Down;
                    break;
                case 1:
                    direction = Constants.Direction.Up;
                    break;
                case 2:
                    direction = Constants.Direction.Left;
                    break;
                case 3:
                    direction = Constants.Direction.Right;
                    break;
                default:
                    break;
            }
        }
        private void Move()
        {
            switch (direction)
            {
                case Constants.Direction.Up: // Up
                    position.Y--;
                    break;
                case Constants.Direction.Down: // Down
                    position.Y++;
                    break;
                case Constants.Direction.Left: // Left
                    position.X--;
                    break;
                case Constants.Direction.Right: // Right
                    position.X++;
                    break;
                default:
                    break;
            }
        }
        private void MoveKnockback(Constants.Direction knockDirection)
        {
            inKnockback = true;
            switch (knockDirection)
            {
                case Constants.Direction.Up: // Up
                    position.Y++;
                    break;
                case Constants.Direction.Down: // Down
                    position.Y--;
                    break;
                case Constants.Direction.Left: // Left
                    position.X++;
                    break;
                case Constants.Direction.Right: // Right
                    position.X--;
                    break;
                default:
                    break;
            }
        }
        private void CheckBounds()
        {
            if (position.X < Constants.MinXPos)
            {
                position.X++;
                ChangeDirection(Constants.Direction.Right); // Right
            }

            else if (position.X > Constants.MaxXPos)
            {
                position.X--;
                ChangeDirection(Constants.Direction.Left); // Left
            }

            if (position.Y < Constants.MinYPos)
            {
                position.Y++;
                ChangeDirection(Constants.Direction.Down); // Down
            }

            else if (position.Y > Constants.MaxYPos)
            {
                position.Y--;
                ChangeDirection(Constants.Direction.Up); // Up
            }
        }
        private void ChangeDirection(Constants.Direction dir)
        {
            direction = dir;

            switch (direction)
            {
                case Constants.Direction.Up: // Up
                    direction = Constants.Direction.Up;
                    break;
                case Constants.Direction.Down: // Down
                    direction = Constants.Direction.Down;
                    break;
                case Constants.Direction.Left: // Left
                    direction = Constants.Direction.Left;
                    break;
                case Constants.Direction.Right: // Right
                    direction = Constants.Direction.Right;
                    break;
                default:
                    break;
            }
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
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
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
        public void ResetSpawnCloud()
        {
            spawning = true;
        }
    }
}
