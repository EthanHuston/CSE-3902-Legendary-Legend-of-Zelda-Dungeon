using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    abstract class GenericItem : IItem
    {
        protected ISprite sprite;
        protected bool itemIsExpired;
        protected Point position;
        protected SpriteBatch spriteBatch;

        public GenericItem(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            position = spawnPosition;
        }

        protected abstract void CheckItemIsExpired();

        public virtual void Update()
        {
            sprite.Update();
            CheckItemIsExpired();
        }

        public virtual void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            Rectangle size = sprite.GetPositionRectangle();
            return new Rectangle(position.X, position.Y, size.Width, size.Height);
        }

        public void Move(Vector2 distance)
        {
            SetPosition(new Point(position.X + (int)distance.X, position.Y + (int)distance.Y));
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public void SetPosition(Point position)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
        }

        public void Despawn()
        {
            itemIsExpired = true;
        }
    }
}
