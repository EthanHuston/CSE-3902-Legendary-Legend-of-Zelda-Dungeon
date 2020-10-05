using Microsoft.Xna.Framework;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingRightState : ILinkState
    {
        private LinkPlayer link;
        private bool damaged;
        private DateTime healthyDateTime;
        int distanceWalked;

        public LinkWalkingRightState(LinkPlayer link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkWalkingRightState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(LinkPlayer link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingRightLinkSprite();
            distanceWalked = 0;
        }

        public void Update()
        {
            Vector2 position = link.GetPosition();
            if (position.Y < Constants.MaxYPos)
            {
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
                position.X = position.X + Constants.LinkWalkStepDistanceInterval;
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
            // Already moving right, do nothing
        }

        public void MoveUp()
        {
            link.SetState(new LinkWalkingUpState(link, damaged, healthyDateTime));
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
            link.SetState(new LinkStandingStillRightState(link, damaged, healthyDateTime));
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

        public void UseBow()
        {
            link.SetState(new LinkUsingBowRightState(link, damaged, healthyDateTime));
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

        public void UseSwordBeam()
        {
            link.SetState(new LinkUsingSwordBeamRightState(link, damaged, healthyDateTime));
        }
    }
}
