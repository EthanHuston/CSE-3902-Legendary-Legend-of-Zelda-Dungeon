using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class OldMan : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;

        public OldMan(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateOldManSprite();
            this.spriteBatch = spriteBatch;
            position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
        }

        public void ResetPosition()
        {

        }
        public void Move(Vector2 distance)
        {

        }
        public void SetPosition(Point position)
        {
            this.position = position;
        }
        public bool SafeToDespawn()
        {
            return false;
        }
        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }
    }
}
