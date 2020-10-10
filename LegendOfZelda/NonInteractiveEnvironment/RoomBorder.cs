using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class RoomBorder : IBlock
    {
        private RoomBorderSprite roomSprite;
        private SpriteBatch sb;
        int posX, posY;
        public RoomBorder(SpriteBatch spriteBatch, int x, int y)
        {
            roomSprite = (RoomBorderSprite)SpriteFactory.Instance.CreateRoomBorderSprite();
            sb = spriteBatch;
            posX = x;
            posY = y;
        }

        public void Draw()
        {
            roomSprite.Draw(sb, posX, posY);
        }
        public void Update()
        {
        }
    }
}
