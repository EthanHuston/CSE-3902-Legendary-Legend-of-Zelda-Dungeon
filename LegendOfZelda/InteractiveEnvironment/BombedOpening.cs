using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class BombedOpening : IInteractiveEnviornment
    {
        private DoorSprite doorSprite;
        private SpriteBatch sB;
        public BombedOpening(SpriteBatch spriteBatch)
        {
            doorSprite = (DoorSprite)SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY, 1, 4);
        }

        public void Interaction()
        {

        }

        public void Update()
        {
        }
    }
}
