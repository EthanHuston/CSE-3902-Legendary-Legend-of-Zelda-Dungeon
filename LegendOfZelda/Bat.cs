﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Bat : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = Sprint2.enemyNPCX;
        private int currentY = Sprint2.enemyNPCY;
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
                currentX++;
            } else if (xDir == 0 && yDir == 1)
            {
                currentX--;
            } else if(xDir == 1 && yDir == 0)
            {
                currentY++;
            }
            else
            {
                currentY--;
            }

            if(movementBuffer > 10)
            {
                movementBuffer = 0;
                ChooseDirection();
            }

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
            int xDir = rand.Next(0, 1); // 0 for x, 1 for y
            int yDir = rand.Next(0, 1); // 0 right/down. 1 for left/up
        }
    }
}