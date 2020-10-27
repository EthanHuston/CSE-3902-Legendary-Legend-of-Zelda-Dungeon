using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.Walking;
using System;

namespace LegendOfZelda.Link.State
{
    internal abstract class LinkActiveAbstractState : ILinkState
    {
        protected LinkPlayer link;
        protected bool damaged;
        protected bool blockNewDirection;
        protected bool walkingToggle;
        protected DateTime healthyDateTime;
        protected DateTime lastDraggedTime;

        public LinkActiveAbstractState(LinkPlayer link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now;
            damaged = false;
            blockNewDirection = false;
            walkingToggle = false;
            InitClass();
        }

        public LinkActiveAbstractState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            blockNewDirection = false;
            walkingToggle = false;
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
            if (!blockNewDirection) link.State = new LinkWalkingDownState(link, damaged, healthyDateTime, !walkingToggle);
        }

        public virtual void MoveLeft()
        {
            if (!blockNewDirection) link.State = new LinkWalkingLeftState(link, damaged, healthyDateTime, !walkingToggle);
        }

        public virtual void MoveRight()
        {
            if (!blockNewDirection) link.State = new LinkWalkingRightState(link, damaged, healthyDateTime, !walkingToggle);
        }

        public virtual void MoveUp()
        {
            if (!blockNewDirection) link.State = new LinkWalkingUpState(link, damaged, healthyDateTime, !walkingToggle);
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
            if (DateTime.Now.CompareTo(lastDraggedTime.AddMilliseconds(Constants.DragAgainDelayMs)) < 0) return;
            link.BlockStateChange = false;
            lastDraggedTime = DateTime.Now;
            link.State = new LinkBeingDraggedState(link, damaged, healthyDateTime, owner, dragTimeMs);
        }
    }
}
