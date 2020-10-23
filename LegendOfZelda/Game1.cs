using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        private List<IController> controllerList;

        public List<IPlayer> PlayerList { get; private set; }

        public IGameState State { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                // TODO: make constants
                PreferredBackBufferWidth = 256,  // set this value to the desired width of your window
                PreferredBackBufferHeight = 176   // set this value to the desired height of your window
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

            PlayerList = new List<IPlayer>()
            {
                // Change me -- choose a default spawn location in room
                {new LinkPlayer(this, new Point(50,50)) }
            };

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
            State.Draw();
        }

        public IPlayer GetGamePlayer(int playerNumber)
        {
            return PlayerList[playerNumber - 1];
        }
    }
}
