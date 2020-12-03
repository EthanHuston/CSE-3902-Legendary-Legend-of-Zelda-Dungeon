using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link
{
    //Sprite Factory based of model found in slides
    internal class LinkSpriteFactory
    {
        private Texture2D idleLinkDownSprite;
        private Texture2D idleLinkRightSprite;
        private Texture2D idleLinkLeftSprite;
        private Texture2D idleLinkUpSprite;
        private Texture2D strikingDownLinkSprite;
        private Texture2D strikingUpLinkSprite;
        private Texture2D strikingLeftLinkSprite;
        private Texture2D strikingRightLinkSprite;
        
        private Texture2D walkingDownLinkSprite;
        private Texture2D walkingUpLinkSprite;
        private Texture2D walkingLeftLinkSprite;
        private Texture2D walkingRightLinkSprite;
        private Texture2D linkPickingUpHeartSprite;
        private Texture2D linkPickingUpTriforceSprite;
        private Texture2D linkPickingUpBowSprite;
        private Texture2D linkPickingUpBoomerangSprite;

        public static LinkSpriteFactory Instance { get; } = new LinkSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            // Load Link sprites
            //idleLinkDownSprite = content.Load<Texture2D>("Link/IdleLinkDown");
            idleLinkDownSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleDown");
            //idleLinkRightSprite = content.Load<Texture2D>("Link/IdleLinkRight");
            idleLinkRightSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleRight");
            //idleLinkLeftSprite = content.Load<Texture2D>("Link/IdleLinkLeft");
            idleLinkLeftSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleLeft");
            //idleLinkUpSprite = content.Load<Texture2D>("Link/IdleLinkUp");
            idleLinkUpSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleUp");
            strikingDownLinkSprite = content.Load<Texture2D>("Link/LinkSwordDown");
            strikingLeftLinkSprite = content.Load<Texture2D>("Link/LinkSwordLeft");
            strikingRightLinkSprite = content.Load<Texture2D>("Link/LinkSwordRight");
            strikingUpLinkSprite = content.Load<Texture2D>("Link/LinkSwordUp");
           /* pickingUpItemLinkSprite = content.Load<Texture2D>("Link/LinkPickingUpItem");*/
            //walkingDownLinkSprite = content.Load<Texture2D>("Link/WalkingDownLink");
            walkingDownLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingDown");
            //walkingLeftLinkSprite = content.Load<Texture2D>("Link/WalkingLeftLink");
            walkingLeftLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingLeft");
            //walkingRightLinkSprite = content.Load<Texture2D>("Link/WalkingRightLink");
            walkingRightLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingRight");
            //walkingUpLinkSprite = content.Load<Texture2D>("Link/WalkingUpLink");
            walkingUpLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingUp");

            //linkPickingUpHeartSprite = content.Load<Texture2D>("Link/LinkPickingUpHeart");
            linkPickingUpHeartSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickUpHeart");
            //linkPickingUpTriforceSprite = content.Load<Texture2D>("Link/LinkPickingUpTriforce");
            linkPickingUpTriforceSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickgUpTriforce");
            //linkPickingUpBowSprite = content.Load<Texture2D>("Link/LinkPickingUpBow");
            linkPickingUpBowSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickUpBow");
            //linkPickingUpBoomerangSprite = content.Load<Texture2D>("Link/LinkPickingUpBoomerang");
            linkPickingUpBoomerangSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickupBoomerang");
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
