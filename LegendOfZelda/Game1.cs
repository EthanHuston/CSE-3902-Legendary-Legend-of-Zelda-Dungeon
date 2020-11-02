using LegendOfZelda.GameState;
using LegendOfZelda.GameState.MainMenu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        public IGameState State { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = (int)Constants.GameSize.X,  // set this value to the desired width of your window
                PreferredBackBufferHeight = (int)Constants.GameSize.Y   // set this value to the desired height of your window
            };
            graphics.ApplyChanges();
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            SpriteFactory.Instance.LoadAllTextures(Content);
        }

        protected override void Initialize()
        {
            SetGameState(new MainMenuGameState(this), new OldInputState());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            State.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            State.Draw();
            SpriteBatch.End();
        }

        public void SetGameState(IGameState gameState, OldInputState oldInputState)
        {
            State = gameState;
            State.SetControllerOldInputState(oldInputState);
        }
    }
}
