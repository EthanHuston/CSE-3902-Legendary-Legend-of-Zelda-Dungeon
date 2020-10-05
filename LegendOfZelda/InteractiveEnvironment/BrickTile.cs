using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class BrickTile : IInteractiveEnviornment
    {
        private BrickTileSprite brickTileSprite;
        private SpriteBatch sB;
        public BrickTile(SpriteBatch spriteBatch)
        {
            brickTileSprite = (BrickTileSprite)SpriteFactory.Instance.CreateBrickTileSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            brickTileSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {
            
        }
        public void Update()
        {
        }
    }
}
