using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Projectile;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Link
{
    class LinkPlayer : IPlayer
    {
        public Game1 Game;
        private double health;
        private Dictionary<Constants.LinkInventory, int> inventory;
        private bool safeToDespawn;

        public ILinkSprite CurrentSprite { get; set; }

        public bool BlockStateChange { get; set; }
        
        public SpawnableMover Mover { get; private set; }
        
        private ILinkState state;
        public ILinkState State { get => state; set { if (!BlockStateChange) state = value; } }

        public Point Position { get => Mover.Position; set => Mover.Position = value; }

        public Vector2 Velocity { get => Mover.Velocity; set => Mover.Velocity = value; }

        public LinkPlayer(Game1 game, Point spawnPosition)
        {
            health = Constants.LinkStartingHealth;
            Game = game;
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            State = new LinkStandingStillDownState(this);
            safeToDespawn = false;
            inventory = new Dictionary<Constants.LinkInventory, int>();
            BlockStateChange = false;
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
            State.MoveUp();
        }

        public void MoveDown()
        {
            State.MoveDown();
        }
        public void MoveLeft()
        {
            State.MoveLeft();
        }
        public void MoveRight()
        {
            State.MoveRight();
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
            State.UseBow();
        }

        public void PickUpSword()
        {
            State.PickUpSword();
        }

        public void PickUpHeartContainer()
        {
            State.PickUpHeartContainer();
        }

        public void PickUpBow()
        {
            State.PickUpBow();
        }

        public void PickUpTriforce()
        {
            State.PickUpTriforce();
        }

        public void SpawnItem(IProjectile item)
        {
            Game.State.SpawnableManager.Spawn(item);
        }

        public void UseBomb()
        {
            State.UseBomb();
        }

        public void UseBoomerang()
        {
            State.UseBoomerang();
        }

        public void PickUpBoomerang()
        {
            State.PickUpBoomerang();
        }

        public void UseSwordBeam()
        {
            State.UseSwordBeam();
        }

        public void Move(int distance, Vector2 velocity)
        {
            Mover.MoveDistance(distance, velocity);
        }

        public Rectangle GetRectangle()
        {
            return CurrentSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void PickupMap()
        {
            inventory[Constants.LinkInventory.Map]++;
        }

        public void PickupBomb()
        {
            inventory[Constants.LinkInventory.Bomb]++;
        }

        public void PickupKey()
        {
            inventory[Constants.LinkInventory.Key]++;
        }

        public void PickupCompass()
        {
            inventory[Constants.LinkInventory.Compass]++;
        }

        public void PickupHeart()
        {
            inventory[Constants.LinkInventory.Heart]++;
        }

        public void PickupRupee()
        {
            inventory[Constants.LinkInventory.Arrow]++;
        }

        public void PickupFairy()
        {
            inventory[Constants.LinkInventory.Fairy]++;
        }

        public void PickupClock()
        {
            inventory[Constants.LinkInventory.Clock]++;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void MoveOnce(Vector2 distance)
        {
            Mover.MoveOnce(distance);
        }

        public void Drag(ISpawnable dragger, int dragTimeMs)
        {
            State.Drag(dragger, dragTimeMs);
        }
    }
}
