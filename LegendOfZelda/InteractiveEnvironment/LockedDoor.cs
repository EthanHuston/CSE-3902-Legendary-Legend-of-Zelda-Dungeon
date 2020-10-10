using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class LockedDoor : IBlock
    {
        private DoorSprite doorSprite;
        private SpriteBatch sB;
        public LockedDoor(SpriteBatch spriteBatch)
        {
            doorSprite = (DoorSprite)SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY, 1, 2);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
