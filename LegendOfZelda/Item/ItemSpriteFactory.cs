using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    //Sprite Factory based of model found in slides
    class ItemSpriteFactory
    {
        private Texture2D arrowSprite;
        private Texture2D bombSprite;
        private Texture2D boomerangSprite;
        private Texture2D bowSprite;
        private Texture2D clockSprite;
        private Texture2D compassSprite;
        private Texture2D fairySprite;
        private Texture2D fireSprite;
        private Texture2D heartSprite;
        private Texture2D heartContainerSprite;
        private Texture2D keySprite;
        private Texture2D mapSprite;
        private Texture2D rupeeSprite;
        private Texture2D triforceSprite;

        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            arrowSprite = content.Load<Texture2D>("Items/Arrow");
            bombSprite = content.Load<Texture2D>("Items/Bomb");
            boomerangSprite = content.Load<Texture2D>("Items/Boomerang");
            bowSprite = content.Load<Texture2D>("Items/Bow");
            clockSprite = content.Load<Texture2D>("Items/Clock");
            compassSprite = content.Load<Texture2D>("Items/Compass");
            fairySprite = content.Load<Texture2D>("Items/Fairy");
            fireSprite = content.Load<Texture2D>("Items/Fire");
            heartSprite = content.Load<Texture2D>("Items/Heart");
            heartContainerSprite = content.Load<Texture2D>("Items/HeartContainer");
            keySprite = content.Load<Texture2D>("Items/Key");
            mapSprite = content.Load<Texture2D>("Items/Map");
            rupeeSprite = content.Load<Texture2D>("Items/Rupee");
            triforceSprite = content.Load<Texture2D>("Items/TriforcePiece");
        }

        public IItemSprite CreateArrowSprite()
        {
            return new ArrowSprite(arrowSprite);
        }
        public IItemSprite CreateBombSprite()
        {
            return new BombSprite(bombSprite);
        }
        public IItemSprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(boomerangSprite);
        }
        public IItemSprite CreateBowSprite()
        {
            return new BowSprite(bowSprite);
        }
        public IItemSprite CreateClockSprite()
        {
            return new ClockSprite(clockSprite);
        }
        public IItemSprite CreateCompassSprite()
        {
            return new CompassSprite(compassSprite);
        }
        public IItemSprite CreateFairySprite(Point spawnPosition)
        {
            return new FairySprite(fairySprite, spawnPosition);
        }
        public IItemSprite CreateFireSprite()
        {
            return new FireSprite(fireSprite);
        }
        public IItemSprite CreateHeartSprite()
        {
            return new HeartSprite(heartSprite);
        }
        public IItemSprite CreateHeartContainerSprite()
        {
            return new HeartContainerSprite(heartContainerSprite);
        }
        public IItemSprite CreateKeySprite()
        {
            return new KeySprite(keySprite);
        }
        public IItemSprite CreateMapSprite()
        {
            return new MapSprite(mapSprite);
        }
        public IItemSprite CreateRupeeSprite()
        {
            return new RupeeSprite(rupeeSprite);
        }
        public IItemSprite CreateTriforceSprite()
        {
            return new TriforceSprite(triforceSprite);
        }
    }
}
