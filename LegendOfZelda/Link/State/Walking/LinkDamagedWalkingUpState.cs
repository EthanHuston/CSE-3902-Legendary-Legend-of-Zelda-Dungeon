using Sprint0.Link.State.NotMoving;
using System;

namespace Sprint0.Link.State.Walking
{
    class LinkDamagedWalkingUpState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedWalkingUpState(Link link, int damage)
        {
            InitClass(link);
            this.link.SubtractHealth(damage);
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedWalkingUpState(Link link, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateWalkingUpDamagedLinkSprite();
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) >= 0) BeHealthy();
        }

        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch);
        }

        public void MoveDown()
        {
            link.State = new LinkDamagedWalkingDownState(link, healthyDateTime);
        }

        public void MoveLeft()
        {
            link.State = new LinkDamagedWalkingLeftState(link, healthyDateTime);
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link, healthyDateTime);
        }

        public void MoveUp()
        {
            // Already walking up, do nothing
        }

        public void BeDamaged(int damage)
        {
            // Already damaged, do nothing           
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void StopMoving()
        {
            link.State = new LinkDamagedStandingStillUpState(link, healthyDateTime);
        }
    }
}
