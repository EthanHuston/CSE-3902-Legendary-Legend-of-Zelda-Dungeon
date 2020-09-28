using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.NotMoving
{
    class LinkDamagedUsingItemState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedStandingStillDownState(Link link)
        {
            InitClass(link);
        }
        public LinkDamagedStandingStillDownState(Link link, int damage)
        {
            InitClass(link);
            this.link.SubtractHealth(damage);
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedStandingStillDownState(Link link, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateIdleDamagedLinkDownSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
            if (DateTime.Compare(DateTime.Now, healthyDateTime) >= 0) BeHealthy();
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
            link.State = new LinkStandingStillDownState(link);
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }

        public void SwordAttack()
        {
            link.State = new LinkDamagedAttackingDownState(link, healthyDateTime);
        }

        public void PickUpItem()
        {
            link.State = new LinkDamagedPickingUpItemState(link, healthyDateTime);
        }
    }
}
}
