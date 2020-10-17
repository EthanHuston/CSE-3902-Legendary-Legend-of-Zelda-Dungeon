using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class LadderTile : IBlock
    {
        private LadderSprite ladderSprite;
        private SpriteBatch sB;
        private Point position;
        public LadderTile(SpriteBatch spriteBatch, Point position)
        {
            ladderSprite = (LadderSprite)SpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
            this.position = position;
        }

        public void Draw()
        {
            ladderSprite.Draw(sB, position);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}
