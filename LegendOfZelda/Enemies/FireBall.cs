using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class Fireball : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int vx, vy;
        private Point position;

        public Fireball(SpriteBatch spriteBatch, int posX, int posY, int vy)
        {
            this.spriteBatch = spriteBatch;
            sprite = SpriteFactory.Instance.CreateFireballSprite();
            position.X = posX;
            position.Y = posY;
            this.vy = vy;
            this.vx = -5;
        }

        public void Update()
        {
            position.X += vx;
            position.Y += vy;
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }
        public void ResetPosition()
        {

        }
        public void Move(Vector2 distance)
        {

        }
        public void SetPosition(Point position)
        {
        }
        public bool SafeToDespawn()
        {
            //TODO: not implemented
            return false;
        }
        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            //Not implemented yet.
            return new Rectangle();
        }
    }
}
