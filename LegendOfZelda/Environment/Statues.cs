using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Statues : IBlock
    {
        private ISprite statueSprite;
        private SpriteBatch sB;
        private Point position;
        public Statues(SpriteBatch spriteBatch, Point position)
        {
            statueSprite = EnvironmentSpriteFactory.Instance.CreateStatueSprite();
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
