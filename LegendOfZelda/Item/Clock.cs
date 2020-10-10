using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class Clock : IItem
    {
        private ClockSprite clockSprite;
        private SpriteBatch sb;
        public Clock(SpriteBatch spriteBatch)
        {
            clockSprite = (ClockSprite)SpriteFactory.Instance.CreateClockSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            clockSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}
