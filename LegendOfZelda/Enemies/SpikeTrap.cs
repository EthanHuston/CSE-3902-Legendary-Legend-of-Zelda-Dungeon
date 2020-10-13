using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class SpikeTrap : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
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
            //Needs new implementation with Link knowledge
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch,position);
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
                position.X = position.X + 2;
                currentDist = currentDist + 2;
            }
            else
            {
                position.Y = position.Y - 2;
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
                position.X = position.X--;
                currentDist++;
            }
            else
            {
                position.Y = position.Y++;
                currentDist++;
            }

            if (currentDist >= maxDistance)
            {
                returning = false;
                currentDist = 0;
            }

        }
        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
        }
    }
}
