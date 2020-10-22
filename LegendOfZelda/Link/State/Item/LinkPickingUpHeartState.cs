using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkPickingUpHeartState : LinkLazyAbstractState
    {
        public const int spawnOffsetX = 0;
        public const int spawnOffsetY = -14;

        public LinkPickingUpHeartState(LinkPlayer link) : base(link)
        {
        }

        public LinkPickingUpHeartState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpHeartSprite();
            link.Velocity = (Vector2.Zero);
        }

        public override void Update()
        {

            if (link.CurrentSprite.FinishedAnimation())
            {
                link.BlockStateChange = false;
                StopMoving();
            }
            else
            {
                link.BlockStateChange = true;
            }
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            link.Mover.Update();
        }

        public override void Draw()
        {
            int posX = link.Position.X + spawnOffsetX;
            int posY = link.Position.Y + spawnOffsetY;
            link.CurrentSprite.Draw(link.Game.SpriteBatch, new Point(posX, posY), damaged);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillDownState(link, damaged, healthyDateTime);
        }
    }
}
