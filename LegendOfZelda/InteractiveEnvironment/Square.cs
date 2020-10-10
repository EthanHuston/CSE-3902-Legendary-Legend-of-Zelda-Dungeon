using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class Square : IBlock
    {
        private BlockSprite blockSprite;
        private SpriteBatch sB;
        public Square(SpriteBatch spriteBatch)
        {
            blockSprite = (BlockSprite)SpriteFactory.Instance.CreateBlockSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            blockSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
