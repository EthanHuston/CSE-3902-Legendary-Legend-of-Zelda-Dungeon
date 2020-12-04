using LegendOfZelda.Projectile.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    //Sprite Factory based of model found in slides
    internal class ProjectileSpriteFactory
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
        private Texture2D swordAttackUp;
        private Texture2D swordAttackDown;
        private Texture2D swordAttackLeft;
        private Texture2D swordAttackRight;

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
            //swordBeamDown = content.Load<Texture2D>("Items/SwordBeamDown");
            swordBeamDown = content.Load<Texture2D>("Pokemon/Items/Pokeball");
            //swordBeamUp = content.Load<Texture2D>("Items/SwordBeamUp");
            swordBeamUp = content.Load<Texture2D>("Pokemon/Items/Pokeball");
            //swordBeamRight = content.Load<Texture2D>("Items/SwordBeamRight");
            swordBeamRight = content.Load<Texture2D>("Pokemon/Items/Pokeball");
            //swordBeamLeft = content.Load<Texture2D>("Items/SwordBeamLeft");
            swordBeamLeft = content.Load<Texture2D>("Pokemon/Items/Pokeball");
            //swordBeamExplodingDownLeft = content.Load<Texture2D>("Items/SwordBeamExplosionDownLeft");
            swordBeamExplodingDownRight = content.Load<Texture2D>("Items/SwordBeamExplosionDownRight");
            swordBeamExplodingUpLeft = content.Load<Texture2D>("Items/SwordBeamExplosionUpLeft");
            swordBeamExplodingUpRight = content.Load<Texture2D>("Items/SwordBeamExplosionUpRight");
            //swordAttackUp = content.Load<Texture2D>("Link/LinkSwordUp");
            swordAttackUp = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingUp");
            //swordAttackDown = content.Load<Texture2D>("Link/LinkSwordDown");
            swordAttackDown = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingDown");
            //swordAttackLeft = content.Load<Texture2D>("Link/LinkSwordLeft");
            swordAttackLeft = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingLeft");
            //swordAttackRight = content.Load<Texture2D>("Link/LinkSwordRight");
            swordAttackRight = content.Load<Texture2D>("Pokemon/Trainer/TrainerStrikingRight");
        }

        public IProjectileSprite CreateFireballSprite()
        {
            return new FireballSprite(fireballSprite);
        }
        public IProjectileSprite CreateExplodingBombSprite()
        {
            return new BombExplodingSprite(explodingBombSprite);
        }
        public IProjectileSprite CreateArrowUpSprite()
        {
            return new ArrowFlyingSprite(arrowUpSprite);
        }
        public IProjectileSprite CreateArrowDownSprite()
        {
            return new ArrowFlyingSprite(arrowDownSprite);
        }
        public IProjectileSprite CreateArrowRightSprite()
        {
            return new ArrowFlyingSprite(arrowRightSprite);
        }
        public IProjectileSprite CreateArrowLeftSprite()
        {
            return new ArrowFlyingSprite(arrowLeftSprite);
        }
        public IProjectileSprite CreateBombExplodingSprite()
        {
            return new BombExplodingSprite(bombExplodingSprite);
        }
        public IProjectileSprite CreateBoomerangFlyingSprite()
        {
            return new BoomerangFlyingSprite(boomerangFlyingSprite);
        }
        public IProjectileSprite CreateSwordBeamDownSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamDown);
        }
        public IProjectileSprite CreateSwordBeamUpSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamUp);
        }
        public IProjectileSprite CreateSwordBeamRightSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamRight);
        }
        public IProjectileSprite CreateSwordBeamLeftSprite()
        {
            return new SwordBeamFlyingSprite(swordBeamLeft);
        }
        public IProjectileSprite CreateSwordBeamExplodingSprite()
        {
            return new SwordBeamExplodingSprite(swordBeamExplodingUpLeft, swordBeamExplodingUpRight, swordBeamExplodingDownLeft, swordBeamExplodingDownRight);
        }

        public IProjectileSprite CreateSwordAttackingUpSprite()
        {
            return new SwordAttackingSprite(swordAttackUp);
        }
        public IProjectileSprite CreateSwordAttackingDownSprite()
        {
            return new SwordAttackingSprite(swordAttackDown);
        }
        public IProjectileSprite CreateSwordAttackingLeftSprite()
        {
            return new SwordAttackingSprite(swordAttackLeft);
        }
        public IProjectileSprite CreateSwordAttackingRightSprite()
        {
            return new SwordAttackingSprite(swordAttackRight);
        }
    }
}
