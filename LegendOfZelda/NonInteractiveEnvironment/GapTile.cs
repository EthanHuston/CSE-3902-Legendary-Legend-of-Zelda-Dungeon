using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class GapTile : IBlock
    {
        private ISprite tileBlackSprite;
        private SpriteBatch sB;
        private Point position;

        public GapTile(SpriteBatch spriteBatch, Point spawnPosition)
        {
            tileBlackSprite = (TileBlackSprite)SpriteFactory.Instance.CreateTileBlackSprite();
            sB = spriteBatch;
            position = spawnPosition;
        }

        public void Draw()
        {
            tileBlackSprite.Draw(sB, position);
        }

        public void Interaction()
        {

        }

        public void Update()
        {
            // No updates necessary
        }

        void Move(Vector2 distance)
        {

        }
        void SetPosition(Point position)
        {

        }
        bool SafeToDespawn()
        {
            return false;
        }
        Point GetPosition()
        {
            return position;
        }
        Rectangle GetRectangle()
        {
            return tileBlackSprite.GetPositionRectangle();
        }
    }
}
