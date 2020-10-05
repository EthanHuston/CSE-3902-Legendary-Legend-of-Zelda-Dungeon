using Microsoft.Xna.Framework;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingDownState : ILinkState
    {
        private LinkPlayer link;
        private bool damaged;
        private DateTime healthyDateTime;
        private int distanceWalked;

        public LinkWalkingDownState(LinkPlayer link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkWalkingDownState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(LinkPlayer link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
        }

        public void Update()
        {
            Vector2 position = link.GetPosition();
            if (position.Y < Constants.MaxYPos)
            {
                damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
                position.Y = position.Y + Constants.LinkWalkStepDistanceInterval;
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
            // Already walking down, do nothing
        }

        public void MoveLeft()
        {
            // Cannot interupt, do nothing
        }

        public void MoveRight()
        {
            // Cannot interupt, do nothing
        }

        public void MoveUp()
        {
            // Cannot interupt, do nothing
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
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }

        public void UseSword()
        {
            // Cannot interupt, do nothing
        }

        public void PickUpSword()
        {
            // Cannot interupt, do nothing
        }

        public void PickUpHeartContainer()
        {
            // Cannot interupt, do nothing
        }

        public void PickUpTriforce()
        {
            // Cannot interupt, do nothing
        }

        public void PickUpBow()
        {
            // Cannot interupt, do nothing
        }

        public void UseBow()
        {
            // Cannot interupt, do nothing
        }

        public void PickUpBoomerang()
        {
            // Cannot interupt, do nothing
        }

        public void UseBomb()
        {
            // Cannot interupt, do nothing
        }

        public void UseBoomerang()
        {
            // Cannot interupt, do nothing
        }

        public void UseSwordBeam()
        {
            // Cannot interupt, do nothing
        }
    }
}
