using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    //Sprite Factory based of model found in slides
    internal class EnemySpriteFactory
    {
        private Texture2D batSprite;
        private Texture2D goriyaUpSprite;
        private Texture2D goriyaDownSprite;
        private Texture2D goriyaLeftSprite;
        private Texture2D goriyaRightSprite;
        private Texture2D aquamentusBreathingSprite;
        private Texture2D aquamentusWalkingSprite;
        private Texture2D handSprite;
        private Texture2D jellySprite;
        private Texture2D skeletonSprite;
        private Texture2D spikeTrapSprite;
        private Texture2D oldManSprite;
        private Texture2D spawnSprite;

        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Enemy Sprites
            //batSprite = content.Load<Texture2D>("Enemies/Bat");
            batSprite = content.Load<Texture2D>("Pokemon/Enemies/Zubat");
            //goriyaUpSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingUp");
            goriyaUpSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Up");
            //goriyaDownSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingDown");
            goriyaDownSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Down");
            //goriyaRightSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingRight");
            goriyaRightSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Right");
            //goriyaLeftSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingLeft");
            goriyaLeftSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Left");
            //aquamentusBreathingSprite = content.Load<Texture2D>("Enemies/DragonBreathing");
            aquamentusBreathingSprite = content.Load<Texture2D>("Pokemon/Enemies/HoOh");
            //aquamentusWalkingSprite = content.Load<Texture2D>("Enemies/DragonWalking");
            aquamentusWalkingSprite = content.Load<Texture2D>("Pokemon/Enemies/HoOh");
            //handSprite = content.Load<Texture2D>("Enemies/Hand");
            handSprite = content.Load<Texture2D>("Pokemon/Enemies/Haunter");
            //jellySprite = content.Load<Texture2D>("Enemies/Jelly");
            jellySprite = content.Load<Texture2D>("Pokemon/Enemies/Ditto");
            //skeletonSprite = content.Load<Texture2D>("Enemies/Skeleton");
            skeletonSprite = content.Load<Texture2D>("Pokemon/Enemies/Hitmonchan");
            //spikeTrapSprite = content.Load<Texture2D>("Enemies/SpikeTrap");
            spikeTrapSprite = content.Load<Texture2D>("Pokemon/Enemies/Decoy");
            oldManSprite = content.Load<Texture2D>("NPC/OldMan");
            spawnSprite = content.Load<Texture2D>("Enemies/EnemySpawn");
        }

        public IDamageableSprite CreateBatSprite()
        {
            return new BatSprite(batSprite);
        }
        public IDamageableSprite CreateGoriyaUpSprite()
        {
            return new GoriyaSprite(goriyaUpSprite);
        }
        public IDamageableSprite CreateGoriyaDownSprite()
        {
            return new GoriyaSprite(goriyaDownSprite);
        }
        public IDamageableSprite CreateGoriyaRightSprite()
        {
            return new GoriyaSprite(goriyaRightSprite);
        }
        public IDamageableSprite CreateGoriyaLeftSprite()
        {
            return new GoriyaSprite(goriyaLeftSprite);
        }
        public IDamageableSprite CreateAquamentusBreathingSprite()
        {
            return new AquamentusBreathingSprite(aquamentusBreathingSprite);
        }
        public IDamageableSprite CreateAquamentusWalkingSprite()
        {
            return new AquamentusWalkingSprite(aquamentusWalkingSprite);
        }
        public IDamageableSprite CreateHandSprite()
        {
            return new HandSprite(handSprite);
        }
        public IDamageableSprite CreateJellySprite()
        {
            return new JellySprite(jellySprite);
        }
        public IDamageableSprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(skeletonSprite);
        }
        public IDamageableSprite CreateSpikeTrapSprite()
        {
            return new SpikeTrapSprite(spikeTrapSprite);
        }
        public ISprite CreateOldManSprite()
        {
            return new OldManSprite(oldManSprite);
        }
        public ISprite CreateSpawnSprite()
        {
            return new SpawnSprite(spawnSprite);
        }
    }
}
