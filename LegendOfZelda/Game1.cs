using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public IPlayer link;
        List<object> controllerList;
        KeyboardController keyboardController;
        public Sprint2 sprint2;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ResetGame()
        {
            sprint2 = new Sprint2(this);
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController(this);
            controllerList = new List<object>();
            controllerList.Add(keyboardController);
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAllTextures(this.Content);
            sprint2 = new Sprint2(this);
            link = new Link.LinkPlayer(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {   
            SpriteFactory.Instance.LoadAllTextures(this.Content);
            base.LoadContent();
            // TODO: use this.Content to load your game content here
            
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            foreach(IController controller in controllerList)
            {
                controller.Update();
            }

            link.Update();
            sprint2.Update();

            base.Update(gameTime);
        }

       
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            link.Draw();
            sprint2.Draw();
        }
    }
}
