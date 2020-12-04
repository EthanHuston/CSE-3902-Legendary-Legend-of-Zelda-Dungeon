using LegendOfZelda.GameState;
using LegendOfZelda.GameState.MainMenuState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public int NumPlayers { get; set; }
        public IGameState State { get; set; }

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

            NumPlayers = 2;

            SpriteFactory.Instance.LoadAllTextures(Content);
            SoundFactory.Instance.LoadAllSounds(Content);
        }

        protected override void Initialize()
        {
            State = new MainMenuGameState(this);
            State.StateEntryProcedure();
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
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(SpriteSortMode.FrontToBack, blendState: null, SamplerState.PointClamp);
            State.Draw();
            SpriteBatch.End();
        }
    }
}
