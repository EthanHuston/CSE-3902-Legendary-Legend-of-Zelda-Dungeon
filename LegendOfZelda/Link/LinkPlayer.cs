using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State;
using LegendOfZelda.Projectile;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Link
{
    internal class LinkPlayer : IPlayer
    {
        private double currentHealth;
        private double maxHealth;
        private Dictionary<LinkConstants.ItemType, int> inventory;
        private readonly Dictionary<LinkConstants.ProjectileType, IProjectile> currentProjectiles;
        private bool safeToDespawn;
        private ILinkState state;


        public Game1 Game { get; private set; }
        public Constants.Direction FacingDirection { get; set; }
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; }
        public SpawnableMover Mover { get; private set; }
        public ILinkState State { get => state; set { if (!BlockStateChange) state = value; } }
        public Point Position { get => Mover.Position; set => Mover.Position = value; }
        public Vector2 Velocity { get => Mover.Velocity; set => Mover.Velocity = value; }
        public LinkConstants.ItemType PrimaryItem => currentHealth == maxHealth ? LinkConstants.ItemType.SwordBeam : LinkConstants.ItemType.Sword;
        public LinkConstants.ItemType SecondaryItem { get; set; }

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
            currentProjectiles = new Dictionary<LinkConstants.ProjectileType, IProjectile>();
            SecondaryItem = LinkConstants.ItemType.None;
            InitInventoryDict();
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
            currentHealth += amount;
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
            IProjectile currentProjectile;

            if (currentProjectiles.ContainsKey(projectile.GetProjectileType()))
                currentProjectile = currentProjectiles[projectile.GetProjectileType()];
            else
            {
                currentProjectile = null;
                currentProjectiles.Add(projectile.GetProjectileType(), null);
            }

            if (currentProjectile != null && !currentProjectile.SafeToDespawn()) return;

            ((RoomGameState)Game.State).SpawnableManager.Spawn(projectile);
            currentProjectiles[projectile.GetProjectileType()] = projectile;
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
                {LinkConstants.ItemType.Rupee, LinkConstants.RupeeCount },
                {LinkConstants.ItemType.Bomb, LinkConstants.BombCount },
                {LinkConstants.ItemType.Clock, 0 },
                {LinkConstants.ItemType.Compass, 0 },
                {LinkConstants.ItemType.Key, 0 },
                {LinkConstants.ItemType.Map, 0 },
                {LinkConstants.ItemType.Boomerang, LinkConstants.BoomerangCount },
                {LinkConstants.ItemType.Bow, LinkConstants.BowCount },
                {LinkConstants.ItemType.Sword, LinkConstants.SwordCount }
            };
        }

        public int GetQuantityInInventory(LinkConstants.ItemType itemType)
        {
            return inventory.ContainsKey(itemType) ? inventory[itemType] : 0;
        }

        public void UsePrimary()
        {
            UseItem(PrimaryItem);
        }

        public void UseSecondary()
        {
            UseItem(SecondaryItem);
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

        private void UseItem(LinkConstants.ItemType item)
        {
            switch (item)
            {
                case LinkConstants.ItemType.Sword:
                    UseSword();
                    break;
                case LinkConstants.ItemType.SwordBeam:
                    UseSwordBeam();
                    break;
                case LinkConstants.ItemType.Bow:
                    UseBow();
                    break;
                case LinkConstants.ItemType.Bomb:
                    UseBomb();
                    break;
                case LinkConstants.ItemType.Boomerang:
                    UseBoomerang();
                    break;
            }
        }

        private void UseSword()
        {
            if (inventory[LinkConstants.ItemType.Sword] <= 0) return;
            State.UseSword();
        }

        private void UseBow()
        {
            if (inventory[LinkConstants.ItemType.Bow] <= 0 || inventory[LinkConstants.ItemType.Rupee] <= 0) return;
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.ArrowSpeed);
            SpawnItem(new ArrowFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingArrowSpawnOffset, Constants.ProjectileOwner.Link, velocity));
        }

        private void UseBomb()
        {
            if (inventory[LinkConstants.ItemType.Bomb] <= 0) return;
            SpawnItem(new BombExplodingProjectile(Game.SpriteBatch, Position, Constants.ProjectileOwner.Link));
        }

        private void UseBoomerang()
        {
            if (inventory[LinkConstants.ItemType.Boomerang] <= 0) return;
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.BoomerangSpeed);
            SpawnItem(new BoomerangFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingBoomerangSpawnOffset, Constants.ProjectileOwner.Link, this, velocity));
        }

        private void UseSwordBeam()
        {
            if (inventory[LinkConstants.ItemType.Sword] <= 0) return;
            SpawnItem(new SwordBeamFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingSwordBeamSpawnOffset, Constants.ProjectileOwner.Link, FacingDirection));
        }
    }
}
