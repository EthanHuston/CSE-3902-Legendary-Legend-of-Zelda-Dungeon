using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    class BowInventoryButton : IButton
    {
        private readonly ITextureAtlasSprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        private bool isActive;

        private Vector2 Size => GameStateConstants.StandardItemSpriteSize;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BowInventoryButton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            sprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
            safeToDespawn = false;
            isActive = false;
        }


        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, Position, GameStateConstants.BowTextureAtlasLocation);
        }

        public Rectangle GetRectangle()
        {
            return !isActive ?
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
            isActive = true;
        }

        public void MakeInactive()
        {
            isActive = false;
        }
    }
}
