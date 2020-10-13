using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class OldMan : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;

        public OldMan(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateOldManSprite();
            this.spriteBatch = spriteBatch;

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        }

        public void Update()
        {
        }

        public void ResetPosition()
        {

        }
    }
}
