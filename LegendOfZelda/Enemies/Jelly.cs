using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{
    class Jelly : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
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
            sprite.Draw(spriteBatch, position, false);
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
            if (upDown == 0 && leftRight == 0 && position.X + 16 < Constants.MaxXPos)
            {
                position.X++;
            }
            else if (upDown == 0 && leftRight == 1 && position.X - 16 > Constants.MinXPos)
            {
                position.X--;
            }
            else if (upDown == 1 && leftRight == 0 && position.Y + 16 < Constants.MaxYPos)
            {
                position.Y--;
            }
            else
            {
                position.Y++;
            }
        }
        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
        }
        public void TakeDamage(float damage)
        {
            health = health - damage;
        }
        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
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
            return sprite.GetPositionRectangle();
        }
    }
}
