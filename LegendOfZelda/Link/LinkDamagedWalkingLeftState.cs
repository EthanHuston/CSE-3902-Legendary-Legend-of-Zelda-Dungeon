using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkDamagedWalkingLeftState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;


        public LinkDamagedWalkingLeftState(Link link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public void MoveDown()
        {
            link.State = new LinkDamagedWalkingDownState(link);
        }

        public void MoveLeft()
        {
            // Already walking left, do nothing
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link);
        }

        public void MoveUp()
        {
            link.State = new LinkDamagedWalkingUpState(link);
        }

        public void BeDamaged()
        {
            // Already damaged, do nothing
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingLeftState(link);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) link.State = new LinkWalkingLeftState(link);
        }
    }
}
