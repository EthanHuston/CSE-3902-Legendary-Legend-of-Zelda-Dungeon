using LegendOfZelda.Interface;
using LegendOfZelda.Projectile.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    //Sprite Factory based of model found in slides
    class ProjectileSpriteFactory
    {

        private Texture2D fireballSprite;
        private Texture2D explodingBombSprite;
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

        public static ProjectileSpriteFactory Instance { get; } = new ProjectileSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            fireballSprite = content.Load<Texture2D>("Items/FireBall");
            explodingBombSprite = content.Load<Texture2D>("Items/BombExploding");
            arrowDownSprite = content.Load<Texture2D>("Items/ArrowDown");
            arrowUpSprite = content.Load<Texture2D>("Items/ArrowUp");
            arrowRightSprite = content.Load<Texture2D>("Items/ArrowRight");
            arrowLeftSprite = content.Load<Texture2D>("Items/ArrowLeft");
            bombExplodingSprite = content.Load<Texture2D>("Items/BombExploding");
            boomerangFlyingSprite = content.Load<Texture2D>("Items/BoomerangFlying");
            swordBeamDown = content.Load<Texture2D>("Items/SwordBeamDown");
            swordBeamUp = content.Load<Texture2D>("Items/SwordBeamUp");
            swordBeamRight = content.Load<Texture2D>("Items/SwordBeamRight");
            swordBeamLeft = content.Load<Texture2D>("Items/SwordBeamLeft");
            swordBeamExplodingDownLeft = content.Load<Texture2D>("Items/SwordBeamExplosionDownLeft");
            swordBeamExplodingDownRight = content.Load<Texture2D>("Items/SwordBeamExplosionDownRight");
            swordBeamExplodingUpLeft = content.Load<Texture2D>("Items/SwordBeamExplosionUpLeft");
            swordBeamExplodingUpRight = content.Load<Texture2D>("Items/SwordBeamExplosionUpRight");
        }

        public IItemSprite CreateFireballSprite()
        {
            return new FireballSprite(fireballSprite);
        }
        public IItemSprite CreateExplodingBombSprite()
        {
            return new BombExplodingSprite(explodingBombSprite);
        }
        public IItemSprite CreateArrowUpSprite()
        {
            return new ArrowFlyingSprite(arrowUpSprite);
        }
        public IItemSprite CreateArrowDownSprite()
        {
            return new ArrowFlyingSprite(arrowDownSprite);
        }
        public IItemSprite CreateArrowRightSprite()
        {
            return new ArrowFlyingSprite(arrowRightSprite);
        }
        public IItemSprite CreateArrowLeftSprite()
        {
            return new ArrowFlyingSprite(arrowLeftSprite);
        }
        public IItemSprite CreateBombExplodingSprite()
        {
            return new BombExplodingSprite(bombExplodingSprite);
        }
        public IItemSprite CreateBoomerangFlyingSprite()
        {
            return new BoomerangFlyingSprite(boomerangFlyingSprite);
        }
        public IItemSprite CreateSwordBeamDownSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamDown);
        }
        public IItemSprite CreateSwordBeamUpSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamUp);
        }
        public IItemSprite CreateSwordBeamRightSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamRight);
        }
        public IItemSprite CreateSwordBeamLeftSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamLeft);
        }
        public IItemSprite CreateSwordBeamExplodingSprite()
        {
            return new SwordBeamExplodingSprite(swordBeamExplodingUpLeft, swordBeamExplodingUpRight, swordBeamExplodingDownLeft, swordBeamExplodingDownRight);
        }
    }
}
