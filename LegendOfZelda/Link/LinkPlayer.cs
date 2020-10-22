using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Link
{
    class LinkPlayer : IPlayer
    {
        public Game1 Game;
        private int health;
        private Dictionary<Constants.LinkInventory, int> inventory;
        private bool safeToDespawn;
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; }
        public SpawnableMover Mover { get; private set; }
        private ILinkState state;
        public ILinkState State
        {
            get { return state; }
            set { if (!BlockStateChange) state = value; }
        }

        public Point Position 
        { 
            get { return Mover.Position; } 
            set { Mover.Position = value; }
        }

        public Vector2 Velocity
        {
            get { return Mover.Velocity; }
            set { Mover.Velocity = value; }
        }

        public LinkPlayer(Game1 game, Point spawnPosition)
        {
            health = Constants.LinkStartingHealth;
            Game = game;
            state = new LinkStandingStillDownState(this);
            Mover = new SpawnableMover(spawnPosition, Vector2.Zero);
            safeToDespawn = false;
            inventory = new Dictionary<Constants.LinkInventory, int>();
            BlockStateChange = false;
        }

        public void Draw()
        {
            state.Draw();
        }

        public void Update()
        {
            state.Update();
        }

        public void BeHealthy(int healAmount)
        {
            state.BeHealthy(healAmount);
        }

        public void BeDamaged(int damage)
        {
            state.BeDamaged(damage);
        }

        public void SubtractHealth(int damage)
        {
            health -= damage;
        }

        public void AddHealth(int healAmount)
        {
            health += healAmount;
        }

        public void MoveUp()
        {
            state.MoveUp();
        }

        public void MoveDown()
        {
            state.MoveDown();
        }
        public void MoveLeft()
        {
            state.MoveLeft();
        }
        public void MoveRight()
        {
            state.MoveRight();
        }

        public void StopMoving()
        {
            state.StopMoving();
        }

        public void UseSword()
        {
            state.UseSword();
        }

        public void UseBow()
        {
            state.UseBow();
        }

        public void PickUpSword()
        {
            state.PickUpSword();
        }

        public void PickUpHeartContainer()
        {
            state.PickUpHeartContainer();
        }

        public void PickUpBow()
        {
            state.PickUpBow();
        }

        public void PickUpTriforce()
        {
            state.PickUpTriforce();
        }

        public void SpawnItem(IProjectile item)
        {
            Game.GetCurrentRoom().GetSpawnableManager().Spawn(item);
        }

        public void UseBomb()
        {
            state.UseBomb();
        }

        public void UseBoomerang()
        {
            state.UseBoomerang();
        }

        public void PickUpBoomerang()
        {
            state.PickUpBoomerang();
        }

        public void UseSwordBeam()
        {
            state.UseSwordBeam();
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
    }
}
