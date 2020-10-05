using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class Stairs : IInteractiveEnvironment
    {
        private StairSprite stairSprite;
        private SpriteBatch sB;
        public Stairs(SpriteBatch spriteBatch)
        {
            stairSprite = (StairSprite)SpriteFactory.Instance.CreateStairSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            stairSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
