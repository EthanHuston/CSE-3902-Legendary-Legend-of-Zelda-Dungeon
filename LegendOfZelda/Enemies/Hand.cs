using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{
    class Hand : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = ConstantsSprint2.enemyNPCX;
        private int currentY = ConstantsSprint2.enemyNPCY;
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
            sprite = SpriteFactory.Instance.CreateHandSprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
            if (xDir == 0 && yDir == 0)
            {
                currentX--;
                currentY--;
            }
            else if (xDir == 0 && yDir == 1)
            {
                currentX--;
                currentY++;
            }
            else if (xDir == 1 && yDir == 0)
            {
                currentX++;
                currentY--;
            }
            else
            {
                currentY++;
                currentX++;
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
            sprite.Draw(spriteBatch, currentX, currentY);
        }
        private void CheckBounds()
        {
            if (currentX == minXVal)
            {
                currentX++;
            }
            else if (currentX == maxXVal)
            {
                currentX--;
            }
            else if (currentY == minYVal)
            {
                currentY++;
            }
            else if (currentY == maxYVal)
            {
                currentY--;
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
            currentX = ConstantsSprint2.enemyNPCX;
            currentY = ConstantsSprint2.enemyNPCY;
        }
        public void TakeDamage(float damage)
        {
            health = health - damage;
        }
        public void Move(Vector2 distance)
        {

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
    }
}
