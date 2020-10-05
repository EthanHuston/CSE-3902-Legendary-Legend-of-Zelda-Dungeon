using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.InteractiveEnvironment
{
    class GapTile : IInteractiveEnviornment
    {
        private TileBlackSprite tileBlackSprite;
        private SpriteBatch sB;
        public GapTile(SpriteBatch spriteBatch)
        {
            tileBlackSprite = (TileBlackSprite)SpriteFactory.Instance.CreateTileBlackSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            tileBlackSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {

        }

        public void Update()
        {
            // No updates necessary
        }
    }
}
