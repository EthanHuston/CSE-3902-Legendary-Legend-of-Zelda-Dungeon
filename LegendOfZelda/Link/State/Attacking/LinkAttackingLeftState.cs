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
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingLeftLinkSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
            // TODO: we somehow have to switch the state after finishing the animation
        }

        public void MoveDown()
        {
            link.SetState(new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            link.SetState(new LinkWalkingLeftState(link);
        }

        public void MoveRight()
        {
            link.SetState(new LinkWalkingRightState(link);
        }

        public void MoveUp()
        {
            link.SetState(new LinkWalkingUpState(link);
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

        public void SwordAttack()
        {
            // Already attacking, do nothing
        }
    }
}
