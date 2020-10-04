using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemies
{
    class Merchant : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        public Merchant(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateMerchantSprite();
            this.spriteBatch = spriteBatch;

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
