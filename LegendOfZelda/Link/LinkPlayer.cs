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
        public int GetHealth { get; set; }

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
            if (inventory[SecondaryItem] <= 0) SecondaryItem = LinkConstants.ItemType.None;
            if(currentHealth <= 1.0)
            {
                SoundEffectInstance lowHealth = SoundFactory.Instance.CreateLowHealthSound();
                lowHealth.IsLooped = true;
                lowHealth.Play();
            }
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
            SoundFactory.Instance.CreateLinkHurtSound().Play();
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
                {LinkConstants.ItemType.Sword, LinkConstants.SwordCount },
                {LinkConstants.ItemType.None, 0 }
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
            SoundFactory.Instance.CreateSwordSlashSound().Play();
        }

        private void UseBow()
        {
            if (!CanSpawnProjectile(LinkConstants.ProjectileType.Arrow) || inventory[LinkConstants.ItemType.Bow] <= 0 || inventory[LinkConstants.ItemType.Rupee] <= 0) return;
            inventory[LinkConstants.ItemType.Rupee]--;
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.ArrowSpeed);
            SpawnItem(new ArrowFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingArrowSpawnOffset, Constants.ProjectileOwner.Link, velocity));
            SoundFactory.Instance.CreateArrowBoomerangSound().Play();
        }

        private void UseBomb()
        {
            if (!CanSpawnProjectile(LinkConstants.ProjectileType.Bomb) || inventory[LinkConstants.ItemType.Bomb] <= 0) return;
            inventory[LinkConstants.ItemType.Bomb]--;
            SpawnItem(new BombExplodingProjectile(Game.SpriteBatch, Position, Constants.ProjectileOwner.Link));
            SoundFactory.Instance.CreateBombDropSound().Play();
        }

        private void UseBoomerang()
        {
            if (!CanSpawnProjectile(LinkConstants.ProjectileType.Boomerang) || inventory[LinkConstants.ItemType.Boomerang] <= 0) return;
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.BoomerangSpeed);
            SpawnItem(new BoomerangFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingBoomerangSpawnOffset, Constants.ProjectileOwner.Link, this, velocity));
            SoundFactory.Instance.CreateArrowBoomerangSound().Play();
        }

        private void UseSwordBeam()
        {
            if (!CanSpawnProjectile(LinkConstants.ProjectileType.SwordBeam) || inventory[LinkConstants.ItemType.Sword] <= 0) return;
            SpawnItem(new SwordBeamFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingSwordBeamSpawnOffset, Constants.ProjectileOwner.Link, FacingDirection));
            SoundFactory.Instance.CreateSwordCombinedSound().Play();
        }

        private bool CanSpawnProjectile(LinkConstants.ProjectileType projectileType)
        {
            IProjectile currentProjectile;

            if (currentProjectiles.ContainsKey(projectileType))
                currentProjectile = currentProjectiles[projectileType];
            else
            {
                currentProjectile = null;
                currentProjectiles.Add(projectileType, null);
            }

            return currentProjectile == null || currentProjectile.SafeToDespawn();
        }
    }
}
