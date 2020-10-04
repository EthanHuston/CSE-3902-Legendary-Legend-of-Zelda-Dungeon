using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemies
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
        private bool attacked = false;
        Fireball[] spicyBalls = new Fireball[3];

        public Aquamentus(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            updateCount++;
            if (updateCount < switchDirection)
            {
                posX -= vx;
            }
            else if(updateCount < 2 * switchDirection)
            {
                posX += vx;
            }
            else
            {
                updateCount = 0;
            }

            if(updateCount % attackTime == 0)
            {
                Attack();
                attacked = true;
            }

            if (attacked)
            {
                for(int i = 0; i < 3; i++)
                {
                    spicyBalls[i].Update();
                }
            }

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
