using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Bat : INpc
    {
        private const int directionChangeDelay = 75;
        private const int velocityScalar = (int)(0.75 * Constants.GameScaler);
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private double health = 0.5 * Constants.HeartValue;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
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
            SafeToDespawn = false;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawning = true;
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

                movementBuffer++;
                //Move based on current chosen direction for some time.
                CheckBounds();

                position.X += xDir == 0 ? -1 * velocityScalar : velocityScalar;
                position.Y += yDir == 0 ? -1 * velocityScalar : velocityScalar;

                if (movementBuffer > directionChangeDelay)
                {
                    movementBuffer = 0;
                    ChooseDirection();
                }
                sprite.Update();
                SafeToDespawn = SafeToDespawn || health <= 0;
            }
            if (SafeToDespawn)
            {
                SoundFactory.Instance.CreateEnemyDieSound().Play();
            }
        }

        public void ClockUpdate()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            SafeToDespawn = SafeToDespawn || health <= 0;
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
            if (SafeToDespawn)
            {
                SoundFactory.Instance.CreateEnemyDieSound().Play();
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
        
        public Rectangle GetRectangle()
        {

            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public void Despawn()
        {
            SafeToDespawn = true;
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
