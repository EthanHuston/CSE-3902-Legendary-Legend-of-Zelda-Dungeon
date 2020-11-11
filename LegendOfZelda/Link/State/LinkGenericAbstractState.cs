using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal abstract class LinkGenericAbstractState : ILinkState
    {
        protected LinkPlayer link;
        protected bool damaged;
        protected DateTime healthyDateTime;
        protected Point spawnOffset;

        protected LinkGenericAbstractState() { }

        public LinkGenericAbstractState(LinkPlayer link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now;
            damaged = false;
            spawnOffset = Point.Zero;
            InitClass();
        }

        public LinkGenericAbstractState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            spawnOffset = Point.Zero;
            InitClass();
        }

        protected abstract void InitClass();

        public virtual void Draw()
        {
            int posX = link.Position.X + spawnOffset.X;
            int posY = link.Position.Y + spawnOffset.Y;
            if (link.SafeToDespawn())
            {
                link.CurrentSprite.Draw(link.Game.SpriteBatch, new Point(posX, posY), !damaged, Constants.DrawLayer.LinkDead);
            }
            else
            {
                link.CurrentSprite.Draw(link.Game.SpriteBatch, new Point(posX, posY), damaged, Constants.DrawLayer.Player);
            }
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.Mover.Update();
            link.CurrentSprite.Update();
            UpdateState();
        }

        protected abstract void UpdateState();

        public void StopMoving()
        {
            link.State = new LinkStandingStillState(link, damaged, healthyDateTime);
        }

        public virtual void UseSword()
        {
            link.State = new LinkAttackingState(link, damaged, healthyDateTime);
        }

        public void BeDamaged(double damage)
        {
            if (!damaged)
            {
                damaged = true;
                link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(LinkConstants.DamageEffectTimeMs);
            }
        }

        public void BeHealthy(double healAmount)
        {
            damaged = false;
            link.AddHealth(healAmount);
        }

        public virtual void Move(Constants.Direction direction)
        {
            link.State = new LinkWalkingState(link, direction, damaged, healthyDateTime);
        }

        public void PickUpItem(LinkConstants.ItemType itemType)
        {
            link.State = new LinkPickingUpItemState(link, itemType, damaged, healthyDateTime);
        }

        public void StartDeath()
        {
            link.State = new LinkDeathState(link, damaged, healthyDateTime);
        }
    }
}
