using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Rooms;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        List<object> controllerList;
        KeyboardController keyboardController;
        public Sprint2Game sprint2;
        private Room1 currentRoom;
        private List<IPlayer> playersList;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentRoom = null; // TODO: Initialize room
            playersList = new List<IPlayer>()
            {
                {new LinkPlayer(this, new Point(0,0)) }
            };
        }

        public void ResetGame()
        {
            sprint2 = new Sprint2Game(this);
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController(this);
            controllerList = new List<object>();
            controllerList.Add(keyboardController);
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAllTextures(Content);

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

        }

        public Room1 GetCurrentRoom()
        {
            return currentRoom;
        }

        public IPlayer GetGamePlayer(int playerNumber)
        {
            return playersList[playerNumber - 1];
        }
    }
}
