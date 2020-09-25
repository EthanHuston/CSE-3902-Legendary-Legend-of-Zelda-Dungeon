using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public ISprite sprite;
        public ISprite textSprite;
        List<object> controllerList;
        KeyboardController keyboardController;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // TEST COMMENT FROM NATHAN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // UWU THANKS FOR THE BIG PP NATHAN ;););) -BIG PP CHRIS
            // big cringe moment - S.P.
            // im "git"ing sad right now, big tuff moment here - sadboi
            // crying tears of joy - we all committed
            textSprite = new NonMovingNonAnimatedTextSprite(this.Content);
            keyboardController = new KeyboardController(this);
            controllerList = new List<object>();
            controllerList.Add(keyboardController);
            controllerList.Add(new MouseController(this));
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SetStillSpriteCommand initialState = new SetStillSpriteCommand(this);
            initialState.Execute();
            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            foreach(IController controller in controllerList)
            {
                controller.Update();
            }

            sprite.Update();

            base.Update(gameTime);
        }

       
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            textSprite.Draw(SpriteBatch);
            sprite.Draw(SpriteBatch);

            // TODO: Add your drawing code here


            base.Draw(gameTime);

            
        }
    }
}
