using System;
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
        private JellySprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = Sprint2.enemyNPCX;
        private int currentY = Sprint2.enemyNPCY;
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;
        private int movementBuffer = 0;

        public Jelly(SpriteBatch spriteBatch)
        {
            sprite = (JellySprite)SpriteFactory.Instance.CreateJellySprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            Random rand = new Random();
            int xy = rand.Next(0, 1); // 0 for x, 1 for y
            int pn = rand.Next(0, 1); // 0 right/down. 1 for left/up

            movementBuffer++;
            if (movementBuffer == 6)
            {
                //Simulate jelly moving
                if (xy == 0 && pn == 0 && currentX < maxXVal)
                {
                    currentX = currentX + 16;
                }
                else if (xy == 0 && pn == 1 && currentX > minXVal)
                {
                    currentX = currentX - 16;
                }
                else if (xy == 1 && pn == 0 && currentY < maxYVal)
                {
                    currentY = currentY + 16;
                }
                else
                {
                    currentY = currentY + 16;
                }
            }
            else
            {
                movementBuffer++;
            }

            this.Draw();

        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
    }
}
