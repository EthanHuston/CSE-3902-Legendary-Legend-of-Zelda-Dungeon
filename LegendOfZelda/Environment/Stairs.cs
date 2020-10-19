using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Stairs : IBlock
    {
        private ISprite stairSprite;
        private SpriteBatch sB;
        private Point position;
        public Stairs(SpriteBatch spriteBatch, Point position)
        {
            stairSprite = EnvironmentSpriteFactory.Instance.CreateStairSprite();
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
