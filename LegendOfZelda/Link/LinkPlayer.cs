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
        private Dictionary<LinkConstants.LinkInventory, int> inventory;
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

        public void UseSword()
        {
            State.UseSword();
        }

        public void UseBow()
        {
        }

        public void PickUpSword()
        {
            State.PickUpItem(LinkConstants.LinkInventory.Sword);
        }

        public void PickUpHeartContainer()
        {
            State.PickUpItem(LinkConstants.LinkInventory.HeartContainer);
        }

        public void PickUpBow()
        {
            State.PickUpItem(LinkConstants.LinkInventory.Bow);
        }

        public void PickUpTriforce()
        {
            State.PickUpItem(LinkConstants.LinkInventory.Triforce);
        }

        public void PickUpBoomerang()
        {
            State.PickUpItem(LinkConstants.LinkInventory.Boomerang);
        }

        public void SpawnItem(IProjectile item)
        {
            Game.State.SpawnableManager.Spawn(item);
        }

        public void UseBomb()
        {
            SpawnItem(new BombExplodingProjectile(Game.SpriteBatch, Position, Constants.ProjectileOwner.Link));
        }

        public void UseBoomerang()
        {
            Vector2 velocity = CreateVelocityVector(FacingDirection, LinkConstants.BoomerangSpeed);
            SpawnItem(new BoomerangFlyingProjectile(Game.SpriteBatch, Position, Constants.ProjectileOwner.Link, this, velocity));
        }

        public void UseSwordBeam()
        {
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
            inventory[LinkConstants.LinkInventory.Map]++;
        }

        public void PickupBomb()
        {
            inventory[LinkConstants.LinkInventory.Bomb]++;
        }

        public void PickupKey()
        {
            inventory[LinkConstants.LinkInventory.Key]++;
        }

        public void PickupCompass()
        {
            inventory[LinkConstants.LinkInventory.Compass]++;
        }

        public void PickupHeart()
        {
            inventory[LinkConstants.LinkInventory.Heart]++;
        }

        public void PickupRupee()
        {
            inventory[LinkConstants.LinkInventory.Arrow]++;
        }

        public void PickupFairy()
        {
            inventory[LinkConstants.LinkInventory.Fairy]++;
        }

        public void PickupClock()
        {
            inventory[LinkConstants.LinkInventory.Clock]++;
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
            inventory = new Dictionary<LinkConstants.LinkInventory, int>()
            {
                {LinkConstants.LinkInventory.Arrow, 0 },
                {LinkConstants.LinkInventory.Bomb, 0 },
                {LinkConstants.LinkInventory.Clock, 0 },
                {LinkConstants.LinkInventory.Compass, 0 },
                {LinkConstants.LinkInventory.Fairy, 0 },
                {LinkConstants.LinkInventory.Heart, 0 },
                {LinkConstants.LinkInventory.Key, 0 },
                {LinkConstants.LinkInventory.Map, 0 }
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
                    velocity.Y = -1 * speed;
                    return velocity;
                case Constants.Direction.Right:
                    velocity.Y = speed;
                    return velocity;
            }

            return velocity;
        }
    }
}
