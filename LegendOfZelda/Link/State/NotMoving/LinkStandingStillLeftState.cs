using Sprint0.Link.Walking;

namespace Sprint0.Link.State.NotMoving
{
    class LinkStandingStilLeftState : ILinkState
    {
        private Link link;

        public LinkStandingStilLeftState(Link link)
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
            link.State = new LinkDamagedStandingStillLeftState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }
    }
}
