using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda
{
    class ShutDoor : IBlock
    {
        private DoorSprite doorSprite;
        private SpriteBatch sB;
        public ShutDoor(SpriteBatch spriteBatch)
        {
            doorSprite = (DoorSprite)SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY, 1, 3);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
