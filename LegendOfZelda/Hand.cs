using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class Hand : IEnemy
    {
        private HandSprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = Sprint2.enemyNPCX;
        private int currentY = Sprint2.enemyNPCY;
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;

        public Hand(SpriteBatch spriteBatch)
        {
            sprite = (HandSprite)SpriteFactory.Instance.CreateHandSprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
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

            Random rand = new Random();
            int xy = rand.Next(0, 1); // 0 for x, 1 for y
            int pn = rand.Next(0, 1); // 0 right/down. 1 for left/up

            if (xy == 0 && pn == 0)
            {
                currentX++;
            }
            else if (xy == 0 && pn == 1)
            {
                currentX--;
            }
            else if (xy == 1 && pn == 0)
            {
                currentY++;
            }
            else
            {
                currentY--;
            }
            sprite.Update();
            this.Draw();
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
    }
}
