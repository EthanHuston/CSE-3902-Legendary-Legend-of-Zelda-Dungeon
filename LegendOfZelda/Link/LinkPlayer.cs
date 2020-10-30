using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;
using LegendOfZelda.Utility;
using LegendOfZelda.Link.State;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Link
{
    class LinkPlayer : IPlayer
    {
        public Game1 Game;
        private double health;
        private Dictionary<LinkConstants.ItemType, int> inventory;
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
            health = Constants.LinkStartingHealth;
            Game = game;
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            FacingDirection = Constants.Direction.Down;
            State = new LinkStandingStillState(this);
            safeToDespawn = false;
            BlockStateChange = false;
            InitInventory();
        }

        public void Draw()
        {
            State.Draw();
        }

        public void Update()
        {
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
            health -= damage;
        }

        public void AddHealth(double healAmount)
        {
            health += healAmount;
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

        public void PickUpSword()
        {
            State.PickUpItem(LinkConstants.ItemType.Sword);
        }

        public void PickUpHeartContainer()
        {
            State.PickUpItem(LinkConstants.ItemType.HeartContainer);
        }

        public void PickUpBow()
        {
            State.PickUpItem(LinkConstants.ItemType.Bow);
        }

        public void PickUpTriforce()
        {
            State.PickUpItem(LinkConstants.ItemType.Triforce);
        }

        public void PickUpBoomerang()
        {
            State.PickUpItem(LinkConstants.ItemType.Boomerang);
        }

        public void SpawnItem(IProjectile item)
        {
            Game.State.SpawnableManager.Spawn(item);
        }

        public void UseSword()
        {
            State.UseSword();
        }

        public void UseBow()
        {
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.ArrowSpeed);
            SpawnItem(new ArrowFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingArrowSpawnOffset, Constants.ProjectileOwner.Link, velocity));
        }

        public void UseBomb()
        {
            SpawnItem(new BombExplodingProjectile(Game.SpriteBatch, Position, Constants.ProjectileOwner.Link));
        }

        public void UseBoomerang()
        {
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.BoomerangSpeed);
            SpawnItem(new BoomerangFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingBoomerangSpawnOffset, Constants.ProjectileOwner.Link, this, velocity));
        }

        public void UseSwordBeam()
        {
            SpawnItem(new SwordBeamFlyingProjectile(Game.SpriteBatch, Position + LinkConstants.ShootingSwordBeamSpawnOffset, Constants.ProjectileOwner.Link, FacingDirection));
        }

        public void Move(int distance, Vector2 velocity)
        {
            Mover.MoveDistance(distance, velocity);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(
                Position.X + Constants.LinkCollisionHelper,
                Position.Y + Constants.LinkCollisionHelper,
                CurrentSprite.GetPositionRectangle().Width - Constants.LinkCollisionHelper,
                CurrentSprite.GetPositionRectangle().Height - Constants.LinkCollisionHelper);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void PickupMap()
        {
            inventory[LinkConstants.ItemType.Map]++;
        }

        public void PickupBomb()
        {
            inventory[LinkConstants.ItemType.Bomb]++;
        }

        public void PickupKey()
        {
            inventory[LinkConstants.ItemType.Key]++;
        }

        public void PickupCompass()
        {
            inventory[LinkConstants.ItemType.Compass]++;
        }

        public void PickupHeart()
        {
            inventory[LinkConstants.ItemType.Heart]++;
        }

        public void PickupRupee()
        {
            inventory[LinkConstants.ItemType.Arrow]++;
        }

        public void PickupFairy()
        {
            inventory[LinkConstants.ItemType.Fairy]++;
        }

        public void PickupClock()
        {
            inventory[LinkConstants.ItemType.Clock]++;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void MoveOnce(Vector2 distance)
        {
            Mover.MoveOnce(distance);
        }

        private void InitInventory()
        {
            inventory = new Dictionary<LinkConstants.ItemType, int>()
            {
                {LinkConstants.ItemType.Arrow, 0 },
                {LinkConstants.ItemType.Bomb, 0 },
                {LinkConstants.ItemType.Clock, 0 },
                {LinkConstants.ItemType.Compass, 0 },
                {LinkConstants.ItemType.Fairy, 0 },
                {LinkConstants.ItemType.Heart, 0 },
                {LinkConstants.ItemType.Key, 0 },
                {LinkConstants.ItemType.Map, 0 }
            };
        }

        private Vector2 CreateVelocityVector(Constants.Direction direction, int speed) {
            Vector2 velocity = Vector2.Zero;
            switch (direction) {
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
