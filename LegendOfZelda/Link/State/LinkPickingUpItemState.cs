using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal class LinkPickingUpItemState : LinkGenericAbstractState
    {
        private readonly LinkConstants.ItemType itemType;

        public LinkPickingUpItemState(LinkPlayer link, LinkConstants.ItemType itemType, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            spawnOffset = Point.Zero;
            this.itemType = itemType;
            InitClass();
        }

        protected override void InitClass()
        {
            link.Velocity = (Vector2.Zero);
            switch (itemType)
            {
                case LinkConstants.ItemType.Boomerang:
                    if (link.GetQuantityInInventory(LinkConstants.ItemType.Boomerang) > 1)
                    {
                        StopMovingLocal();
                        break;
                    }
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBoomerangSprite();
                    spawnOffset = LinkConstants.PickingUpBoomerangSpawnOffset;
                    SoundFactory.Instance.CreateGetItemSound().Play();
                    break;
                case LinkConstants.ItemType.Bow:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBowSprite();
                    spawnOffset = LinkConstants.PickingUpBowSpawnOffset;
                    SoundFactory.Instance.CreateFanfareSound().Play();
                    break;
                case LinkConstants.ItemType.Sword:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpSwordSprite();
                    spawnOffset = LinkConstants.PickingUpSwordSpawnOffset;
                    SoundFactory.Instance.CreateFanfareSound().Play();
                    break;
                case LinkConstants.ItemType.Triforce:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpTriforceSprite();
                    spawnOffset = LinkConstants.PickingUpTriforceSpawnOffset;
                    break;
                case LinkConstants.ItemType.Clock:
                    SoundFactory.Instance.CreateGetItemSound().Play();
                    // For Sprint 5: SoundFactory.Instance.CreateClockPickUpSound().Play();
                    StopMovingLocal();
                    break;
                case LinkConstants.ItemType.Compass:
                    SoundFactory.Instance.CreateGetItemSound().Play();
                    StopMovingLocal();
                    break;
                case LinkConstants.ItemType.Fairy:
                    SoundFactory.Instance.CreateGetItemSound().Play();
                    StopMovingLocal();
                    break;
                case LinkConstants.ItemType.Key:
                    SoundFactory.Instance.CreateGetHeartSound().Play();
                    StopMovingLocal();
                    break;
                case LinkConstants.ItemType.Map:
                    SoundFactory.Instance.CreateGetItemSound().Play();
                    StopMovingLocal();
                    break;
                case LinkConstants.ItemType.Rupee:
                    SoundFactory.Instance.CreateGetRupeeSound().Play();
                    StopMovingLocal();
                    break;
                default:
                    break;
            }
        }

        protected override void UpdateState()
        {
            if (link.CurrentSprite.FinishedAnimation())
            {

                link.BlockStateChange = false;
                StopMovingLocal();
            }
            else
            {
                link.BlockStateChange = true;
            }
        }

        public override void Move(Constants.Direction direction)
        {
            // do not allow Link to move from this state
        }

        private void StopMovingLocal()
        {
            link.State = new LinkStandingStillState(link, damaged, healthyDateTime);
        }

        public override void StopMoving()
        {
        }
    }
}
