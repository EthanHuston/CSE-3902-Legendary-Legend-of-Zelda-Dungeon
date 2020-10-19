using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class Stairs : IBlock
    {
        private StairSprite stairSprite;
        private SpriteBatch sB;
        private Point position;
        public Stairs(SpriteBatch spriteBatch, Point position)
        {
            stairSprite = (StairSprite)SpriteFactory.Instance.CreateStairSprite();
            sB = spriteBatch;
            this.position = position;
        }

        public void Despawn()
        {
            throw new System.NotImplementedException();
        }

        public void Draw()
        {
            stairSprite.Draw(sB, position);
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
