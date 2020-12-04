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

        private bool PokemonOn;

        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Enemy Sprites
            batSprite = content.Load<Texture2D>("Enemies/Bat");
            
            goriyaUpSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingUp");
            
            goriyaDownSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingDown");
            
            goriyaRightSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingRight");
           
            goriyaLeftSprite = content.Load<Texture2D>("Enemies/DogLikeMonsterWalkingLeft");
            
            aquamentusBreathingSprite = content.Load<Texture2D>("Enemies/DragonBreathing");
            
            aquamentusWalkingSprite = content.Load<Texture2D>("Enemies/DragonWalking");
            
            handSprite = content.Load<Texture2D>("Enemies/Hand");
           
            jellySprite = content.Load<Texture2D>("Enemies/Jelly");
            
            skeletonSprite = content.Load<Texture2D>("Enemies/Skeleton");
            
            spikeTrapSprite = content.Load<Texture2D>("Enemies/SpikeTrap");
           
            oldManSprite = content.Load<Texture2D>("NPC/OldMan");
            
            spawnSprite = content.Load<Texture2D>("Enemies/EnemySpawn");

            PokemonOn = false;
        }
        public void LoadPokemonTextures(ContentManager content)
        {
            batSprite = content.Load<Texture2D>("Pokemon/Enemies/Zubat");
            goriyaUpSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Up");
            goriyaDownSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Down");
            goriyaRightSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Right");
            goriyaLeftSprite = content.Load<Texture2D>("Pokemon/Enemies/Cubone Left");
            aquamentusBreathingSprite = content.Load<Texture2D>("Pokemon/Enemies/HoOh");
            aquamentusWalkingSprite = content.Load<Texture2D>("Pokemon/Enemies/HoOh");
            jellySprite = content.Load<Texture2D>("Pokemon/Enemies/Ditto");
            skeletonSprite = content.Load<Texture2D>("Pokemon/Enemies/Hitmonchan");
            handSprite = content.Load<Texture2D>("Pokemon/Enemies/Haunter");
            spikeTrapSprite = content.Load<Texture2D>("Pokemon/Enemies/Decoy");
            oldManSprite = content.Load<Texture2D>("Pokemon/Professor Oak");

            PokemonOn = true;
        }

        public IDamageableSprite CreateBatSprite()
        {
            return new BatSprite(batSprite, PokemonOn);
        }
        public IDamageableSprite CreateGoriyaUpSprite()
        {
            return new GoriyaSprite(goriyaUpSprite, PokemonOn);
        }
        public IDamageableSprite CreateGoriyaDownSprite()
        {
            return new GoriyaSprite(goriyaDownSprite, PokemonOn);
        }
        public IDamageableSprite CreateGoriyaRightSprite()
        {
            return new GoriyaSprite(goriyaRightSprite, PokemonOn);
        }
        public IDamageableSprite CreateGoriyaLeftSprite()
        {
            return new GoriyaSprite(goriyaLeftSprite, PokemonOn);
        }
        public IDamageableSprite CreateAquamentusBreathingSprite()
        {
            return new AquamentusBreathingSprite(aquamentusBreathingSprite, PokemonOn);
        }
        public IDamageableSprite CreateAquamentusWalkingSprite()
        {
            return new AquamentusWalkingSprite(aquamentusWalkingSprite, PokemonOn);
        }
        public IDamageableSprite CreateHandSprite()
        {
            return new HandSprite(handSprite, PokemonOn);
        }
        public IDamageableSprite CreateJellySprite()
        {
            return new JellySprite(jellySprite, PokemonOn);
        }
        public IDamageableSprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(skeletonSprite, PokemonOn);
        }
        public IDamageableSprite CreateSpikeTrapSprite()
        {
            return new SpikeTrapSprite(spikeTrapSprite, PokemonOn);
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
