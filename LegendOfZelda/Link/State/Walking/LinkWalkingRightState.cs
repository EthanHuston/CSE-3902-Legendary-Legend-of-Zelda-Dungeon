using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link.State.Walking
{
    class LinkWalkingRightState : ILinkState
    {
        private Link link;

        public LinkWalkingRightState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingRightLinkSprite();
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
            link.State = new LinkWalkingLeftState(link);
        }

        public void MoveRight()
        {
            // Already walking right, do nothing
        }

        public void MoveUp()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void BeDamaged(int damage)
        {
            link.State = new LinkDamagedWalkingRightState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStillRightState(link);
        }

        public void SwordAttack()
        {
            link.State = new LinkAttackingRightState(link);
        }
    }
}
