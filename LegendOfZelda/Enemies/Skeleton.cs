using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Skeleton : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = ConstantsSprint2.enemyNPCX;
        private int currentY = ConstantsSprint2.enemyNPCY;
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;
        private int movementBuffer = 0;
        private int upDown = 0;
        private int leftRight = 0;

        public Skeleton(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateSkeletonSprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
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
            }
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            upDown = rand.Next(0, 2); // 0 for x, 1 for y
            leftRight = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
        private void Move()
        {
            if (upDown == 0 && leftRight == 0 && currentX + 32 < maxXVal)
            {
                currentX++;
            }
            else if (upDown == 0 && leftRight == 1 && currentX - 32 > minXVal)
            {
                currentX--;
            }
            else if (upDown == 1 && leftRight == 0 && currentY + 32 < maxYVal)
            {
                currentY--;
            }
            else if (currentY - 32 > minYVal)
            {
                currentY++;
            }
        }
        public void ResetPosition()
        {
            currentX = ConstantsSprint2.enemyNPCX;
            currentY = ConstantsSprint2.enemyNPCY;
        }
    }
}
