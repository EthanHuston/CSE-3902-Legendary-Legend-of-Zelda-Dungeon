using Microsoft.Xna.Framework;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingUpState : ILinkState
    {
        private LinkPlayer link;
        private bool damaged;
        private DateTime healthyDateTime;
        int distanceWalked;

        public LinkWalkingUpState(LinkPlayer link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkWalkingUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(LinkPlayer link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingUpLinkSprite();
            distanceWalked = 0;
        }

        public void Update()
        {
            Vector2 position = link.GetPosition();
            if (position.Y < Constants.MaxYPos)
            {
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
                position.Y = position.Y - Constants.LinkWalkStepDistanceInterval;
                distanceWalked += Constants.LinkWalkStepDistanceInterval;
                link.SetPosition(position);

                link.CurrentSprite.Update();
            }

            if (distanceWalked > Constants.LinkWalkDistanceInterval)
            {
                StopMoving();
            }
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
            // Already walking up, do nothing
        }

        public void BeDamaged(int damage)
        {
            if (!damaged)
            {
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
            link.SetState(new LinkStandingStillUpState(link, damaged, healthyDateTime));
        }

        public void UseSword()
        {
            link.SetState(new LinkAttackingUpState(link, damaged, healthyDateTime));
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

        public void UseBow()
        {
            link.SetState(new LinkUsingBowUpState(link, damaged, healthyDateTime));
        }

        public void PickUpBoomerang()
        {
            link.SetState(new LinkPickingUpBoomerangState(link, damaged, healthyDateTime));
        }

        public void UseBomb()
        {
            link.SetState(new LinkUsingBombUpState(link, damaged, healthyDateTime));
        }

        public void UseBoomerang()
        {
            link.SetState(new LinkUsingBoomerangUpState(link, damaged, healthyDateTime));
        }

        public void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamUpState(link, damaged, healthyDateTime));
        }
    }
}
