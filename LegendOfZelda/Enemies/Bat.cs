using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Bat : IEnemy
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
        private int xDir = 0;
        private int yDir = 0;

        public Bat(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateBatSprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
            if(xDir == 0 && yDir == 0)
            {
                currentX--;
                currentY--;
            } else if (xDir == 0 && yDir == 1)
            {
                currentX--;
                currentY++;
            } else if(xDir == 1 && yDir == 0)
            {
                currentX++;
                currentY--;
            }
            else
            {
                currentY++;
                currentX++;
            }

            if(movementBuffer > 10)
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

        //Movement character away from edge of screen
        private void CheckBounds()
        {
            if (currentX == minXVal)
            {
                currentX = currentX + 5;
            }
            else if (currentX == maxXVal)
            {
                currentX = currentX - 5; ;
            }
            else if (currentY == minYVal)
            {
                currentY = currentY + 5; ;
            }
            else if (currentY == maxYVal)
            {
                currentY = currentY - 5;
            }
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
    }
}
