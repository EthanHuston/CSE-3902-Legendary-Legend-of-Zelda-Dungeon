using LegendOfZelda.Link;
using LegendOfZelda.Projectile.Sprite;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal abstract class GenericProjectile : IProjectile
    {
        protected IProjectileSprite sprite;
        protected bool itemIsExpired;
        protected SpriteBatch spriteBatch;
        protected LinkConstants.ProjectileType projectileType;

        public SpawnableMover Mover { get; private set; }

        public Constants.ProjectileOwner Owner { get; private set; }

        public Point Position { get => Mover.Position; set => Mover.Position = value; }

        public Vector2 Velocity { get => Mover.Velocity; set => Mover.Velocity = value; }
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        public GenericProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner)
        {
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            this.spriteBatch = spriteBatch;
            Owner = owner;
        }

        public abstract void Update();

        public abstract double DamageAmount();

        public virtual void Draw()
        {
            sprite.Draw(spriteBatch, Position, Constants.DrawLayer.Projectile);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public void Move(int distance, Vector2 velocity)
        {
            Mover.MoveDistance(distance, velocity);
        }

        public void Despawn()
        {
            SafeToDespawn = true;
        }

        public LinkConstants.ProjectileType GetProjectileType()
        {
            return projectileType;
        }
    }
}
