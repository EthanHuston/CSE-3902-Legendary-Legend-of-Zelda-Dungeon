using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.Attacking
{
    class LinkAttackingDownState : ILinkState
    {
        private Link link;
        bool damaged;

        public LinkAttackingDownState(Link link)
        {
            InitState(link);
            damaged = false;
        }

        private void InitState(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingDownLinkSprite();
        }

        public void Update()
        {
            link.CurrentSprite.Update();
        }

        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public void MoveDown()
        {
            link.SetState(new LinkWalkingDownState(link));
        }

        public void MoveLeft()
        {
            link.SetState(new LinkWalkingLeftState(link));
        }

        public void MoveRight()
        {
            link.SetState(new LinkWalkingRightState(link));
        }

        public void MoveUp()
        {
            link.SetState(new LinkWalkingUpState(link));
        }

        public void BeDamaged(int damage)
        {
            link.SetState(new LinkDamagedWalkingDownState(link, damage));
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillDownState(link));
        }

        public void SwordAttack()
        {
            // Already attacking, do nothing
        }

        public void PickUpItem()
        {
            link.SetState(new LinkPickingUpItemState(link));
        }

        public void UseItem()
        {
            link.SetState(new LinkUsingItemDownState(link));
        }
    }
}
