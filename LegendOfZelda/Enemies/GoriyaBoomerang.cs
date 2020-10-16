using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class GoriyaBoomerang : INpc
    {
        // TODO: I think we can combine this class and Items.BoomerangFlyingItem?
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private Vector2 velocity;
        public int retractRang = 30;
        private int updateCount = 0;
        public bool isActive;

        public GoriyaBoomerang(SpriteBatch spriteBatch, Point pos, Vector2 velocity)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateGoriyaBoomerangSprite();
            this.position = pos;
            this.velocity = velocity;
            isActive = true;
        }

        public void Update()
        {
            updateCount++;
            if (updateCount < retractRang)
            {
                position.X += (int)velocity.X;
                position.Y += (int)velocity.Y;
            }
            else if (updateCount < 2 * retractRang)
            {
                position.X -= (int)velocity.X;
                position.Y -= (int)velocity.Y;
            }
            else
                isActive = false;

            sprite.Update();

        }

        public void Draw()
        {
            if (isActive)
                sprite.Draw(spriteBatch, position);
        }
        public void ResetPosition()
        {

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
            return false;
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
