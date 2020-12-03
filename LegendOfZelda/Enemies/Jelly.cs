using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Jelly : INpc
    {
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private int movementBuffer = 0;
        private int upDown = 0;
        private int leftRight = 0;
        private double health = .5 * Constants.HeartValue;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;
        private readonly Random rand = RoomConstants.RandomGenerator;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Jelly(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateJellySprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            SafeToDespawn = false;
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
            }
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
            else
            {
                movementBuffer++;
                if (movementBuffer == 16)
                {
                    movementBuffer = 0;
                    ChooseDirection();
                }
                else
                {
                    Move();
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
        private void ChooseDirection()
        {
            upDown = rand.Next(0, 2); // 0 for x, 1 for y
            leftRight = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
        private void Move()
        {
            //Simulate jelly moving
            if (upDown == 0 && leftRight == 0 && position.X + 16 < Constants.MaxXPos)
            {
                position.X++;
            }
            else if (upDown == 0 && leftRight == 1 && position.X - 16 > Constants.MinXPos)
            {
                position.X--;
            }
            else if (upDown == 1 && leftRight == 0 && position.Y + 16 < Constants.MaxYPos)
            {
                position.Y--;
            }
            else
            {
                position.Y++;
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
            // cannot be knocked back
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
