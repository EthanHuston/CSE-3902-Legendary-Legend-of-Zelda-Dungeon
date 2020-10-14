using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Jelly : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int currentX = ConstantsSprint2.enemyNPCX;
        private int currentY = ConstantsSprint2.enemyNPCY;
        private int movementBuffer = 0;
        private int upDown = 0;
        private int leftRight = 0;
        private double health = .5;

        public Jelly(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateJellySprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            movementBuffer++;
            if (movementBuffer == 16)
            {
                movementBuffer = 0;
                ChooseDirection();
            }
            else
            {
                Move();
            }
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, currentX, currentY);
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            upDown = rand.Next(0, 2); // 0 for x, 1 for y
            leftRight = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
        private void Move()
        {
            //Simulate jelly moving
            if (upDown == 0 && leftRight == 0 && currentX + 16 < Constants.MaxXPos)
            {
                currentX++;
            }
            else if (upDown == 0 && leftRight == 1 && currentX - 16 > Constants.MinXPos)
            {
                currentX--;
            }
            else if (upDown == 1 && leftRight == 0 && currentY + 16 < Constants.MaxYPos)
            {
                currentY--;
            }
            else
            {
                currentY++;
            }
        }
        public void ResetPosition()
        {
            currentX = ConstantsSprint2.enemyNPCX;
            currentY = ConstantsSprint2.enemyNPCY;
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
