using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    class BoomerangWoodInventoryButton : IButton
    {
        private readonly ITextureAtlasSprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        public bool IsActive { get; private set; }

        private Vector2 Size => GameStateConstants.StandardItemSpriteSize;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BoomerangWoodInventoryButton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            sprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
            safeToDespawn = false;
            IsActive = true;
        }


        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, Position, GameStateConstants.BoomerangWoodTextureAtlasSource);
        }

        public Rectangle GetRectangle()
        {
            return !IsActive ?
                Rectangle.Empty :
                new Rectangle(Position.X, Position.Y, (int)(Size.X * Constants.GameScaler), (int)(Size.Y * Constants.GameScaler));
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void MakeActive()
        {
            IsActive = true;
        }

        public void MakeInactive()
        {
            IsActive = false;
        }
    }
}
