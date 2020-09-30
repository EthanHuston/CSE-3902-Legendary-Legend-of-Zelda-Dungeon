﻿using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;
using System;

namespace Sprint0.Link.State.Item
{
    class LinkPickingUpBowState : ILinkState
    {
        private Link link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkPickingUpBowState(Link link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkPickingUpBowState(Link link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBowSprite();
            link.BlockStateChange = true;
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            if (link.CurrentSprite.finishedAnimation())
            {
                link.BlockStateChange = false;
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
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillUpState(link, damaged, healthyDateTime));
        }

        public void SwordAttack()
        {
            link.SetState(new LinkAttackingDownState(link, damaged, healthyDateTime));
        }

        public void PickUpItem()
        {
            // Already picking up item, do nothing
        }

        public void UseItem()
        {
            link.SetState(new LinkUsingItemUpState(link, damaged, healthyDateTime));
        }

        public void PickUpSword()
        {
            link.SetState(new LinkPickingUpSwordState(link, damaged, healthyDateTime));
        }

        public void PickUpHeart()
        {
            link.SetState(new LinkPickingUpHeartState(link, damaged, healthyDateTime));
        }

        public void PickUpTriforce()
        {
            link.SetState(new LinkPickingUpTriforceState(link, damaged, healthyDateTime));
        }

        public void PickUpBow()
        {
            // Already picking up bow, do nothing
        }
    }
}