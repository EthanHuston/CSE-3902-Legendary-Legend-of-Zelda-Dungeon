using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkPickingUpSwordState : LinkLazyAbstractState
    {
        private const int spawnOffsetX = 0;
        private const int spawnOffsetY = -12;

        public LinkPickingUpSwordState(LinkPlayer link) : base(link)
        {
        }

        public LinkPickingUpSwordState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpSwordSprite();
            link.SetVelocity(Vector2.Zero);
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
            link.SetVelocity(Vector2.Zero);
        }

        public override void Draw()
        {
            int posX = link.GetPosition().X + spawnOffsetX;
            int posY = link.GetPosition().Y + spawnOffsetY;
            link.CurrentSprite.Draw(link.Game.SpriteBatch, new Point(posX, posY), damaged);
        }

        public override void StopMoving()
        {
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }
    }
}