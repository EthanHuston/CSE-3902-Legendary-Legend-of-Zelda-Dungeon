using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class LadderTile : IInteractiveEnviornment
    {
        private LadderSprite ladderSprite;
        private SpriteBatch sB;
        public LadderTile(SpriteBatch spriteBatch)
        {
            ladderSprite = (LadderSprite)SpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            ladderSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
