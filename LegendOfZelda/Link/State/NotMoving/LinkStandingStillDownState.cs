using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.NotMoving
{
    class LinkStandingStillDownState : ILinkState
    {
        private Link link;

        public LinkStandingStillDownState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            // TODO: draw sprite
        }

        public void Update()
        {
        }

        public void Draw()
        {
            // TODO: Implement me
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
            link.State = new LinkDamagedStandingStillDownState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
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
            link.State = new LinkAttackingDownState(link);
        }

        public void SwordUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
