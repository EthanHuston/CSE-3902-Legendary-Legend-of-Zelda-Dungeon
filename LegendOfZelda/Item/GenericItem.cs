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
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

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
            sprite.Draw(spriteBatch, position, Constants.DrawLayer.Item);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(position.X, position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
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
