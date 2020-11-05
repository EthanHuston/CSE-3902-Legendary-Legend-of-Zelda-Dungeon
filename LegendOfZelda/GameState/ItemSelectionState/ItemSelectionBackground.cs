using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionBackground : ISpawnable
    {
        private bool safeToDespawn;
        private readonly ISprite itemSelectionBackgroundSprite;
        private readonly SpriteBatch spriteBatch;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public ItemSelectionBackground(SpriteBatch spriteBatch)
        {
            itemSelectionBackgroundSprite = GameStateSpriteFactory.Instance.CreateItemSelectionBackgroundSprite();
            Position = Point.Zero;
            this.spriteBatch = spriteBatch;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            itemSelectionBackgroundSprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0,0, itemSelectionBackgroundSprite.GetPositionRectangle().Width, itemSelectionBackgroundSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            itemSelectionBackgroundSprite.Update();
        }
    }
}
