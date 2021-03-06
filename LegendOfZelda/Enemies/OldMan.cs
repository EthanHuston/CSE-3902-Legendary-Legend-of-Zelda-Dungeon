﻿using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    internal class OldMan : INpc
    {
        private readonly ISprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private bool spawning;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public OldMan(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            SafeToDespawn = false;
            spawning = true;
        }

        public void Draw()
        {
            if (spawning)
            {
                spawnSprite.Draw(spriteBatch, position, Constants.DrawLayer.EnemySpawnSprite);
            }
            else
            {
                sprite.Draw(spriteBatch, position, Constants.DrawLayer.Enemy);
            }
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
                sprite.Update();
            }
        }

        public void ClockUpdate() { }
        
        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }
        
        public void TakeDamage(double damage)
        {
            // old man knoweth not the concept of damage
        }

        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            // knows no knockback
        }

        public double GetDamageAmount()
        {
            return 0; // does no damage
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
        public void ResetSpawnCloud()
        {
            spawning = true;
        }
    }
}
