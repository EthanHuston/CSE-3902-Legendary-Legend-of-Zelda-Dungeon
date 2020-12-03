using LegendOfZelda.GameState.RoomsState;
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
        private Dictionary<LinkConstants.ItemType, int> inventory;
        private readonly Dictionary<LinkConstants.ProjectileType, IProjectile> currentProjectiles;
        private ILinkState state;
        private readonly SoundEffectInstance lowHealth;

        public Game1 Game { get; private set; }
        public Constants.Direction FacingDirection { get; set; }
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; }
        public SpawnableMover Mover { get; private set; }
        public ILinkState State { get => state; set { if (!BlockStateChange) state = value; } }
        public Point Position { get => Mover.Position; set => Mover.Position = value; }
        public Vector2 Velocity { get => Mover.Velocity; set => Mover.Velocity = value; }
        public LinkConstants.ItemType PrimaryItem => LinkConstants.ItemType.Sword;
        public LinkConstants.ItemType SecondaryItem { get; set; }
        public double MaxHealth { get; private set; }
        public double CurrentHealth { get; private set; }
        public bool BeingDragged { get; set; }
        public int PlayerNumber { get; private set; }
        public bool IsDead { get; private set; }
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        public LinkPlayer(Game1 game, Point spawnPosition, int playerNumber)
        {
            PlayerNumber = playerNumber;
            CurrentHealth = LinkConstants.StartingHearts;
            MaxHealth = LinkConstants.StartingHearts;
            lowHealth = SoundFactory.Instance.CreateLowHealthSound();
            Game = game;
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            FacingDirection = Constants.Direction.Up;
            State = new LinkStandingStillState(this);
            SafeToDespawn = false;
            BlockStateChange = false;
            currentProjectiles = new Dictionary<LinkConstants.ProjectileType, IProjectile>();
            SecondaryItem = LinkConstants.ItemType.None;
            BeingDragged = false;
            InitInventoryDict();
        }

        public void Draw()
        {
            State.Draw();
            State.Draw();
        }

        public void Update()
        {
            IsDead = CurrentHealth <= 0;
            if (IsDead && !BlockStateChange) StartDeathAnimation();

            State.Update();
            if (inventory[SecondaryItem] <= 0) SecondaryItem = LinkConstants.ItemType.None;
            if (CurrentHealth <= Constants.HeartValue && CurrentHealth > 0)
            {
                lowHealth.Play();
            }
            if (IsDead || CurrentHealth > Constants.HeartValue)
            {
                lowHealth.Stop();
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
            CurrentHealth -= damage;
            SoundFactory.Instance.CreateLinkHurtSound().Play();
        }

        public void AddHealth(double healAmount)
        {
            CurrentHealth += healAmount;
            if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        }

        public void IncreaseMaxHealth(int amount)
        {
            MaxHealth += amount;
            CurrentHealth += amount;
        }

        public void GiveFullHealth()
        {
            CurrentHealth = MaxHealth;
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
        public void StartDeathAnimation()
        {
            State.StartDeath();
        }

        public void SpawnItem(IProjectile projectile)
        {
            ((RoomGameState)Game.State).SpawnableManager.Spawn(projectile);
            currentProjectiles[projectile.GetProjectileType()] = projectile;
        }

        public void Move(int distance, Vector2 velocity)
        {
            if (IsDead) return;
            Mover.MoveDistance(distance, velocity);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(
                Position.X + LinkConstants.CollisionHelper,
                Position.Y + LinkConstants.CollisionHelper * 2,
                CurrentSprite.GetPositionRectangle().Width - LinkConstants.CollisionHelper * 2,
                CurrentSprite.GetPositionRectangle().Height - LinkConstants.CollisionHelper * 2);
        }

        public void PickupItem(LinkConstants.ItemType itemType)
        {
            inventory[itemType]++;
            state.PickUpItem(itemType);
        }
        
        public void PickupTriforce()
        {
            state.PickUpItem(LinkConstants.ItemType.Triforce);
        }

        private void InitInventoryDict()
        {
            inventory = new Dictionary<LinkConstants.ItemType, int>()
            {
                {LinkConstants.ItemType.Rupee, LinkConstants.RupeeCount },
                {LinkConstants.ItemType.Bomb, LinkConstants.BombCount },
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
                case LinkConstants.ItemType.Bow:
                case LinkConstants.ItemType.Rupee:
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

        public bool CanSpawnProjectile(LinkConstants.ProjectileType projectileType)
        {
            IProjectile currentProjectile;

            if (currentProjectiles.ContainsKey(projectileType))
                currentProjectile = currentProjectiles[projectileType];
            else
            {
                currentProjectile = null;
                currentProjectiles.Add(projectileType, null);
            }

            return currentProjectile == null || currentProjectile.SafeToDespawn;
        }

        public void ConsumeKey()
        {
            inventory[LinkConstants.ItemType.Key]--;
        }

        public void ForceMoveToPoint(Point position)
        {
            Mover.ForceMoveToPoint(position);
        }
    }
}
