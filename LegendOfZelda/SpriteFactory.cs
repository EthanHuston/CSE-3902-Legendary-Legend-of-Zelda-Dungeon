using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
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
            dogLikeMonsterSprite = content.Load<Texture2D>("Enemies/DogLikeMonster");
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
        }
    }
}
