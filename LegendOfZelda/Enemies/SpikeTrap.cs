using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class SpikeTrap : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = ConstantsSprint2.enemyNPCX;
        private int currentY = ConstantsSprint2.enemyNPCY;
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;
        private int maxDistance = 50;
        private int currentDist = 0;
        bool returning = false;
        bool going = false;
        private int xOrYDir = 0;

        public SpikeTrap(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateSpikeTrapSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            if (!going && !returning)
            {
                ChooseDirection();
                going = true;
            }
            else if (going)
            {
                MoveGoing();
            }
            else
            {
                MoveReturning();
            }
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }

        private void ChooseDirection()
        {
            Random rand = new Random();
            xOrYDir = rand.Next(0, 2); // 0 for x, 1 for y
        }
        private void MoveGoing()
        {
            if (xOrYDir == 0)
            {
                currentX = currentX + 2;
                currentDist = currentDist + 2;
            }
            else
            {
                currentY = currentY - 2;
                currentDist = currentDist + 2;
            }
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
                currentDist = 0;
            }
        }
        private void MoveReturning()
        {
            if (xOrYDir == 0)
            {
                currentX = currentX--;
                currentDist++;
            }
            else
            {
                currentY = currentY++;
                currentDist++;
            }

            if (currentDist >= maxDistance)
            {
                returning = false;
                currentDist = 0;
            }

        }
    }
}
