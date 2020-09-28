using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;

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
            this.link.CurrentSprite = SpriteFactory.Instance.CreateStrikingDownLinkSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
            // TODO: switch state after finishing animation, but how????
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

        public void SwordAttack()
        {
            // Already attacking, do nothing
        }
    }
}
