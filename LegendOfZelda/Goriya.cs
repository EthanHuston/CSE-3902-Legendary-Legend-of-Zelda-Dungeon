using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Goriya : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Vector2 pos;
        private int velocity;
        private int updateCount = 0;
        private int direction = 0;
        private int changeDirection = 50;

        private Random rand = new Random();

        public Goriya(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateDogLikeMonsterSprite();
            this.spriteBatch = spriteBatch;
            pos.X = Sprint2.enemyNPCX;
            pos.Y = Sprint2.enemyNPCY;
            velocity = 5;
        }

        public void Update()
        {
            updateCount++;
            move();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, pos.X, pos.Y);
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
            if(updateCount % changeDirection == 0)
                direction = rand.Next(0, 3);

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
    }
}
