using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    class LinkPickingUpItemState : LinkGenericAbstractState
    {
        private readonly LinkConstants.ItemType itemType;

        public LinkPickingUpItemState(LinkPlayer link, LinkConstants.ItemType itemType) : base(link)
        {
            this.itemType = itemType;
        }

        public LinkPickingUpItemState(LinkPlayer link, LinkConstants.ItemType itemType, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
            this.itemType = itemType;
        }

        protected override void InitClass()
        {
            link.Velocity = (Vector2.Zero);
            switch (itemType)
            {
                case LinkConstants.ItemType.Arrow:
                case LinkConstants.ItemType.Bomb:
                case LinkConstants.ItemType.Clock:
                case LinkConstants.ItemType.Compass:
                case LinkConstants.ItemType.Fairy:
                case LinkConstants.ItemType.Heart:
                case LinkConstants.ItemType.Key:
                case LinkConstants.ItemType.Map:
                    break;

                
                case LinkConstants.ItemType.Boomerang:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBoomerangSprite();
                    spawnOffset = LinkConstants.PickingUpBoomerangSpawnOffset;
                    break;
                case LinkConstants.ItemType.Bow:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBowSprite();
                    spawnOffset = LinkConstants.PickingUpBowSpawnOffset;
                    break;
                case LinkConstants.ItemType.HeartContainer:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpHeartContainerSprite();
                    spawnOffset = LinkConstants.PickingUpHeartContainerSpawnOffset;
                    break;
                case LinkConstants.ItemType.Sword:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpSwordSprite();
                    spawnOffset = LinkConstants.PickingUpSwordSpawnOffset;
                    break;
                case LinkConstants.ItemType.Triforce:
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
