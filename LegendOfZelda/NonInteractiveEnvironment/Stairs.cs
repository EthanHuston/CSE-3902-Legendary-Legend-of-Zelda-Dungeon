using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
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

        public void Draw()
        {
            stairSprite.Draw(sB, position);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
