using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Hand : INpc
    {
        private const int draggingCooldownMs = 5000;
        private const int directionChangeDelay = 30;
        private const int velocityScalar = 3;
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private double health = 4 * Constants.HeartValue;
        private readonly Random rand = RoomConstants.RandomGenerator;
        private bool safeToDespawn;
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;
        private IPlayer link;
        private DateTime draggingTime;

        public bool DraggingLink { get; private set; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }


        public Hand(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateHandSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawning = true;
            DraggingLink = false;
        }
        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
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
                movementBuffer++;
                CheckBounds();
                UpdatePosition();
                sprite.Update();
                if(DraggingLink)
                {
                    DraggingLink = DateTime.Compare(draggingTime, DateTime.Now) > 0;
                    link.ForceMoveToPoint(Position);
                    if (!DraggingLink) draggingTime = DateTime.Now.AddMilliseconds(draggingCooldownMs);
                }
            }
        }

        private void UpdatePosition()
        {
            position.X += xDir == 0 ? -1 * velocityScalar : velocityScalar;
            position.Y += yDir == 0 ? -1 * velocityScalar : velocityScalar;

            if (movementBuffer > directionChangeDelay)
            {
                movementBuffer = 0;
                ChooseDirection();
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
        private void CheckBounds()
        {
            if (position.X <= Constants.MinXPos)
            {
                position.X += velocityScalar;
            }
            else if (position.X >= Constants.MaxXPos)
            {
                position.X -= velocityScalar;
            }
            else if (position.Y <= Constants.MinYPos)
            {
                position.Y += velocityScalar;
            }
            else if (position.Y >= Constants.MaxYPos)
            {
                position.Y -= velocityScalar;
            }
        }
        public void ChooseDirection()
        {
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
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
            safeToDespawn = true;
        }

        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            // hand does not have knockback
        }

        public double GetDamageAmount()
        {
            return Constants.LinkEnemyCollisionDamage;
        }
        public void ResetSpawnCloud()
        {
            spawning = true;
        }

        public void DragLink(IPlayer link)
        {
            if (DraggingLink || DateTime.Compare(draggingTime, DateTime.Now) > 0) return;
            DraggingLink = true;
            this.link = link;
            draggingTime = DateTime.Now + TimeSpan.FromMilliseconds(Constants.HandDragLinkTimeMs);
        }
    }
}
