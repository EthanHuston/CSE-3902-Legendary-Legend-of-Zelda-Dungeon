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
        private int maxDistance = 50;
        private int currentDist = 0;
        bool returning = false;

        public SpikeTrap(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateSpikeTrapSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            currentY--;
            if (returning)
            {
                currentY++;
                currentDist--;
                if(currentDist <= 0)
                {
                    returning = false;
                }
            }
            else
            {
                currentY = currentY - 2;
                currentDist = currentDist + 2;
                if(currentDist >= maxDistance)
                {
                    returning = true;
                }
                
            }
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
    }
}
