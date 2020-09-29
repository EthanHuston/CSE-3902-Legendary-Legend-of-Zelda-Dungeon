using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link.State.Walking
{
    class LinkWalkingUpState : ILinkState
    {
        private Link link;

        public LinkWalkingUpState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingUpLinkSprite();
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
            link.State = new LinkWalkingRightState(link);
        }

        public void MoveUp()
        {
            // Already walking up, do nothing
        }

        public void BeDamaged(int damage)
        {
            link.State = new LinkDamagedWalkingUpState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in health state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStillUpState(link);
        }

        public void SwordAttack()
        {
            link.State = new LinkAttackingUpState(link);
        }
    }
}
