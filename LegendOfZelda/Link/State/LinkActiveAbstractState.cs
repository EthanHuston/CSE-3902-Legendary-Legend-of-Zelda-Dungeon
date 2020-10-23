using LegendOfZelda.Interface;
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

        public void BeDamaged(double damage)
        {
            if (!damaged)
            {
                damaged = true;
                link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
            }
        }

        public void BeHealthy(double healAmount)
        {
            damaged = false;
            link.AddHealth(healAmount);
        }

        public virtual void MoveDown()
        {
            link.State = new LinkWalkingDownState(link, damaged, healthyDateTime);
        }

        public virtual void MoveLeft()
        {
            link.State = new LinkWalkingLeftState(link, damaged, healthyDateTime);
        }

        public virtual void MoveRight()
        {
            link.State = new LinkWalkingRightState(link, damaged, healthyDateTime);
        }

        public virtual void MoveUp()
        {
            link.State = new LinkWalkingUpState(link, damaged, healthyDateTime);
        }

        public void PickUpSword()
        {
            link.State = new LinkPickingUpSwordState(link, damaged, healthyDateTime);
        }

        public void PickUpHeartContainer()
        {
            link.State = new LinkPickingUpHeartState(link, damaged, healthyDateTime);
        }

        public void PickUpTriforce()
        {
            link.State = new LinkPickingUpTriforceState(link, damaged, healthyDateTime);
        }

        public void PickUpBow()
        {
            link.State = new LinkPickingUpBowState(link, damaged, healthyDateTime);
        }

        public void PickUpBoomerang()
        {
            link.State = new LinkPickingUpBoomerangState(link, damaged, healthyDateTime);
        }

        public void Drag(ISpawnable owner, int dragTimeMs)
        {
            link.BlockStateChange = false;
            link.State = new LinkBeingDraggedState(link, damaged, healthyDateTime, owner, dragTimeMs);
        }
    }
}
