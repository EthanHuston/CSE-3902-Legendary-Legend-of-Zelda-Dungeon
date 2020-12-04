using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal class LinkDeathState : LinkGenericAbstractState
    {
        private int spinBuffer = 0;
        private int totalSpins = 0;
        public LinkDeathState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
            //Handled by Parent
        }
        protected override void InitClass()
        {
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
            link.Velocity = Vector2.Zero;
        }

        public override void Draw()
        {
            int posX = link.Position.X + spawnOffset.X;
            int posY = link.Position.Y + spawnOffset.Y;
            link.CurrentSprite.Draw(link.Game.SpriteBatch, new Point(posX, posY), false, Constants.DrawLayer.LinkDead);
        }

        protected override void UpdateState()
        {
            if (totalSpins < 3)
            {
                spinBuffer++;
                switch (spinBuffer)
                {
                    case 10:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkRightSprite();
                        break;
                    case 20:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkUpSprite();
                        break;
                    case 30:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkLeftSprite();
                        break;
                    case 40:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
                        totalSpins++;
                        spinBuffer = 0;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                link.SafeToDespawn = true;
            }
        }
    }
}
