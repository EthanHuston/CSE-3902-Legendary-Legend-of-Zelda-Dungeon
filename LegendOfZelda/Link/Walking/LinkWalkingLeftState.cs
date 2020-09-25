using Sprint0.Link.NotMoving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
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
            // TODO: draw sprite
        }
        public void Update()
        {
        }
        public void Draw()
        {
            // TODO: Implement me
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
            // link.State = new LinkDamagedWalkingLeftState(link);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStilLeftState(link);
        }
    }
}
