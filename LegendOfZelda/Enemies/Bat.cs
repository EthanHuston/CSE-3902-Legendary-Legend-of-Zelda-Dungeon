using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Bat : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private double health = 0.5;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Bat(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = EnemySpriteFactory.Instance.CreateBatSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Update()
        {
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
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

            if (movementBuffer > 10)
            {
                movementBuffer = 0;
                ChooseDirection();
            }
            sprite.Update();
            safeToDespawn = !safeToDespawn && health <= 0;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);

        }

        //Movement character away from edge of screen
        private void CheckBounds()
        {
            if (position.X >= Constants.MinXPos)
            {
                position.X =+ 5;
            }
            else if (position.X <= Constants.MaxXPos)
            {
                position.X =- 5; ;
            }
            else if (position.Y >= Constants.MaxYPos)
            {
                position.Y =+ 5; ;
            }
            else if (position.Y <= Constants.MinYPos)
            {
                position.Y =- 5;
            }
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
        }
        public void TakeDamage(double damage)
        {
            health -= damage;
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
    }
}
