using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    class LinkPickingUpItemState : LinkGenericAbstractState
    {
        private LinkConstants.LinkInventory itemType;

        public LinkPickingUpItemState(LinkPlayer link, LinkConstants.LinkInventory item) : base(link)
        {
        }

        public LinkPickingUpItemState(LinkPlayer link, LinkConstants.LinkInventory item, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            link.Velocity = (Vector2.Zero);
            switch (itemType)
            {
                case LinkConstants.LinkInventory.Arrow:
                case LinkConstants.LinkInventory.Bomb:
                case LinkConstants.LinkInventory.Clock:
                case LinkConstants.LinkInventory.Compass:
                case LinkConstants.LinkInventory.Fairy:
                case LinkConstants.LinkInventory.Heart:
                case LinkConstants.LinkInventory.Key:
                case LinkConstants.LinkInventory.Map:
                    break;

                
                case LinkConstants.LinkInventory.Boomerang:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBoomerangSprite();
                    spawnOffset = LinkConstants.PickingUpBoomerangSpawnOffset;
                    break;
                case LinkConstants.LinkInventory.Bow:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBowSprite();
                    spawnOffset = LinkConstants.PickingUpBowSpawnOffset;
                    break;
                case LinkConstants.LinkInventory.HeartContainer:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpHeartContainerSprite();
                    spawnOffset = LinkConstants.PickingUpHeartContainerSpawnOffset;
                    break;
                case LinkConstants.LinkInventory.Sword:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpSwordSprite();
                    spawnOffset = LinkConstants.PickingUpSwordSpawnOffset;
                    break;
                case LinkConstants.LinkInventory.Triforce:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpTriforceSprite();
                    spawnOffset = LinkConstants.PickingUpTriforceSpawnOffset;
                    break;
            }
        }

        protected override void UpdateState()
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
        }
    }
}
