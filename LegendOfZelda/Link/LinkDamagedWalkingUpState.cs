using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkDamagedWalkingUpState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedWalkingUpState(Link link)
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
            link.State = new LinkDamagedWalkingLeftState(link);
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link);
        }

        public void MoveUp()
        {
            // Already walking up, do nothing
        }

        public void BeDamaged()
        {
            // Already damaged, do nothing           
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) link.State = new LinkWalkingUpState(link);
        }
    }
}
