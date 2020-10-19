using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class Statues : IBlock
    {
        private StatueSprite statueSprite;
        private SpriteBatch sB;
        private Point position;
        public Statues(SpriteBatch spriteBatch, Point position)
        {
            statueSprite = (StatueSprite)SpriteFactory.Instance.CreateStatueSprite();
            sB = spriteBatch;
            this.position = position;
        }

        public void Despawn()
        {
            throw new System.NotImplementedException();
        }

        public void Draw()
        {
            statueSprite.Draw(sB, position);
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
