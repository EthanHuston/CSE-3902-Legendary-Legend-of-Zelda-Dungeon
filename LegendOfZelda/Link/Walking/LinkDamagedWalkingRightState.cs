using Sprint0.Link.NotMoving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Walking
{
    class LinkDamagedWalkingRightState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;


        public LinkDamagedWalkingRightState(Link link, int damage)
        {
            this.link = link;
            this.link.SubtractHealth(damage);
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedWalkingRightState(Link link, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
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
            // Already walking right, do nothing
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
            link.State = new LinkWalkingRightState(link);
        }

        public void StopMoving()
        {
            link.State = new LinkDamagedStandingStillRightState(link, healthyDateTime);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) BeHealthy();
        }
    }
}
