using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Bat : INpc
    {
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private const int directionChangeDelay = 30;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private double health = 0.5;
        private bool safeToDespawn;
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;
        private readonly Random rand = RoomConstants.RandomGenerator;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Bat(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateBatSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            position = spawnPosition;
            safeToDespawn = false;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawning = true;
        }

        public void Update()
        {
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
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged

                movementBuffer++;
                //Move based on current chosen direction for some time.
                CheckBounds();
                if (xDir == 0 && yDir == 0)
                {
                    position.X--;
                    position.Y--;
                }
                else if (xDir == 0 && yDir == 1)
                {
                    position.X--;
                    position.Y++;
                }
                else if (xDir == 1 && yDir == 0)
                {
                    position.X++;
                    position.Y--;
                }
                else
                {
                    position.Y++;
                    position.X++;
                }

                if (movementBuffer > directionChangeDelay)
                {
                    movementBuffer = 0;
                    ChooseDirection();
                }
                sprite.Update();
                safeToDespawn = !safeToDespawn && health <= 0;
            }
            if (safeToDespawn)
            {
                SoundFactory.Instance.CreateEnemyDieSound().Play();
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

        public void ChooseDirection()
        {
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
        private void CheckBounds()
        {
            // TODO: use constant
            if (position.X + 16 > Constants.MaxXPos)
            {
                ChooseDirection();
            }
            else if (position.X - 16 < Constants.MinXPos)
            {
                ChooseDirection();
            }
            if (position.Y + 16 > Constants.MaxYPos)
            {
                ChooseDirection();
            }
            else if (position.Y - 16 < Constants.MinYPos)
            {
                ChooseDirection();
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
            // bat has no knockback
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
