using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link
{
    class Link : IPlayer
    {
        public ILinkState State;
        public ISprite CurrentSprite;
        public Game1 Game;
        private int health;

        public Link(Game1 game)
        {
            health = Constants.LinkHealth;
            this.Game = game;
            State = new LinkStandingStillDownState(this);
        }

        public void Draw()
        {
            CurrentSprite.Draw(Game.SpriteBatch);
        }

        public void Update()
        {
            State.Update();
        }

        public void Heal(int healAmount)
        {
            State.BeHealthy();
            health += healAmount;
        }

        public void TakeDamage(int damage)
        {
            State.BeDamaged(damage);
        }

        public void SubtractHealth(int damage)
        {
            health -= damage;
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

        public void SwordAttack()
        {
            State.SwordAttack();
        }
    }
}
