using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;
using System;

namespace Sprint0.Link.State.Walking
{
    class LinkWalkingDownState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;
        private bool damaged;

        public LinkWalkingDownState(Link link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkWalkingDownState(Link link, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            damaged = true;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
            damaged = DateTime.Compare(DateTime.Now, healthyDateTime) < 0;
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
            link.SetState(new LinkWalkingLeftState(link));
        }

        public void MoveRight()
        {
            link.SetState(new LinkWalkingRightState(link));
        }

        public void MoveUp()
        {
            link.SetState(new LinkWalkingUpState(link));
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
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillDownState(link));
        }

        public void SwordAttack()
        {
            link.SetState(new LinkAttackingDownState(link));
        }

        public void PickUpItem()
        {
            link.SetState(new LinkPickingUpItemState(link));
        }

        public void UseItem()
        {
            link.SetState(new LinkUsingItemDownState(link));
        }
    }
}
