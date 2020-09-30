using Microsoft.Xna.Framework;
using Sprint0.Link.Interface;
using Sprint0.Link.Items;
using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link
{
    class Link : IPlayer
    {
        private ILinkState state;
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; } = false;
        public Game1 Game;
        private ISpawnedItems spawnedItems;
        private int health;
        private float posX;
        private float posY;

        public Link(Game1 game)
        {
            health = Constants.LinkHealth;
            this.Game = game;
            state = new LinkStandingStillDownState(this);
            spawnedItems = new LinkSpawnedItems();
        }

        public Vector2 GetPosition()
        {
            return new Vector2(posX, posY);
        }

        public void SetPosition(Vector2 newPosition)
        {
            posX = newPosition.X;
            posY = newPosition.Y;
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
            Heal(healAmount);
            state.BeHealthy();
        }

        public void TakeDamage(int damage)
        {
            state.BeDamaged(damage);
        }

        public void SubtractHealth(int damage)
        {
            health -= damage;
        }

        public void Heal(int healAmount)
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

        public void SwordAttack()
        {
            state.SwordAttack();
        }

        public void ShootBow()
        {
            state.ShootBow();
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

        public void SpawnItem(ILinkItem item)
        {
            spawnedItems.SpawnNewItem(item);
        }

        public void UseBomb()
        {
            throw new System.NotImplementedException();
        }

        public void UseBoomerang()
        {
            throw new System.NotImplementedException();
        }
    }
}
