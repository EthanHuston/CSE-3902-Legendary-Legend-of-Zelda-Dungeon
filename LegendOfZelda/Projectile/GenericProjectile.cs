using LegendOfZelda.Interface;
using LegendOfZelda.Projectile.Sprite;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    abstract class GenericProjectile : IProjectile
    {
        protected IProjectileSprite sprite;
        protected bool itemIsExpired;
        protected SpriteBatch spriteBatch;

        public SpawnableMover Mover { get; private set; }

        public Constants.ItemOwner Owner { get; private set; }

        public Point Position { get => Mover.Position; set => Mover.Position = value; }

        public Vector2 Velocity { get => Mover.Velocity; set => Mover.Velocity = value; }

        public GenericProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner)
        {
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            this.spriteBatch = spriteBatch;
            Owner = owner;
        }

        protected abstract void CheckItemIsExpired();

        public abstract void Update();

        public abstract double DamageAmount();

        public virtual void Draw()
        {
            sprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            Rectangle size = sprite.GetPositionRectangle();
            return new Rectangle(Position.X, Position.Y, size.Width, size.Height);
        }

        public void Move(int distance, Vector2 velocity)
        {
            Mover.MoveDistance(distance, velocity);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public void Despawn()
        {
            itemIsExpired = true;
        }
    }
}
