using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Link
{
    class LinkPlayer : IPlayer
    {
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; } = false;
        public Game1 Game;
        private ILinkState state;
        private Point position;
        private Point oldPosition;
        private int health;
        private Dictionary<Constants.LinkInventory, int> inventory;
        private bool safeToDespawn;

        public LinkPlayer(Game1 game, Point spawnPosition)
        {
            health = Constants.LinkHealth;
            Game = game;
            state = new LinkStandingStillDownState(this);
            oldPosition = new Point(spawnPosition.X, spawnPosition.Y);
            position = new Point(spawnPosition.X, spawnPosition.Y);
            safeToDespawn = false;
            inventory = new Dictionary<Constants.LinkInventory, int>();
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public void SetPosition(Point newPosition)
        {
            oldPosition = new Point(position.X, position.Y);
            position = new Point(newPosition.X, newPosition.Y);
        }

        public ILinkState GetState()
        {
            return state;
        }

        public void SetState(ILinkState newState)
        {
            if (!BlockStateChange) state = newState;
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

        public Vector2 GetVelocity()
        {
            return Vector2.Subtract(GetPosition().ToVector2(), oldPosition.ToVector2());
        }

        public void Move(Vector2 distance)
        {
            SetPosition(new Point((int)(position.X + distance.X), (int)(position.Y + distance.Y)));
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
    }
}
