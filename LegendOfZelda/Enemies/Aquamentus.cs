using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Aquamentus : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        private int vx = 1;
        private int updateCount = 0;
        private int switchDirection = 100;
        private int attackTime = 110;
        private int attackUpdate = 0;
        private bool attacked = false;
        private bool ballsInitialized = false;
        private double health = 6;
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
            sprite.Draw(spriteBatch, position);

            if (ballsInitialized)
            {
                for (int i = 0; i < 3; i++)
                {
                    spicyBalls[i].Draw();
                }
            }


        }

        public Point GetPosition()
        {
            return position;
        }

        public Rectangle GetRectangle()
        {
            //Not implemented yet.
            return new Rectangle();
        }

        public void Move(Vector2 distance)
        {

        }
        public void SetPosition(Point position)
        {
            this.position = position;
        }

        public bool SafeToDespawn()
        {
            return health <= 0;
        }

        private void Attack()
        {
            spicyBalls[0] = new Fireball(spriteBatch, position.X, position.Y, -3);
            spicyBalls[1] = new Fireball(spriteBatch, position.X, position.Y, 0);
            spicyBalls[2] = new Fireball(spriteBatch, position.X, position.Y, 3);
            ballsInitialized = true;
            attacked = true;
            attackUpdate = updateCount;
        }

        private void updateDirection()
        {
            if (updateCount < switchDirection)
                position.X -= vx;
            else if (updateCount < 2 * switchDirection)
                position.X += vx;
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
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
            ballsInitialized = false;
            updateCount = 0;
        }
        public void TakeDamage(double damage)
        {
            health = health - damage;
        }
    }
}
