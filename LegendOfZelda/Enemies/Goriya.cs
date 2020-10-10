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
        private Vector2 pos;
        private GoriyaBoomerang boomer;
        private int velocity;
        private int updateCount = 0;
        private int direction = 1;
        private int changeDirection = 100;
        private bool boomerangInitialized = false;
        private bool boomerangActive = false;
        private int attackWaitTime = 150;
        private int attackTime;

        private Random rand = new Random();

        public Goriya(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateGoriyaDownSprite();
            this.spriteBatch = spriteBatch;
            pos.X = ConstantsSprint2.enemyNPCX;
            pos.Y = ConstantsSprint2.enemyNPCY;
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
            sprite.Draw(spriteBatch, (int)pos.X, (int)pos.Y);
            if (boomerangActive)
                boomer.Draw();
        }

        public Vector2 getPos()
        {
            return pos;
        }

        public void setPos(Vector2 pos)
        {
            this.pos = pos;
        }

        private void move()
        {
            if ((updateCount % changeDirection) == 0)
                ChangeDirection();

            switch (direction)
            {
                case 0: // Up
                    pos.Y -= velocity;
                    break;
                case 1: // Down
                    pos.Y += velocity;
                    break;
                case 2: // Left
                    pos.X -= velocity;
                    break;
                case 3: // Right
                    pos.X += velocity;
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

            boomer = new GoriyaBoomerang(spriteBatch, pos, v);
        }

        private void keepInBounds()
        {
            if (pos.X < Constants.MinXPos)
            {
                pos.X += velocity;
                ChangeDirection(3); // Right
            }

            else if (pos.X > Constants.MaxXPos)
            {
                pos.X -= velocity;
                ChangeDirection(2); // Left
            }

            if (pos.Y < Constants.MinYPos)
            {
                pos.Y += velocity;
                ChangeDirection(1); // Down
            }

            else if (pos.Y > Constants.MaxYPos)
            {
                pos.Y -= velocity;
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
            pos.X = ConstantsSprint2.enemyNPCX;
            pos.Y = ConstantsSprint2.enemyNPCY;
            boomerangInitialized = false;
            boomerangActive = false;
            updateCount = 0;
        }

    }
}
