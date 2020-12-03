using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class BlackBackground : IBackground
    {
        private readonly ISprite sprite;
        private readonly SpriteBatch sb;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BlackBackground(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateBlackBackgroundSprite();
            sb = spriteBatch;
            Position = position;
            SafeToDespawn = false;
        }
        
        public void Draw()
        {
            sprite.Draw(sb, position, Constants.DrawLayer.Background);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
        
        public void Update()
        {
            sprite.Update();
        }
    }
}
