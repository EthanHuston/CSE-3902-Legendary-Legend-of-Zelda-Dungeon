using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Merchant : INpc
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
