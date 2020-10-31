using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link
{
    //Sprite Factory based of model found in slides
    class LinkSpriteFactory
    {
        private Texture2D idleLinkDownSprite;
        private Texture2D idleLinkRightSprite;
        private Texture2D idleLinkLeftSprite;
        private Texture2D idleLinkUpSprite;
        private Texture2D strikingDownLinkSprite;
        private Texture2D strikingUpLinkSprite;
        private Texture2D strikingLeftLinkSprite;
        private Texture2D strikingRightLinkSprite;
        private Texture2D pickingUpItemLinkSprite;
        private Texture2D usingItemDownLinkSprite;
        private Texture2D usingItemUpLinkSprite;
        private Texture2D usingItemRightLinkSprite;
        private Texture2D usingItemLeftLinkSprite;
        private Texture2D walkingDownLinkSprite;
        private Texture2D walkingUpLinkSprite;
        private Texture2D walkingLeftLinkSprite;
        private Texture2D walkingRightLinkSprite;
        private Texture2D linkPickingUpSwordSprite;
        private Texture2D linkPickingUpHeartSprite;
        private Texture2D linkPickingUpTriforceSprite;
        private Texture2D linkPickingUpBowSprite;
        private Texture2D linkPickingUpBoomerangSprite;

        public static LinkSpriteFactory Instance { get; } = new LinkSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            // Load Link sprites
            idleLinkDownSprite = content.Load<Texture2D>("Link/IdleLinkDown");
            idleLinkRightSprite = content.Load<Texture2D>("Link/IdleLinkRight");
            idleLinkLeftSprite = content.Load<Texture2D>("Link/IdleLinkLeft");
            idleLinkUpSprite = content.Load<Texture2D>("Link/IdleLinkUp");
            strikingDownLinkSprite = content.Load<Texture2D>("Link/LinkSwordDown");
            strikingLeftLinkSprite = content.Load<Texture2D>("Link/LinkSwordLeft");
            strikingRightLinkSprite = content.Load<Texture2D>("Link/LinkSwordRight");
            strikingUpLinkSprite = content.Load<Texture2D>("Link/LinkSwordUp");
            pickingUpItemLinkSprite = content.Load<Texture2D>("Link/LinkPickingUpItem");
            usingItemDownLinkSprite = content.Load<Texture2D>("Link/LinkUsingItemDown");
            usingItemUpLinkSprite = content.Load<Texture2D>("Link/LinkUsingItemUp");
            usingItemRightLinkSprite = content.Load<Texture2D>("Link/LinkUsingItemRight");
            usingItemLeftLinkSprite = content.Load<Texture2D>("Link/LinkUsingItemLeft");
            walkingDownLinkSprite = content.Load<Texture2D>("Link/WalkingDownLink");
            walkingLeftLinkSprite = content.Load<Texture2D>("Link/WalkingLeftLink");
            walkingRightLinkSprite = content.Load<Texture2D>("Link/WalkingRightLink");
            walkingUpLinkSprite = content.Load<Texture2D>("Link/WalkingUpLink");
            linkPickingUpSwordSprite = content.Load<Texture2D>("Link/LinkPickingUpSword");
            linkPickingUpHeartSprite = content.Load<Texture2D>("Link/LinkPickingUpHeart");
            linkPickingUpTriforceSprite = content.Load<Texture2D>("Link/LinkPickingUpTriforce");
            linkPickingUpBowSprite = content.Load<Texture2D>("Link/LinkPickingUpBow");
            linkPickingUpBoomerangSprite = content.Load<Texture2D>("Link/LinkPickingUpBoomerang");
        }

        public ILinkSprite CreateIdleLinkDownSprite()
        {
            return new IdleLinkSprite(idleLinkDownSprite);
        }
        public ILinkSprite CreateIdleLinkLeftSprite()
        {
            return new IdleLinkSprite(idleLinkLeftSprite);
        }
        public ILinkSprite CreateIdleLinkRightSprite()
        {
            return new IdleLinkSprite(idleLinkRightSprite);
        }
        public ILinkSprite CreateIdleLinkUpSprite()
        {
            return new IdleLinkSprite(idleLinkUpSprite);
        }
        public ILinkSprite CreateStrikingDownLinkSprite()
        {
            return new StrikingLinkSprite(strikingDownLinkSprite);
        }
        public ILinkSprite CreateStrikingLeftLinkSprite()
        {
            return new StrikingLinkSprite(strikingLeftLinkSprite);
        }
        public ILinkSprite CreateStrikingRightLinkSprite()
        {
            return new StrikingLinkSprite(strikingRightLinkSprite);
        }
        public ILinkSprite CreateStrikingUpLinkSprite()
        {
            return new StrikingLinkSprite(strikingUpLinkSprite);
        }
        public ILinkSprite CreatePickingUpItemLinkSprite()
        {
            return new PickingUpItemLinkSprite(pickingUpItemLinkSprite);
        }
        public ILinkSprite CreateWalkingDownLinkSprite()
        {
            return new WalkingLinkSprite(walkingDownLinkSprite);
        }
        public ILinkSprite CreateWalkingRightLinkSprite()
        {
            return new WalkingLinkSprite(walkingRightLinkSprite);
        }
        public ILinkSprite CreateWalkingLeftLinkSprite()
        {
            return new WalkingLinkSprite(walkingLeftLinkSprite);
        }
        public ILinkSprite CreateWalkingUpLinkSprite()
        {
            return new WalkingLinkSprite(walkingUpLinkSprite);
        }
        public ILinkSprite CreateLinkPickingUpSwordSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpSwordSprite);
        }
        public ILinkSprite CreateLinkPickingUpHeartContainerSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpHeartSprite);
        }
        public ILinkSprite CreateLinkPickingUpTriforceSprite()
        {
            return new PickingUpTriforceLinkSprite(linkPickingUpTriforceSprite);
        }
        public ILinkSprite CreateLinkPickingUpBowSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpBowSprite);
        }
        public ILinkSprite CreateLinkPickingUpBoomerangSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpBoomerangSprite);
        }
    }
}
