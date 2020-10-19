using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class LadderTile : IBlock
    {
        private IItemSprite ladderSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public LadderTile(SpriteBatch spriteBatch, Point position)
        {
            ladderSprite = SpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
            this.position = position;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            ladderSprite.Draw(sB, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return ladderSprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // condition here to despawn
        }
    }
}
