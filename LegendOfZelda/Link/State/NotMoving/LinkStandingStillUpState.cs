using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.NotMoving
{
    class LinkStandingStillUpState : ILinkState
    {
        private Link link;

        public LinkStandingStillUpState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateIdleLinkUpSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
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
            link.State = new LinkDamagedStandingStillUpState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }

        public void SwordAttack()
        {
            link.State = new LinkAttackingUpState(link);
        }
    }
}
