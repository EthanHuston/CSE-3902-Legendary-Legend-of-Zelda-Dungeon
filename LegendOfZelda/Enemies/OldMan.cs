using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class OldMan : INpc
    {
        private IItemSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private bool itemIsExpired;

        public OldMan(SpriteBatch spriteBatch, Point spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateOldManSprite();
            this.spriteBatch = spriteBatch;
            position = spawnPosition;

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            // TODO: implement me
        }

        public void ResetPosition()
        {

        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public void SetPosition(Point position)
        {
            this.position = position;
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            throw new System.NotImplementedException();
        }
    }
}
