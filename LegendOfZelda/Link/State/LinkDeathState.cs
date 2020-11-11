using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Link.State
{
    class LinkDeathState : LinkGenericAbstractState
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
            link.BlockStateChange = true;
        }

        protected override void UpdateState()
        {
            if (totalSpins <= 4)
            {
                spinBuffer++;
                switch (spinBuffer)
                {
                    case 20:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkRightSprite();
                        break;
                    case 40:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkUpSprite();
                        break;
                    case 60:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkLeftSprite();
                        break;
                    case 80:
                        link.CurrentSprite = LinkSpriteFactory.Instance.CreateIdleLinkDownSprite();
                        totalSpins++;
                        spinBuffer = 0;
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
