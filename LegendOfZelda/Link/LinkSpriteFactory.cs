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
        private bool pokemonOn;

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
            
            walkingDownLinkSprite = content.Load<Texture2D>("Link/WalkingDownLink");            
            walkingLeftLinkSprite = content.Load<Texture2D>("Link/WalkingLeftLink");            
            walkingRightLinkSprite = content.Load<Texture2D>("Link/WalkingRightLink");            
            walkingUpLinkSprite = content.Load<Texture2D>("Link/WalkingUpLink");            

            linkPickingUpHeartSprite = content.Load<Texture2D>("Link/LinkPickingUpHeart");            
            linkPickingUpTriforceSprite = content.Load<Texture2D>("Link/LinkPickingUpTriforce");            
            linkPickingUpBowSprite = content.Load<Texture2D>("Link/LinkPickingUpBow");           
            linkPickingUpBoomerangSprite = content.Load<Texture2D>("Link/LinkPickingUpBoomerang");
            pokemonOn = false;
            
        }
        public void LoadPokemonTextures(ContentManager content)
        {
            idleLinkDownSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleDown");
            idleLinkRightSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleRight");
            idleLinkLeftSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleLeft");
            idleLinkUpSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerIdleUp");

            strikingDownLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingDown");
            strikingLeftLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingLeft");
            strikingRightLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingRight");
            strikingUpLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingUp");

            walkingDownLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingDown");
            walkingLeftLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingLeft");
            walkingRightLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingRight");
            walkingUpLinkSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerWalkingUp");

            linkPickingUpHeartSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickUpHeart");
            linkPickingUpTriforceSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickUpTriforce");
            linkPickingUpBowSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickUpBow");
            linkPickingUpBoomerangSprite = content.Load<Texture2D>("Pokemon/Trainer/TrainerPickupBoomerang");
            pokemonOn = true;
        }

        public ILinkSprite CreateIdleLinkDownSprite()
        {
            return new IdleLinkSprite(idleLinkDownSprite, pokemonOn);
        }
        public ILinkSprite CreateIdleLinkLeftSprite()
        {
            return new IdleLinkSprite(idleLinkLeftSprite, pokemonOn);
        }
        public ILinkSprite CreateIdleLinkRightSprite()
        {
            return new IdleLinkSprite(idleLinkRightSprite, pokemonOn);
        }
        public ILinkSprite CreateIdleLinkUpSprite()
        {
            return new IdleLinkSprite(idleLinkUpSprite, pokemonOn);
        }
        public ILinkSprite CreateStrikingDownLinkSprite()
        {
            return new StrikingLinkSprite(strikingDownLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateStrikingLeftLinkSprite()
        {
            return new StrikingLinkSprite(strikingLeftLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateStrikingRightLinkSprite()
        {
            return new StrikingLinkSprite(strikingRightLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateStrikingUpLinkSprite()
        {
            return new StrikingLinkSprite(strikingUpLinkSprite, pokemonOn);
        }

        public ILinkSprite CreateWalkingDownLinkSprite()
        {
            return new WalkingLinkSprite(walkingDownLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateWalkingRightLinkSprite()
        {
            return new WalkingLinkSprite(walkingRightLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateWalkingLeftLinkSprite()
        {
            return new WalkingLinkSprite(walkingLeftLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateWalkingUpLinkSprite()
        {
            return new WalkingLinkSprite(walkingUpLinkSprite, pokemonOn);
        }
        public ILinkSprite CreateLinkPickingUpHeartContainerSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpHeartSprite, pokemonOn);
        }
        public ILinkSprite CreateLinkPickingUpTriforceSprite()
        {
            return new PickingUpTriforceLinkSprite(linkPickingUpTriforceSprite, pokemonOn);
        }
        public ILinkSprite CreateLinkPickingUpBowSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpBowSprite, pokemonOn);
        }
        public ILinkSprite CreateLinkPickingUpBoomerangSprite()
        {
            return new PickingUpItemLinkSprite(linkPickingUpBoomerangSprite, pokemonOn);
        }
    }
}
