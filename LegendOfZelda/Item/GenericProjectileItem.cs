using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    abstract class GenericProjectileItem : GenericItem
    {
        protected Vector2 velocity;

        public GenericProjectileItem(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner) : base(spriteBatch, spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            position.X = spawnPosition.X;
            position.Y = spawnPosition.Y;
            this.owner = owner;
        }

        public abstract override void Update();

        public override abstract Vector2 GetVelocity();
    }
}
