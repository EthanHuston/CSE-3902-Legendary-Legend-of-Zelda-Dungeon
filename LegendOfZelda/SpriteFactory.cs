using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link;
using Sprint0.Link.Sprite;

namespace Sprint0
{
    //Sprite Factory based of model found in slides
    class SpriteFactory
    {
        private Texture2D batSprite;
        private Texture2D goriyaUpSprite;
        private Texture2D goriyaDownSprite;
        private Texture2D goriyaLeftSprite;
        private Texture2D goriyaRightSprite;
        private Texture2D goriyaBoomerangSprite;
        private Texture2D aquamentusBreathingSprite;
        private Texture2D aquamentusWalkingSprite;
        private Texture2D handSprite;
        private Texture2D jellySprite;
        private Texture2D skeletonSprite;
        private Texture2D spikeTrapSprite;
        private Texture2D blockSprite;
        private Texture2D statueSprite;
        private Texture2D stairSprite;
        private Texture2D doorSprite;
        private Texture2D ladderSprite;
        private Texture2D brickTileSprite;
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
        private Texture2D oldManSprite;
        private Texture2D merchantSprite;
        private Texture2D tileBlackSprite;
        private Texture2D tileWaterSprite;
        private Texture2D tileBlueGrassSprite;
        private Texture2D roomBorderSprite;

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
            goriyaUpSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingUp");
            goriyaDownSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingDown");
            goriyaRightSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingRight");
            goriyaLeftSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingLeft");
            goriyaBoomerangSprite = content.Load<Texture2D>("Items/BoomerangFlying");
            aquamentusBreathingSprite = content.Load<Texture2D>("Enemies/DragonBreathing");
            aquamentusWalkingSprite = content.Load<Texture2D>("Enemies/DragonWalking");
            handSprite = content.Load<Texture2D>("Enemies/Hand");
            jellySprite = content.Load<Texture2D>("Enemies/Jelly");
            skeletonSprite = content.Load<Texture2D>("Enemies/Skeleton");
            spikeTrapSprite = content.Load<Texture2D>("Enemies/SpikeTrap");
            //Load Environment Sprites
            blockSprite = content.Load<Texture2D>("Environment/Block");
            statueSprite = content.Load<Texture2D>("Environment/Statue");
            stairSprite = content.Load<Texture2D>("Environment/Stairs");
            doorSprite = content.Load<Texture2D>("Environment/Doors");
            ladderSprite = content.Load<Texture2D>("Environment/Ladder");
            brickTileSprite = content.Load<Texture2D>("Environment/BrickTile");
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
            //Load NPC Sprites
            oldManSprite = content.Load<Texture2D>("NPC/OldMan");
            merchantSprite = content.Load<Texture2D>("NPC/Merchant");
            //Load Tile Sprites
            tileBlackSprite = content.Load<Texture2D>("Environment/BlackTile");
            tileBlueGrassSprite = content.Load<Texture2D>("Environment/BlueGrassTile");
            tileWaterSprite = content.Load<Texture2D>("Environment/WaterTile");
            roomBorderSprite = content.Load<Texture2D>("Environment/RoomBorder");
            LinkSpriteFactory.Instance.LoadAllTextures(content);
        }

        public ISprite CreateBatSprite()
        {
            return new BatSprite(batSprite);
        }
        public ISprite CreateGoriyaUpSprite()
        {
            return new GoriyaUpSprite(goriyaUpSprite);
        }
        public ISprite CreateGoriyaDownSprite()
        {
            return new GoriyaUpSprite(goriyaDownSprite);
        }
        public ISprite CreateGoriyaRightSprite()
        {
            return new GoriyaRightSprite(goriyaRightSprite);
        }
        public ISprite CreateGoriyaLeftSprite()
        {
            return new GoriyaLeftSprite(goriyaLeftSprite);
        }
        public ISprite CreateGoriyaBoomerangSprite()
        {
            return new GoriyaBoomerangSprite(goriyaBoomerangSprite);
        }
        public ISprite CreateAquamentusBreathingSprite()
        {
            return new AquamentusBreathingSprite(aquamentusBreathingSprite);
        }
        public ISprite CreateAquamentusWalkingSprite()
        {
            return new AquamentusWalkingSprite(aquamentusWalkingSprite);
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
        public ISprite CreateStairSprite()
        {
            return new StairSprite(stairSprite);
        }
        public ISprite CreateDoorSprite()
        {
            return new DoorSprite(doorSprite);
        }
        public ISprite CreateLadderSprite()
        {
            return new LadderSprite(ladderSprite);
        }
        public ISprite CreateBrickTileSprite()
        {
            return new BrickTileSprite(brickTileSprite);
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
        public ISprite CreateOldManSprite()
        {
            return new OldManSprite(oldManSprite);
        }
        public ISprite CreateMerchantSprite()
        {
            return new MerchantSprite(merchantSprite);
        }
        public ISprite CreateTileBlackSprite()
        {
            return new TileBlackSprite(tileBlackSprite);
        }
        public ISprite CreateTileBlueGrassSprite()
        {
            return new TileBlueGrassSprite(tileBlueGrassSprite);
        }
        public ISprite CreateTileWaterSprite()
        {
            return new TileWaterSprite(tileWaterSprite);
        }
        public ISprite CreateRoomBorderSprite()
        {
            return new RoomBorderSprite(roomBorderSprite);
        }
    }
}
