using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class Statues : IBlock
    {
        private StatueSprite statueSprite;
        private SpriteBatch sB;
        public Statues(SpriteBatch spriteBatch)
        {
            statueSprite = (StatueSprite)SpriteFactory.Instance.CreateStatueSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            statueSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
