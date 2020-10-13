using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.Walking;
using System;

namespace LegendOfZelda.Link.State.NotMoving
{
    class LinkStandingStillRightState : ILinkState
    {
        private LinkPlayer link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkStandingStillRightState(LinkPlayer link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkStandingStillRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(LinkPlayer link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkRightSprite();
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
        }

        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
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

        public void BeDamaged(int damage)
        {
            if (!damaged)
            {
                damaged = true;
                this.link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
            }
        }

        public void BeHealthy()
        {
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }

        public void UseSword()
        {
            link.SetState(new LinkAttackingRightState(link, damaged, healthyDateTime));
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

        public void UseBomb()
        {
            link.SetState(new LinkUsingBombRightState(link, damaged, healthyDateTime));
        }

        public void UseBoomerang()
        {
            link.SetState(new LinkUsingBoomerangRightState(link, damaged, healthyDateTime));
        }

        public void UseBow()
        {
            link.SetState(new LinkUsingBowRightState(link, damaged, healthyDateTime));
        }

        public void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamRightState(link, damaged, healthyDateTime));
        }
    }
}
