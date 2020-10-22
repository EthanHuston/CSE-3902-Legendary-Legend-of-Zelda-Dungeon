using LegendOfZelda.Interface;
using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkBeingDraggedState : LinkLazyAbstractState
    {
        private ISpawnable dragger;
        private DateTime dragEndTime;

        public LinkBeingDraggedState(LinkPlayer link, ISpawnable dragger, int dragTimeMs) : base(link)
        {
            InitDragging(dragger, dragTimeMs);
        }

        public LinkBeingDraggedState(LinkPlayer link, bool damaged, DateTime healthyDateTime, ISpawnable dragger, int dragTimeMs) : base(link, damaged, healthyDateTime)
        {
            InitDragging(dragger, dragTimeMs);
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
            link.Velocity = Vector2.Zero;
        }

        private void InitDragging(ISpawnable dragger, int dragTimeMs)
        {
            this.dragger = dragger;
            dragEndTime = DateTime.Now.AddMilliseconds(dragTimeMs);
        }

        public override void Update()
        {
            link.Mover.ForceMoveToPoint(dragger.Position);
            if (DateTime.Now.CompareTo(dragEndTime) > 0) StopMoving();
            link.CurrentSprite.Update();
            link.Mover.Update();
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillDownState(link, damaged, healthyDateTime);
        }
    }
}
