using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Aquamentus : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int posX = Sprint2.enemyNPCX;
        private int posY = Sprint2.enemyNPCY;
        private int vx = 5;
        private int updateCount = 0;
        private int switchDirection = 50;
        private int attackTime = 33;
        private int attackUpdate = 0;
        private bool attacked = false;
        public Fireball[] spicyBalls = new Fireball[3];

        public Aquamentus(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            updateCount++;

            updateDirection();

            if(updateCount % attackTime == 0)
                Attack();

            if (attacked)
                updateBalls();

            updateSprite();

            sprite.Update();

        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, posX, posY);

            if (attacked)
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
            spicyBalls[0] = new Fireball(spriteBatch, posX, posY, -1);
            spicyBalls[1] = new Fireball(spriteBatch, posX, posY, 0);
            spicyBalls[2] = new Fireball(spriteBatch, posX, posY, 1);
            attacked = true;
            attackUpdate = updateCount;
        }

        private void updateDirection()
        {
            if(updateCount < switchDirection)
                posX -= vx;
            else if(updateCount < 2 * switchDirection)
                posX += vx;
            else
                updateCount = 0;
        }

        private void updateBalls()
        {
            for(int i = 0; i < 3; i++)
                {
                    spicyBalls[i].Update();
                }
        }

        private void updateSprite()
        {
            if(updateCount - attackUpdate <= 4)
            {
                setBreathingSprite();
            }
            else if(attacked)
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
    }
}
