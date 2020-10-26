using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    abstract class GenericItem : IItem
    {
        protected ISprite sprite;
        protected bool itemIsExpired;
        protected SpriteBatch spriteBatch;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public GenericItem(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
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
            return new Rectangle(position.X, position.Y, size.Top, size.Right);
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
