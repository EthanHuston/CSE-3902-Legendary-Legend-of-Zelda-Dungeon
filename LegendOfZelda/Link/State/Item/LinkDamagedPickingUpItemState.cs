using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.NotMoving
{
    class LinkDamagedPickingUpItemState : ILinkState
    {
        private Link link;

        public LinkDamagedPickingUpItemState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = SpriteFactory.Instance.CreateIdleLinkDownSprite();
        }

        // TODO: cool stuff
    }
}
