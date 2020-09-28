﻿using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;
using System;

namespace Sprint0.Link.State.Attacking
{
    class LinkDamagedAttackingDownState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedAttackingDownState(Link link)
        {
            InitClass(link);
        }
        public LinkDamagedAttackingDownState(Link link, int damage)
        {
            InitClass(link);
            this.link.SubtractHealth(damage);
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedAttackingDownState(Link link, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateStrikingDownDamagedLinkSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
            // Somehow we have to switch to healthy state after the damage time is up, but sword animation would restart
            // TODO: Could we use a constructor that takes in the current frame?
            // if (DateTime.Compare(DateTime.Now, healthyDateTime) >= 0) BeHealthy();
            // TODO: Somehow we have to switch to an idle state after animation is finished
            // if (finishedWithAnimation) link.State = new LinkDamagedStandingStillUpState(link, healthyDateTime)
        }

        public void MoveDown()
        {
            link.State = new LinkDamagedWalkingDownState(link, healthyDateTime);
        }

        public void MoveLeft()
        {
            link.State = new LinkDamagedWalkingLeftState(link, healthyDateTime);
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link, healthyDateTime);
        }

        public void MoveUp()
        {
            link.State = new LinkDamagedWalkingUpState(link, healthyDateTime);
        }

        public void BeDamaged(int damage)
        {
            // Already damaged, do nothing
        }

        public void BeHealthy()
        {
            // TODO: Implement me, not sure how though because switching to healthy state would restart attack animation
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }

        public void SwordAttack()
        {
            // Already attacking, do nothing
        }
    }
}