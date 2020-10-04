using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;
using Sprint0.Link.Sprite;

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
        private Texture2D linkPickingUpHeartSprite;
        private Texture2D linkPickingUpTriforceSprite;
        private Texture2D linkPickingUpBowSprite;
        private Texture2D linkPickingUpBoomerangSprite;
        private Texture2D arrowUpSprite;
        private Texture2D arrowDownSprite;
        private Texture2D arrowRightSprite;
        private Texture2D arrowLeftSprite;
        private Texture2D bombExplodingSprite;
        private Texture2D boomerangFlyingSprite;
        private Texture2D swordBeamUp;
        private Texture2D swordBeamDown;
        private Texture2D swordBeamRight;
        private Texture2D swordBeamLeft;
        private Texture2D swordBeamExplodingDownLeft;
        private Texture2D swordBeamExplodingDownRight;
        private Texture2D swordBeamExplodingUpLeft;
        private Texture2D swordBeamExplodingUpRight;

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
            // Load Link sprites
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
            linkPickingUpHeartSprite = content.Load<Texture2D>("Link/LinkPickingUpHeart");
            linkPickingUpTriforceSprite = content.Load<Texture2D>("Link/LinkPickingUpTriforce");
            linkPickingUpBowSprite = content.Load<Texture2D>("Link/LinkPickingUpBow");
            linkPickingUpBoomerangSprite = content.Load<Texture2D>("Link/LinkPickingUpBoomerang");

            // Load Link's item sprites
            arrowDownSprite = content.Load<Texture2D>("Items/ArrowDown");
            arrowUpSprite = content.Load<Texture2D>("Items/ArrowUp");
            arrowRightSprite = content.Load<Texture2D>("Items/ArrowRight");
            arrowLeftSprite = content.Load<Texture2D>("Items/ArrowLeft");
            bombExplodingSprite = content.Load<Texture2D>("Item/BombExploding");
            boomerangFlyingSprite = content.Load<Texture2D>("Item/BoomerangFlying");
            swordBeamDown = content.Load<Texture2D>("Item/SwordBeamDown");
            swordBeamUp = content.Load<Texture2D>("Item/SwordBeamUp");
            swordBeamRight = content.Load<Texture2D>("Item/SwordBeamRight");
            swordBeamLeft = content.Load<Texture2D>("Item/SwordBeamLeft");
            swordBeamExplodingDownLeft = content.Load <Texture2D>("Item/SwordBeamExplosionDownLeft");
            swordBeamExplodingDownRight = content.Load <Texture2D>("Item/SwordBeamExplosionDownRight");
            swordBeamExplodingUpLeft = content.Load <Texture2D>("Item/SwordBeamExplosionUpLeft");
            swordBeamExplodingUpRight = content.Load <Texture2D>("Item/SwordBeamExplosionUpRight");
        }
        // Link Sprites
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
        public ILinkSprite CreateLinkPickingUpHeartSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpHeartSprite);
        }
        public ILinkSprite CreateLinkPickingUpTriforceSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpTriforceSprite);
        }
        public ILinkSprite CreateLinkPickingUpBowSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpBowSprite);
        }
        public ILinkSprite CreateLinkPickingUpBoomerangSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpBoomerangSprite);
        }

        // Link item sprites
        public ILinkItemSprite CreateArrowUpSprite()
        {
            return new ArrowFlyingSprite(arrowUpSprite);
        }
        public ILinkItemSprite CreateArrowDownSprite()
        {
            return new ArrowFlyingSprite(arrowDownSprite);
        }
        public ILinkItemSprite CreateArrowRightSprite()
        {
            return new ArrowFlyingSprite(arrowRightSprite);
        }
        public ILinkItemSprite CreateArrowLeftSprite()
        {
            return new ArrowFlyingSprite(arrowLeftSprite);
        }
        public ILinkItemSprite CreateBombExplodingSprite()
        {
            return new BombExplodingSprite(bombExplodingSprite);
        }
        public ILinkItemSprite CreateBoomerangFlyingSprite()
        {
            return new BoomerangFlyingSprite(boomerangFlyingSprite);
        }
        public ILinkItemSprite CreateSwordBeamDownSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamDown);
        }
        public ILinkItemSprite CreateSwordBeamUpSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamUp);
        }
        public ILinkItemSprite CreateSwordBeamRightSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamRight);
        }
        public ILinkItemSprite CreateSwordBeamLeftSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamLeft);
        }
        public ILinkItemSprite CreateSwordBeamExplodingSprite()
        {
            return new SwordBeamExplodingSprite(swordBeamExplodingDownLeft, swordBeamExplodingDownRight, swordBeamExplodingUpLeft, swordBeamExplodingUpRight);
        }
    }
}
