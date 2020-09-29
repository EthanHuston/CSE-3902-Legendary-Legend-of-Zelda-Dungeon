using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Sprite;
using Sprint0.Link.State.NotMoving;

namespace Sprint0.Link
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

        private static LinkSpriteFactory instance = new LinkSpriteFactory();
        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //Load Link Sprites
            idleLinkDownSprite = content.Load<Texture2D>("Link/IdleLinkDown");
            idleLinkRightSprite = content.Load<Texture2D>("Link/IdleLinkRight");
            idleLinkLeftSprite = content.Load<Texture2D>("Link/IdleLinkLeft");
            idleLinkUpSprite = content.Load<Texture2D>("Link/IdleLinkUp");
            strikingDownLinkSprite = content.Load<Texture2D>("Link/LinkStrikingDown");
            strikingLeftLinkSprite = content.Load<Texture2D>("Link/LinkStrikingLeft");
            strikingRightLinkSprite = content.Load<Texture2D>("Link/LinkStrikingRight");
            strikingUpLinkSprite = content.Load<Texture2D>("Link/LinkStrikingUp");
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
        public ILinkSprite CreateUsingItemLeftLinkSprite()
        {
            return new UsingItemLinkSprite(usingItemLeftLinkSprite);
        }
        public ILinkSprite CreateUsingItemRightLinkSprite()
        {
            return new UsingItemLinkSprite(usingItemRightLinkSprite);
        }
        public ILinkSprite CreateUsingItemUpLinkSprite()
        {
            return new UsingItemLinkSprite(usingItemUpLinkSprite);
        }
        public ILinkSprite CreateUsingItemDownLinkSprite()
        {
            return new UsingItemLinkSprite(usingItemDownLinkSprite);
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
    }
}
