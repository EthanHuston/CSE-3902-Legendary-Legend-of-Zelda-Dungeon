using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class Statues : IBlock
    {
        private StatueSprite statueSprite;
        private SpriteBatch sB;
        private Point position;
        public Statues(SpriteBatch spriteBatch, Point Position)
        {
            statueSprite = (StatueSprite)SpriteFactory.Instance.CreateStatueSprite();
            sB = spriteBatch;
            this.position = position;
        }

        public void Draw()
        {
            statueSprite.Draw(sB, position);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
