using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Goriya : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        private GoriyaBoomerang boomer;
        private int velocity;
        private int updateCount = 0;
        private int direction = 1;
        private int changeDirection = 100;
        private bool boomerangInitialized = false;
        private bool boomerangActive = false;
        private int attackWaitTime = 150;
        private int attackTime;
        private double health = 3;

        private Random rand = new Random();

        public Goriya(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateGoriyaDownSprite();
            this.spriteBatch = spriteBatch;
            velocity = 2;
        }

        public void Update()
        {
            updateCount++;
            if (updateCount >= 1000)
                updateCount = 0;

            if (!boomerangActive)
                move();

            keepInBounds();

            if (updateCount % attackWaitTime == 0)
                Attack();

            if (boomerangInitialized)
            {
                boomer.Update();
                boomerangActive = boomer.isActive;
            }


            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
            if (boomerangActive)
                boomer.Draw();
        }

        private void move()
        {
            if ((updateCount % changeDirection) == 0)
                ChangeDirection();

            switch (direction)
            {
                case 0: // Up
                    position.Y -= velocity;
                    break;
                case 1: // Down
                    position.Y += velocity;
                    break;
                case 2: // Left
                    position.X -= velocity;
                    break;
                case 3: // Right
                    position.X += velocity;
                    break;
                default:
                    break;
            }

        }

        private void ChangeDirection()
        {
            direction = rand.Next(0, 4);

            switch (direction)
            {
                case 0: // Up
                    setUpSprite();
                    break;
                case 1: // Down
                    setDownSprite();
                    break;
                case 2: // Left
                    setLeftSprite();
                    break;
                case 3: // Right
                    setRightSprite();
                    break;
                default:
                    break;
            }
        }

        private void ChangeDirection(int dir)
        {
            direction = dir;

            switch (direction)
            {
                case 0: // Up
                    setUpSprite();
                    break;
                case 1: // Down
                    setDownSprite();
                    break;
                case 2: // Left
                    setLeftSprite();
                    break;
                case 3: // Right
                    setRightSprite();
                    break;
                default:
                    break;
            }
        }

        private void Attack()
        {
            boomerangActive = true;
            boomerangInitialized = true;
            attackTime = updateCount;
            Vector2 v = new Vector2(0, 0);
            switch (direction)
            {
                case 0: // Up
                    v = new Vector2(0, -5);
                    break;
                case 1: // Down
                    v = new Vector2(0, 5);
                    break;
                case 2: // Left
                    v = new Vector2(-5, 0);
                    break;
                case 3: // Right
                    v = new Vector2(5, 0);
                    break;
                default:
                    break;
            }

            boomer = new GoriyaBoomerang(spriteBatch, position, v);
        }

        private void keepInBounds()
        {
            if (position.X < Constants.MinXPos)
            {
                position.X += velocity;
                ChangeDirection(3); // Right
            }

            else if (position.X > Constants.MaxXPos)
            {
                position.X -= velocity;
                ChangeDirection(2); // Left
            }

            if (position.Y < Constants.MinYPos)
            {
                position.Y += velocity;
                ChangeDirection(1); // Down
            }

            else if (position.Y > Constants.MaxYPos)
            {
                position.Y -= velocity;
                ChangeDirection(0); // Up
            }

        }

        private void setUpSprite()
        {
            sprite = SpriteFactory.Instance.CreateGoriyaUpSprite();
        }

        private void setDownSprite()
        {
            sprite = SpriteFactory.Instance.CreateGoriyaDownSprite();
        }

        private void setLeftSprite()
        {
            sprite = SpriteFactory.Instance.CreateGoriyaLeftSprite();
        }

        private void setRightSprite()
        {
            sprite = SpriteFactory.Instance.CreateGoriyaRightSprite();
        }

        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
            boomerangInitialized = false;
            boomerangActive = false;
            updateCount = 0;
        }
        public void TakeDamage(float damage)
        {
            health = health - damage;
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
        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            //Not implemented yet.
            return new Rectangle();
        }

    }
}
