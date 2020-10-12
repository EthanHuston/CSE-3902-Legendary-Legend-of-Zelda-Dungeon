using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.NotMoving;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link
{
    class LinkPlayer : ILinkPlayer
    {
        private ILinkState state;
        public ILinkSprite CurrentSprite { get; set; }
        public bool BlockStateChange { get; set; } = false;
        public Game1 Game;
        private int health;
        private float posX;
        private float posY;
        private Vector2 oldPosition;

        public LinkPlayer(Game1 game) : this(game, new Vector2(ConstantsSprint2.Sprint2LinkSpawnX, ConstantsSprint2.Sprint2LinkSpawnY))
        {
            // handle with other constructor
        }

        public LinkPlayer(Game1 game, Vector2 spawnPosition)
        {
            health = Constants.LinkHealth;
            Game = game;
            state = new LinkStandingStillDownState(this);
            posX = ConstantsSprint2.Sprint2LinkSpawnX;
            posY = ConstantsSprint2.Sprint2LinkSpawnY;
            oldPosition = new Vector2(posX, posY);
        }

        public Vector2 GetPosition()
        {
            return new Vector2(posX, posY);
        }

        public void SetPosition(Vector2 newPosition)
        {
            oldPosition = new Vector2(posX, posY);
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

        public void SpawnItem(ILinkItem item)
        {
            throw new System.NotImplementedException();
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
            return Vector2.Subtract(GetPosition(), oldPosition);
        }

        public void Move(Vector2 distance)
        {
            SetPosition(new Vector2(posX + distance.X, posY + distance.Y));
        }

        public Rectangle GetRectangle()
        {
            return CurrentSprite.GetRectangle();
        }

        public bool SafeToDespawn()
        {
            return false; // Link can only despawn when game ends
        }
    }
}
