﻿using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        List<IController> controllerList;
        private Room1 currentRoom;
        private List<IPlayer> playersList;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); 
            graphics.PreferredBackBufferWidth = 256;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 176;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentRoom = null; // TODO: Initialize room
            playersList = new List<IPlayer>();
        }

        public void ResetGame()
        {
        }

        protected override void Initialize()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);

            controllerList = new List<IController>()
            {
                {new KeyboardController(this) }
            };

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            playersList.Add(new LinkPlayer(this, new Point(0, 0)));

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
