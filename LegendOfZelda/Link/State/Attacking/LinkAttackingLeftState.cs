using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.Attacking
{
    class LinkAttackingLeftState : ILinkState
    {
        private Link link;

        public LinkAttackingLeftState(Link link)
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
            // TODO: we somehow have to switch the state after finishing the animation
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
            // TODO: Implement me, not sure how though because switching to damaged state would restart attack animation
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
            link.State = new LinkAttackingRightState(link);
        }

        public void SwordLeft()
        {
            // Already attacking left, do nothing
        }

        public void SwordDown()
        {
            link.State = new LinkAttackingDownState(link);
        }

        public void SwordUp()
        {
            link.State = new LinkAttackingUpState(link);
        }
    }
}
