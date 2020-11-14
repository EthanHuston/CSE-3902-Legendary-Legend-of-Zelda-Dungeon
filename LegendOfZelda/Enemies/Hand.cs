using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    internal class Hand : INpc
    {
        private readonly int velocityScalar = (int) Math.Ceiling(0.5 * Constants.GameScaler);
        private double health = 2 * Constants.HeartValue;
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private readonly IRoom roomToJumpTo;
        private Vector2 velocity;
        private bool safeToDespawn;
        private DateTime healthyDateTime;
        private bool damaged;
        private bool spawning;
        private IPlayer link;

        public bool DraggingLink { get; private set; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }


        public Hand(SpriteBatch spriteBatch, Point spawnPosition, IRoom roomToJumpTo)
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
            this.roomToJumpTo = roomToJumpTo;
            velocity = SetVelocityFromPosition(spawnPosition);
        }

        private Vector2 SetVelocityFromPosition(Point spawnPosition)
        {
            Vector2 velocity = Vector2.Zero;
            if (spawnPosition.X <= Constants.MinXPos) velocity.X = velocityScalar;
            else if (spawnPosition.X >= Constants.MaxXPos) velocity.X = -1 * velocityScalar;
            else if (spawnPosition.Y <= Constants.MinYPos) velocity.Y = velocityScalar;
            else if (spawnPosition.Y >= Constants.MaxYPos) velocity.Y = -1 * velocityScalar;

            return velocity;
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
                if (DraggingLink)
                {
                    link.ForceMoveToPoint(Position);
                }
                CheckBounds();
                if (!safeToDespawn)
                {
                    sprite.Update();
                    UpdatePosition();
                }
            }
        }

        private void UpdatePosition()
        {
            position.X += (int)velocity.X;
            position.Y += (int)velocity.Y;
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
            safeToDespawn = safeToDespawn ||
                position.X > Constants.HandSpawnRightX ||
                position.X < Constants.HandSpawnLeftX ||
                position.Y > Constants.HandSpawnDownY ||
                position.Y < Constants.HandSpawnUpY;
            
            if(DraggingLink && safeToDespawn) // once outside map, jump back to beginning room
            {
                link.BeingDragged = false;
                ((RoomGameState)link.Game.State).MoveToRoom(roomToJumpTo, Constants.Direction.Down);
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
            DraggingLink = true;
            this.link = link;
            link.BeingDragged = true;
            velocity.X = 0;
            velocity.Y = 2 * velocityScalar;
        }
    }
}
