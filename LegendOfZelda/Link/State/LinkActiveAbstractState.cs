using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.Walking;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    abstract class LinkActiveAbstractState : ILinkState
    {
        protected LinkPlayer link;
        protected bool damaged;
        protected DateTime healthyDateTime;

        public LinkActiveAbstractState(LinkPlayer link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now;
            damaged = false;
            InitClass();
        }

        public LinkActiveAbstractState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
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

        public abstract void UseBoomerang();

        public abstract void UseBow();

        public abstract void UseSword();

        public abstract void UseSwordBeam();

        public abstract void UseBomb();

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

        public void MoveDown()
        {
            link.SetState(new LinkWalkingDownState(link, damaged, healthyDateTime));
        }

        public void MoveLeft()
        {
            link.SetState(new LinkWalkingLeftState(link, damaged, healthyDateTime));
        }

        public void MoveRight()
        {
            link.SetState(new LinkWalkingRightState(link, damaged, healthyDateTime));
        }

        public void MoveUp()
        {
            link.SetState(new LinkWalkingUpState(link, damaged, healthyDateTime));
        }

        public void PickUpSword()
        {
            link.SetState(new LinkPickingUpSwordState(link, damaged, healthyDateTime));
        }

        public void PickUpHeartContainer()
        {
            link.SetState(new LinkPickingUpHeartState(link, damaged, healthyDateTime));
        }

        public void PickUpTriforce()
        {
            link.SetState(new LinkPickingUpTriforceState(link, damaged, healthyDateTime));
        }

        public void PickUpBow()
        {
            link.SetState(new LinkPickingUpBowState(link, damaged, healthyDateTime));
        }

        public void PickUpBoomerang()
        {
            link.SetState(new LinkPickingUpBoomerangState(link, damaged, healthyDateTime));
        }
    }
}
