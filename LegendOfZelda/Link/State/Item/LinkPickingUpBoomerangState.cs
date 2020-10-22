using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkPickingUpBoomerangState : LinkLazyAbstractState
    {
        private const int spawnOffsetX = 0;
        private const int spawnOffsetY = -9;

        public LinkPickingUpBoomerangState(LinkPlayer link) : base(link)
        {
        }

        public LinkPickingUpBoomerangState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBoomerangSprite();
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
