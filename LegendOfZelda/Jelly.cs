﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class Jelly : IEnemy
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
        private int upDown = 0;
        private int leftRight = 0;

        public Jelly(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateJellySprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
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

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            upDown = rand.Next(0, 1); // 0 for x, 1 for y
            leftRight = rand.Next(0, 1); // 0 right/down. 1 for left/up
        }
        private void Move()
        {
            //Simulate jelly moving
            if (upDown == 0 && leftRight == 0 && currentX + 16 < maxXVal)
            {
                currentX++;
            }
            else if (upDown == 0 && leftRight== 1 && currentX - 16 > minXVal)
            {
                currentX--;
            }
            else if (upDown == 1 && leftRight == 0 && currentY + 16 < maxYVal)
            {
                currentY--;
            }
            else 
            {
                currentY++;
            }
        }
    }
}