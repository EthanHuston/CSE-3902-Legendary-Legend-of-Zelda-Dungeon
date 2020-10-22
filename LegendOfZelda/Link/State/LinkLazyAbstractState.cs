using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    abstract class LinkLazyAbstractState : ILinkState
    {
        protected LinkPlayer link;
        protected bool damaged;
        protected DateTime healthyDateTime;

        public LinkLazyAbstractState(LinkPlayer link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now;
            damaged = false;
            InitClass();
        }

        public LinkLazyAbstractState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            InitClass();
        }

        protected abstract void InitClass();

        public abstract void Draw();

        public abstract void Update();

        public abstract void StopMoving();

        public void BeDamaged(int damage)
        {
            if (!damaged)
            {
                damaged = true;
                link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
            }
        }

        public void BeHealthy(int healAmount)
        {
            damaged = false;
            link.AddHealth(healAmount);
        }

        public virtual void MoveDown()
        {
            // Does nothing by default since most states do this
        }

        public virtual void MoveLeft()
        {
            // Does nothing by default since most states do this
        }

        public virtual void MoveRight()
        {
            // Does nothing by default since most states do this
        }

        public virtual void MoveUp()
        {
            // Does nothing by default since most states do this
        }

        public virtual void PickUpBoomerang()
        {
            // Does nothing by default since most states do this
        }

        public virtual void PickUpBow()
        {
            // Does nothing by default since most states do this
        }

        public virtual void PickUpHeartContainer()
        {
            // Does nothing by default since most states do this
        }

        public virtual void PickUpSword()
        {
            // Does nothing by default since most states do this
        }

        public virtual void PickUpTriforce()
        {
            // Does nothing by default since most states do this
        }

        public virtual void UseBomb()
        {
            // Does nothing by default since most states do this
        }

        public virtual void UseBoomerang()
        {
            // Does nothing by default since most states do this
        }

        public virtual void UseBow()
        {
            // Does nothing by default since most states do this
        }

        public virtual void UseSword()
        {
            // Does nothing by default since most states do this
        }

        public virtual void UseSwordBeam()
        {
            // Does nothing by default since most states do this
        }
    }
}
