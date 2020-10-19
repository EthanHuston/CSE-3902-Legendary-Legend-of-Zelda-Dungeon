using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Hand : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private double health = 4;


        public Hand(SpriteBatch spriteBatch)
        {
            sprite = EnemySpriteFactory.Instance.CreateHandSprite();
            this.spriteBatch = spriteBatch;
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
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position, false);
        }
        private void CheckBounds()
        {
            if (position.X == minXVal)
            {
                position.X++;
            }
            else if (position.X == maxXVal)
            {
                position.X--;
            }
            else if (position.Y == minYVal)
            {
                position.Y++;
            }
            else if (position.Y == maxYVal)
            {
                position.Y--;
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
        public void TakeDamage(float damage)
        {
            health = health - damage;
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
