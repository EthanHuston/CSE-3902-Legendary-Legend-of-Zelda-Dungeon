using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State;
using LegendOfZelda.Projectile;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.Link
{
    internal class LinkPlayer : IPlayer
    {
        public Game1 Game;
        private double currentHealth;
        private double maxHealth;
        private Dictionary<LinkConstants.ItemType, int> inventory;
        private Dictionary<LinkConstants.ProjectileType, IProjectile> currentProjectiles;
        private bool safeToDespawn;
        private ILinkState state;

        public Constants.Direction FacingDirection { get; set; }
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; }
        public SpawnableMover Mover { get; private set; }
        public ILinkState State { get => state; set { if (!BlockStateChange) state = value; } }
        public Point Position { get => Mover.Position; set => Mover.Position = value; }
        public Vector2 Velocity { get => Mover.Velocity; set => Mover.Velocity = value; }

        public LinkPlayer(Game1 game, Point spawnPosition)
        {
            currentHealth = LinkConstants.StartingHealth;
            maxHealth = LinkConstants.StartingHealth;
            Game = game;
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            FacingDirection = Constants.Direction.Down;
            State = new LinkStandingStillState(this);
            safeToDespawn = false;
            BlockStateChange = false;
            InitInventoryDict();
            InitCurrentProjectileDict();
        }

        public void Draw()
        {
            State.Draw();
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && currentHealth <= 0;
            State.Update();
        }

        public void BeHealthy(double healAmount)
        {
            State.BeHealthy(healAmount);
        }

        public void BeDamaged(double damage)
        {
            State.BeDamaged(damage);
        }

        public void SubtractHealth(double damage)
        {
            currentHealth -= damage;
        }

        public void AddHealth(double healAmount)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
        }

        public void IncreaseMaxHealth(int amount)
        {
            maxHealth += amount;
        }

        public void GiveFullHealth()
        {
            currentHealth = maxHealth;
        }

        public void MoveUp()
        {
            State.Move(Constants.Direction.Up);
        }

        public void MoveDown()
        {
            State.Move(Constants.Direction.Down);
        }
        public void MoveLeft()
        {
            State.Move(Constants.Direction.Left);
        }
        public void MoveRight()
        {
            State.Move(Constants.Direction.Right);
        }

        public void StopMoving()
        {
            State.StopMoving();
        }

        public void SpawnItem(IProjectile projectile)
        {
            IProjectile currentProjectile = currentProjectiles[projectile.GetProjectileType()];
            if (currentProjectile != null && !currentProjectile.SafeToDespawn()) return;

            ((RoomGameState)Game.State).SpawnableManager.Spawn(projectile);
            currentProjectiles[projectile.GetProjectileType()] = projectile;
        }

        public void UseSword()
        {
            if (inventory[LinkConstants.ItemType.Sword] <= 0) return;
            State.UseSword();
            SoundFactory.Instance.CreateSwordSlashSound().Play();
        }

        public void UseBow()
        {
            if (inventory[LinkConstants.ItemType.Bow] <= 0 && inventory[LinkConstants.ItemType.Rupee] <= 0) return;
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.ArrowSpeed);
            SpawnItem(new ArrowFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingArrowSpawnOffset, Constants.ProjectileOwner.Link, velocity));
        }

        public void UseBomb()
        {
            if (inventory[LinkConstants.ItemType.Bomb] <= 0) return;
            SpawnItem(new BombExplodingProjectile(Game.SpriteBatch, Position, Constants.ProjectileOwner.Link));
        }

        public void UseBoomerang()
        {
            if (inventory[LinkConstants.ItemType.Boomerang] <= 0) return;
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.BoomerangSpeed);
            SpawnItem(new BoomerangFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingBoomerangSpawnOffset, Constants.ProjectileOwner.Link, this, velocity));
        }

        public void UseSwordBeam()
        {
            IProjectile projectile = currentProjectiles[LinkConstants.ProjectileType.SwordBeam];
            if (inventory[LinkConstants.ItemType.Sword] > 0 && (projectile == null || projectile.SafeToDespawn())) SpawnItem(new SwordBeamFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingSwordBeamSpawnOffset, Constants.ProjectileOwner.Link, FacingDirection));
        }

        public void Move(int distance, Vector2 velocity)
        {
            Mover.MoveDistance(distance, velocity);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(
                Position.X + LinkConstants.CollisionHelper,
                Position.Y + LinkConstants.CollisionHelper,
                CurrentSprite.GetPositionRectangle().Width - LinkConstants.CollisionHelper * 2,
                CurrentSprite.GetPositionRectangle().Height - LinkConstants.CollisionHelper * 2);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void PickupItem(LinkConstants.ItemType itemType)
        {
            inventory[itemType]++;
            state.PickUpItem(itemType);
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        private void InitInventoryDict()
        {
            inventory = new Dictionary<LinkConstants.ItemType, int>()
            {
                {LinkConstants.ItemType.Rupee, 0 },
                {LinkConstants.ItemType.Bomb, 0 },
                {LinkConstants.ItemType.Clock, 0 },
                {LinkConstants.ItemType.Compass, 0 },
                {LinkConstants.ItemType.Key, 0 },
                {LinkConstants.ItemType.Map, 0 },
                {LinkConstants.ItemType.Boomerang, 1 },
                {LinkConstants.ItemType.Bow, 0 },
                {LinkConstants.ItemType.Sword, 1 },
            };
        }

        private void InitCurrentProjectileDict()
        {
            currentProjectiles = new Dictionary<LinkConstants.ProjectileType, IProjectile>()
            {
                {LinkConstants.ProjectileType.Sword, null },
                {LinkConstants.ProjectileType.Bomb, null },
                {LinkConstants.ProjectileType.Boomerang, null },
                {LinkConstants.ProjectileType.SwordBeam, null },
                {LinkConstants.ProjectileType.Arrow, null }
            };
        }

        private Vector2 CreateVelocityVector(Constants.Direction direction, int speed)
        {
            Vector2 velocity = Vector2.Zero;
            switch (direction)
            {
                case Constants.Direction.Up:
                    velocity.Y = -1 * speed;
                    return velocity;
                case Constants.Direction.Down:
                    velocity.Y = speed;
                    return velocity;
                case Constants.Direction.Left:
                    velocity.X = -1 * speed;
                    return velocity;
                case Constants.Direction.Right:
                    velocity.X = speed;
                    return velocity;
            }
            return velocity;
        }
    }
}
