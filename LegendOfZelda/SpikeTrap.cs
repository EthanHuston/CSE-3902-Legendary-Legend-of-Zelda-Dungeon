using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class SpikeTrap : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = Sprint2.enemyNPCX;
        private int currentY = Sprint2.enemyNPCY;
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;
        private int maxDistance = 20;

        public SpikeTrap(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateSpikeTrapSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            Random rand = new Random();
            int xy = rand.Next(0, 1); // 0 for x, 1 for y
            int pn = rand.Next(0, 1); // 0 right/down. 1 for left/up

            for(int i = 0; i < maxDistance; i++)
            {
                if (currentX == minXVal)
                {
                    break;
                }
                else if (currentX == maxXVal)
                {
                    break;
                }
                else if (currentY == minYVal)
                {
                    break;
                }
                else if (currentY == maxYVal)
                {
                    break;
                }

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
                this.Draw();
            }
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
    }
}
