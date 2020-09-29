using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.Walking;

namespace Sprint0.Link.State.NotMoving
{
    class LinkPickingUpItemState : ILinkState
    {
        private Link link;

        public LinkPickingUpItemState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
        }

        // TODO: cool stuff
    }
}
