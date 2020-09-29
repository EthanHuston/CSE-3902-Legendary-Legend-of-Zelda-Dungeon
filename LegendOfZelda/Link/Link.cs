using Microsoft.Xna.Framework;
using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link
{
    class Link : IPlayer
    {
        private ILinkState state;

        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; } = false;
        public Game1 Game;
        private int health;
        private float posX;
        private float posY;

        public Link(Game1 game)
        {
            health = Constants.LinkHealth;
            this.Game = game;
            state = new LinkStandingStillDownState(this);
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

        public void UseItem()
        {
            state.UseItem();
        }

        public void PickUpItem()
        {
            state.PickUpItem();
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
            if(!BlockStateChange) state = newState;
        }
    }
}
