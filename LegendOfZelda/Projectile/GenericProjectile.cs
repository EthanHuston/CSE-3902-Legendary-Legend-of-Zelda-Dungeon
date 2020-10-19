using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    abstract class GenericProjectile : IProjectile
    {
        protected Vector2 velocity;
        protected IItemSprite sprite;
        protected bool itemIsExpired;
        protected Point position;
        protected SpriteBatch spriteBatch;
        protected Constants.ItemOwner owner;

        public GenericProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner)
        {
            this.spriteBatch = spriteBatch;
            position = spawnPosition;
            this.owner = owner;
            velocity = Vector2.Zero;
        }

        protected abstract void CheckItemIsExpired();

        public abstract void Update();

        public abstract Vector2 GetVelocity();

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

        public Constants.ItemOwner GetItemOwner()
        {
            return owner;
        }

        public abstract double DamageAmount();
    }
}
