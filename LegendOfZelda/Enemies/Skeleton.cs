using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class Skeleton : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        private int minXVal = 0;
        private int maxXVal = 800;
        private int minYVal = 0;
        private int maxYVal = 480;
        private int movementBuffer = 0;
        private int upDown = 0;
        private int leftRight = 0;
        private double health = 2;

        public Skeleton(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateSkeletonSprite();
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            movementBuffer++;
            CheckBounds();
            if (movementBuffer == 20)
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
            sprite.Draw(spriteBatch, position);
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            upDown = rand.Next(0, 2); // 0 for x, 1 for y
            leftRight = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
        private void Move()
        {
            if (upDown == 0 && leftRight == 0 && position.X + 32 < maxXVal)
            {
                position.X++;
            }
            else if (upDown == 0 && leftRight == 1 && position.X - 32 > minXVal)
            {
                position.X++;
            }
            else if (upDown == 1 && leftRight == 0 && position.Y + 32 < maxYVal)
            {
                position.Y--;
            }
            else if (position.Y - 32 > minYVal)
            {
                position.Y++;
            }
        }
        private void CheckBounds()
        {
            if (position.X == minXVal)
            {
                position.X = position.X + 5;
            }
            else if (position.X == maxXVal)
            {
                position.X = position.X - 5; ;
            }
            else if (position.Y == minYVal)
            {
                position.Y = position.Y + 5; ;
            }
            else if (position.Y == maxYVal)
            {
                position.Y = position.Y - 5;
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

        public void TakeDamage(double damage)
        {
            health -= damage;
        }

        public void Despawn()
        {
        }
    }
}
