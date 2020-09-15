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
        public SpriteBatch spriteBatch;
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
            textSprite = new NonMovingNonAnimatedTextSprite(this.Content);
            keyboardController = new KeyboardController(this);
            controllerList = new List<object>();
            controllerList.Add(keyboardController);
            controllerList.Add(new MouseController(this));
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Register Keyboard Commands
            keyboardController.RegisterCommand(Keys.NumPad0, new QuitGameCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad1, new SetStillSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad2, new SetWalkingStillSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad3, new SetDeadSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad4, new SetFullWalkingSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D0, new QuitGameCommand(this));
            keyboardController.RegisterCommand(Keys.D1, new SetStillSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D2, new SetWalkingStillSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D3, new SetDeadSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D4, new SetFullWalkingSpriteCommand(this));

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            textSprite.Draw(spriteBatch);
            sprite.Draw(spriteBatch);

            // TODO: Add your drawing code here


            base.Draw(gameTime);

            
        }
    }
}
