using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    //Sprite Factory based of model found in slides
    class SpriteFactory
    {
        private Texture2D batSprite;
        private Texture2D dogLikeMonsterSprite;
        private Texture2D dragonBreathingSprite;
        private Texture2D dragonWalkingSprite;
        private Texture2D handSprite;
        private Texture2D jellySprite;
        private Texture2D skeletonSprite;
        private Texture2D spikeTrapSprite;
        private Texture2D blockSprite;
        private Texture2D statueSprite;
        private Texture2D arrowSprite;
        private Texture2D bombSprite;
        private Texture2D explodingBombSprite;
        private Texture2D boomerangSprite;
        private Texture2D bowSprite;
        private Texture2D clockSprite;
        private Texture2D compassSprite;
        private Texture2D fairySprite;
        private Texture2D fireSprite;
        private Texture2D fireballSprite;
        private Texture2D heartSprite;
        private Texture2D heartContainerSprite;
        private Texture2D keySprite;
        private Texture2D mapSprite;
        private Texture2D rupeeSprite;
        private Texture2D triforceSprite;
        private Texture2D idleLinkSprite;
        private Texture2D strikingDownLinkSprite;
        private Texture2D strikingUpLinkSprite;
        private Texture2D strikingLeftLinkSprite;
        private Texture2D strikingRightLinkSprite;
        private Texture2D pickingUpItemLinkSprite;
        private Texture2D usingItemLinkSprite;
        private Texture2D walkingDownLinkSprite;
        private Texture2D walkingUpLinkSprite;
        private Texture2D walkingLeftLinkSprite;
        private Texture2D walkingRightLinkSprite;
        private Texture2D oldManSprite;
        private Texture2D merchantSprite;
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SpriteFactory()
        { 
        }

        public void LoadAllTextures(ContentManager content)
        {
            //Load Enemy Sprites
            batSprite = content.Load<Texture2D>("Enemies/Bat");
            dogLikeMonsterSprite = content.Load<Texture2D>("DogLikeMonster");
            dragonBreathingSprite = content.Load<Texture2D>("Enemies/DragonBreathing");
            dragonWalkingSprite = content.Load<Texture2D>("Enemies/DragonWalking");
            handSprite = content.Load<Texture2D>("Enemies/Hand");
            jellySprite = content.Load<Texture2D>("Enemies/Jelly");
            skeletonSprite = content.Load<Texture2D>("Enemies/Skeleton");
            spikeTrapSprite = content.Load<Texture2D>("Enemies/SpikeTrap");
            //Load Environment Sprites
            blockSprite = content.Load<Texture2D>("Environment/Block");
            statueSprite = content.Load<Texture2D>("Environment/Statue");
            //Load Item Sprites
            arrowSprite = content.Load<Texture2D>("Items/Arrow");
            bombSprite = content.Load<Texture2D>("Items/Bomb");
            explodingBombSprite = content.Load<Texture2D>("Items/BombWithExplosion");
            boomerangSprite = content.Load<Texture2D>("Items/Boomerang");
            bowSprite = content.Load<Texture2D>("Items/Bow");
            clockSprite = content.Load<Texture2D>("Items/Clock");
            compassSprite = content.Load<Texture2D>("Items/Compass");
            fairySprite = content.Load<Texture2D>("Items/Fairy");
            fireSprite = content.Load<Texture2D>("Items/Fire");
            fireballSprite = content.Load<Texture2D>("Items/Fireball");
            heartSprite = content.Load<Texture2D>("Items/Heart");
            heartContainerSprite = content.Load<Texture2D>("Items/HeartContainer");
            keySprite = content.Load<Texture2D>("Items/Key");
            mapSprite = content.Load<Texture2D>("Items/Map");
            rupeeSprite = content.Load<Texture2D>("Items/Ruppee");
            triforceSprite = content.Load<Texture2D>("Items/TriforcePiece");
            //Load Link Sprites
            idleLinkSprite = content.Load<Texture2D>("Link/IdleLink");
            strikingDownLinkSprite = content.Load<Texture2D>("Link/LinkStrikingDown");
            strikingLeftLinkSprite = content.Load<Texture2D>("Link/LinkStrikingLeft");
            strikingRightLinkSprite = content.Load<Texture2D>("Link/LinkStrikingRight");
            strikingUpLinkSprite = content.Load<Texture2D>("Link/LinkStrikingUp");
            pickingUpItemLinkSprite = content.Load<Texture2D>("Link/PickingUpItemLink");
            usingItemLinkSprite = content.Load<Texture2D>("Link/UsingItemLink");
            walkingDownLinkSprite = content.Load<Texture2D>("Link/WalkingDownLink");
            walkingLeftLinkSprite = content.Load<Texture2D>("Link/WalkingLeftLink");
            walkingRightLinkSprite = content.Load<Texture2D>("Link/WalkingRightLink");
            walkingUpLinkSprite = content.Load<Texture2D>("Link/WalkingUpLink");
            //Load NPC Sprites
            oldManSprite = content.Load<Texture2D>("NPC/OldMan");
            merchantSprite = content.Load<Texture2D>("NPC/Merchant");
        }

        public ISprite CreateBatSprite()
        {
            return new BatSprite(batSprite);
        }

        public ISprite CreateDogLikeMonsterSprite()
        {
            return new GoriyaSprite(dogLikeMonsterSprite);
        }
        public ISprite CreateDragonBreathingSprite()
        {
            return new AquamentusBreathingSprite(dragonBreathingSprite);
        }
        public ISprite CreateDragonWalkingSprite()
        {
            return new AquamentusWalkingSprite(dragonWalkingSprite);
        }
        public ISprite CreateHandSprite()
        {
            return new HandSprite(handSprite);
        }
        public ISprite CreateJellySprite()
        {
            return new JellySprite(jellySprite);
        }
        public ISprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(skeletonSprite);
        }
        public ISprite CreateSpikeTrapSprite()
        {
            return new SpikeTrapSprite(spikeTrapSprite);
        }
        public ISprite CreateBlockSprite()
        {
            return new BlockSprite(blockSprite);
        }
        public ISprite CreateStatueSprite()
        {
            return new StatueSprite(statueSprite);
        }
        public ISprite CreateArrowSprite()
        {
            return new ArrowSprite(arrowSprite);
        }
        public ISprite CreateBombSprite()
        {
            return new BombSprite(bombSprite);
        }
        public ISprite CreateExplodingBombSprite()
        {
            return new ExplodingBombSprite(explodingBombSprite);
        }
        public ISprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(boomerangSprite);
        }
        public ISprite CreateBowSprite()
        {
            return new BowSprite(bowSprite);
        }
        public ISprite CreateClockSprite()
        {
            return new ClockSprite(clockSprite);
        }
        public ISprite CreateCompassSprite()
        {
            return new CompassSprite(compassSprite);
        }
        public ISprite CreateFairySprite()
        {
            return new FairySprite(fairySprite);
        }
        public ISprite CreateFireSprite()
        {
            return new FireSprite(fireSprite);
        }
        public ISprite CreateFireballSprite()
        {
            return new FireballSprite(fireballSprite);
        }
        public ISprite CreateHeartSprite()
        {
            return new HeartSprite(heartSprite);   
        }
        public ISprite CreateHeartContainerSprite()
        {
            return new HeartContainerSprite(heartContainerSprite);
        }
        public ISprite CreateKeySprite()
        {
            return new KeySprite(keySprite);
        }
        public ISprite CreateMapSprite()
        {
            return new MapSprite(mapSprite);
        }
        public ISprite CreateRupeeSprite()
        {
            return new RupeeSprite(rupeeSprite);
        }
        public ISprite CreateTriforceSprite()
        {
            return new TriforceSprite(triforceSprite);
        }
        public ISprite CreateIdleLinkSprite()
        {
            return new IdleLinkSprite(idleLinkSprite);
        }
        public ISprite CreateStrikingDownLinkSprite()
        {
            return new StrikingDownLinkSprite(strikingDownLinkSprite);
        }
        public ISprite CreateStrikingLeftLinkSprite()
        {
            return new StrikingLeftLinkSprite(strikingLeftLinkSprite);
        }
        public ISprite CreateStrikingRightLinkSprite()
        {
            return new StrikingRightLinkSprite(strikingRightLinkSprite);
        }
        public ISprite CreateStrikingUpLinkSprite()
        {
            return new StrikingUpLinkSprite(strikingUpLinkSprite);
        }
        public ISprite CreatePickingUpItemLinkSprite()
        {
            return new PickingUpItemLinkSprite(pickingUpItemLinkSprite);
        }
        public ISprite CreateUsingItemLinkSprite()
        {
            return new UsingItemLinkSprite(usingItemLinkSprite);
        }
        public ISprite CreateWalkingDownLinkSprite()
        {
            return new WalkingDownLinkSprite(walkingDownLinkSprite);
        }
        public ISprite CreateWalkingRightLinkSprite()
        {
            return new WalkingRightLinkSprite(walkingRightLinkSprite);
        }
        public ISprite CreateWalkingLeftLinkSprite()
        {
            return new WalkingLeftLinkSprite(walkingLeftLinkSprite);
        }
        public ISprite CreateWalkingUpLinkSprite()
        {
            return new WalkingUpLinkSprite(walkingUpLinkSprite);
        }
        public ISprite CreateOldManSprite()
        {
            return new OldManSprite(oldManSprite);
        }
        public ISprite CreateMerchantSprite()
        {
            return new MerchantSprite(merchantSprite);
        }
    }
}
