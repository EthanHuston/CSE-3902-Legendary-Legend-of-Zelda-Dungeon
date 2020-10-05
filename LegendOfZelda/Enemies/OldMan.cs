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

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, Sprint2.enemyNPCX, Sprint2.enemyNPCY);
        }

        public void Update()
        {
        }
    }
}
