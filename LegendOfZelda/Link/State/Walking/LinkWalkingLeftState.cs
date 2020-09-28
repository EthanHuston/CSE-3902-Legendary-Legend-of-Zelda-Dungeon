using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link.State.Walking
{
    class LinkWalkingLeftState : ILinkState
    {
        private Link link;

        public LinkWalkingLeftState(Link link)
        {
            InitClass(link);
        }
        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateWalkingLeftLinkSprite();
        }
        public void Update()
        {
            link.CurrentSprite.Update();
        }
        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch);
        }
        public void MoveDown()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            // Already walking left, do nothing
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
            link.State = new LinkDamagedWalkingLeftState(link);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStillLeftState(link);
        }

        public void SwordAttack()
        {
            link.State = new LinkAttackingLeftState(link);
        }
    }
}
