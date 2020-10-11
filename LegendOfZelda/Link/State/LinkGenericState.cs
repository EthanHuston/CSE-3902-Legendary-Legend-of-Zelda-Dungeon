using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State
{
    abstract class LinkGenericState : ILinkState
    {
        protected LinkPlayer link;
        protected bool damaged;
        protected DateTime healthyDateTime;

        public LinkGenericState(LinkPlayer link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now;
            damaged = false;
            InitClass();
        }

        public LinkGenericState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            InitClass();
        }

        protected abstract void InitClass();

        public abstract void Draw();

        public abstract void Update();

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

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }

        public void MoveDown()
        {
            // Does nothing by default since most states do this
        }

        public void MoveLeft()
        {
            // Does nothing by default since most states do this
        }

        public void MoveRight()
        {
            // Does nothing by default since most states do this
        }

        public void MoveUp()
        {
            // Does nothing by default since most states do this
        }

        public void PickUpBoomerang()
        {
            // Does nothing by default since most states do this
        }

        public void PickUpBow()
        {
            // Does nothing by default since most states do this
        }

        public void PickUpHeartContainer()
        {
            // Does nothing by default since most states do this
        }

        public void PickUpSword()
        {
            // Does nothing by default since most states do this
        }

        public void PickUpTriforce()
        {
            // Does nothing by default since most states do this
        }

        public void UseBomb()
        {
            // Does nothing by default since most states do this
        }

        public void UseBoomerang()
        {
            // Does nothing by default since most states do this
        }

        public void UseBow()
        {
            // Does nothing by default since most states do this
        }

        public void UseSword()
        {
            // Does nothing by default since most states do this
        }

        public void UseSwordBeam()
        {
            // Does nothing by default since most states do this
        }
    }
}
