using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Aquamentus : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int posX = ConstantsSprint2.enemyNPCX;
        private int posY = ConstantsSprint2.enemyNPCY;
        private int vx = 1;
        private int updateCount = 0;
        private int switchDirection = 100;
        private int attackTime = 110;
        private int attackUpdate = 0;
        private bool attacked = false;
        private bool ballsInitialized = false;
        public Fireball[] spicyBalls = new Fireball[3];

        public Aquamentus(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            //updateCount++;

            if (!attacked)
                updateDirection();

            if (updateCount % attackTime == 0)
                Attack();

            if (ballsInitialized)
                updateBalls();

            updateSprite();

            sprite.Update();

            updateCount++;

        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, posX, posY);

            if (ballsInitialized)
            {
                for (int i = 0; i < 3; i++)
                {
                    spicyBalls[i].Draw();
                }
            }
            

        }

        public int getX()
        {
            return posX;
        }

        public int getY()
        {
            return posY;
        }

        private void Attack()
        {
            spicyBalls[0] = new Fireball(spriteBatch, posX, posY, -3);
            spicyBalls[1] = new Fireball(spriteBatch, posX, posY, 0);
            spicyBalls[2] = new Fireball(spriteBatch, posX, posY, 3);
            ballsInitialized = true;
            attacked = true;
            attackUpdate = updateCount;
        }

        private void updateDirection()
        {
            if (updateCount < switchDirection)
                posX -= vx;
            else if (updateCount < 2 * switchDirection)
                posX += vx;
            else
                updateCount = 0;
        }

        private void updateBalls()
        {
            for (int i = 0; i < 3; i++)
            {
                spicyBalls[i].Update();
            }
        }

        private void updateSprite()
        {
            if (updateCount - attackUpdate <= 4)
            {
                setBreathingSprite();
            }
            else if (attacked)
            {
                setWalkingSprite();
                attacked = false;
            }
        }

        private void setBreathingSprite()
        {
            sprite = SpriteFactory.Instance.CreateAquamentusBreathingSprite();
        }

        private void setWalkingSprite()
        {
            sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
        }
        public void ResetPosition()
        {
            posX = ConstantsSprint2.enemyNPCX;
            posY = ConstantsSprint2.enemyNPCY;
            ballsInitialized = false;
            updateCount = 0;
        }
    }
}
