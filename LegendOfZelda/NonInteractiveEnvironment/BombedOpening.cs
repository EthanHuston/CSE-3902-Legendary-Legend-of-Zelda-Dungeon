using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class BombedOpening : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private Point position;
        private const int textureMapRow = 1;
        private const int textureMapColumn = 4;

        public BombedOpening(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            position = spawnPosition;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public Point GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public Rectangle GetRectangle()
        {
            throw new System.NotImplementedException();
        }

        public void Interaction()
        {

        }

        public void Move(Vector2 distance)
        {
            throw new System.NotImplementedException();
        }

        public bool SafeToDespawn()
        {
            throw new System.NotImplementedException();
        }

        public void SetPosition(Point position)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
        }
    }
}
