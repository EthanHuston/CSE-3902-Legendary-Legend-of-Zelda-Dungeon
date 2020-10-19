using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class ShutDoor : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private Point position;
        private const int textureAtlasColumn = 1;
        private const int textureAtlasRow = 3;

        public ShutDoor(SpriteBatch spriteBatch, Point position)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            this.position = position;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, position, new Point(textureAtlasColumn, textureAtlasRow));
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
