using LegendOfZelda.GameLogic;
using LegendOfZelda.Link;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{

    class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        private List<IController> controllerList;

        public IGameState State { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                // TODO: make constants
                PreferredBackBufferWidth = (int) Constants.GameSize.X,  // set this value to the desired width of your window
                PreferredBackBufferHeight = (int) Constants.GameSize.Y   // set this value to the desired height of your window
            };
            graphics.ApplyChanges();
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            SpriteFactory.Instance.LoadAllTextures(Content);
        }

        public void ResetGame()
        {
        }

        protected override void Initialize()
        {
            State = new RoomGameState(this);

            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this) }
            };

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

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

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

        public IPlayer GetGamePlayer(int playerNumber)
        {
            return State.GetPlayer(playerNumber);
        }
    }
}
