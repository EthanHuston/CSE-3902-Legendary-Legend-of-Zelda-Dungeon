using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    internal abstract class GenericItem : IItem
    {
        protected ISprite sprite;
        protected bool itemIsExpired;
        protected SpriteBatch spriteBatch;
        protected LinkConstants.ItemType itemType;

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

        public Rectangle GetRectangle()
        {
            return new Rectangle(position.X, position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public void Despawn()
        {
            itemIsExpired = true;
        }

        public LinkConstants.ItemType GetItemType()
        {
            return itemType;
        }
    }
}
