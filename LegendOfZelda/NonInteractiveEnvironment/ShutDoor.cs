using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class ShutDoor : IBlock
    {
        private DoorSprite doorSprite;
        private SpriteBatch sB;
        private Point position;
        public ShutDoor(SpriteBatch spriteBatch, Point position)
        {
            doorSprite = (DoorSprite)SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            this.position = position;
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
