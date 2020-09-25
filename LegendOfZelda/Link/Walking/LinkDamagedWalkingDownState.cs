using Sprint0.Link.NotMoving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Walking
{
    class LinkDamagedWalkingDownState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedWalkingDownState(Link link, int damage)
        {
            InitClass(link);
            this.link.SubtractHealth(damage);
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedWalkingDownState(Link link, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            // TODO: draw sprite
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) >= 0) BeHealthy();
        }

        public void Draw()
        {
            // TODO: Implement me
        }

        public void MoveDown()
        {
            // Already walking down, do nothing
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
            link.State = new LinkDamagedWalkingUpState(link, healthyDateTime);
        }

        public void BeDamaged(int damage)
        {
            // Already damaged, do nothing
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void StopMoving()
        {
            link.State = new LinkDamagedStandingStillDownState(link, healthyDateTime);
        }
    }
}
