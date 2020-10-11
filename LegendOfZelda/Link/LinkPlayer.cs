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

        public LinkPlayer(Game1 game) : this(game, new Vector2(ConstantsSprint2.Sprint2LinkSpawnX, ConstantsSprint2.Sprint2LinkSpawnY))
        {
            // handle with other constructor
        }

        public LinkPlayer(Game1 game, Vector2 spawnPosition)
        {
            health = Constants.LinkHealth;
            this.Game = game;
            state = new LinkStandingStillDownState(this);
            posX = ConstantsSprint2.Sprint2LinkSpawnX;
            posY = ConstantsSprint2.Sprint2LinkSpawnY;
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
            throw new System.NotImplementedException();
        }

        public void Move(Vector2 distance)
        {
            throw new System.NotImplementedException();
        }

        public Rectangle GetRectangle()
        {
            throw new System.NotImplementedException();
        }
    }
}
