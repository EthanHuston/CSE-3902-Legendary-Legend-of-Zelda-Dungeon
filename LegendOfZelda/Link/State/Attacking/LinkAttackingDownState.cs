using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;
using System;

namespace Sprint0.Link.State.Attacking
{
    class LinkAttackingDownState : ILinkState
    {
        private Link link;

        public LinkAttackingDownState(Link link)
        {
            InitState(link);
        }

        private void InitState(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateIdleDamagedLinkDownSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
            link.State = new LinkStandingStillDownState(link); // switch state after finishing animation
        }

        public void MoveDown()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            link.State = new LinkWalkingLeftState(link);
        }

        public void MoveRight()
        {
            link.State = new LinkWalkingRightState(link);
        }

        public void MoveUp()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void BeDamaged(int damage)
        {
            link.State = new LinkDamagedWalkingDownState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStillDownState(link);
        }
        public void SwordRight()
        {
            link.State = new LinkAttackingUpState(link);
        }

        public void SwordLeft()
        {
            link.State = new LinkAttackingLeftState(link);
        }

        public void SwordDown()
        {
            // Already attacking down, do nothing
        }

        public void SwordUp()
        {
            link.State = new LinkAttackingUpState(link);
        }
    }
}
