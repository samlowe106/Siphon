using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siphon
{
    enum gameState
    {
        Menu,
        Game,
        Options
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Stack<gameState> state;
        Rectangle startButton;
        Rectangle optionsButton;
        Rectangle exitButton;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Full Screen
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            //intializing the buttons
            startButton = new Rectangle(GraphicsDevice.Viewport.Width*0.1, GraphicsDevice.Viewport.Height * 0.1, GraphicsDevice.Viewport.Width*0.8, GraphicsDevice.Viewport.Height*0.2);
            optionsButton = new Rectangle(GraphicsDevice.Viewport.Width*0.1, GraphicsDevice.Viewport.Height * 0.4, GraphicsDevice.Viewport.Width*0.8, GraphicsDevice.Viewport.Height*0.2);
            exitButton = new Rectangle(GraphicsDevice.Viewport.Width*0.1, GraphicsDevice.Viewport.Height * 0.7, GraphicsDevice.Viewport.Width*0.8, GraphicsDevice.Viewport.Height*0.2);

            state.Push(gameState.Menu);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            switch (state.Peek())
            {
                case gameState.Menu:
                    break;
                case gameState.Game:
                    break;
                case gameState.Options:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            // finite state machine for draw
            switch (state.Peek())
            {
                case gameState.Menu:
                    spriteBatch.Draw(startButton);
                    spriteBatch.Draw(optionsButton);
                    spriteBatch.Draw(exitButton);
                    break;
                case gameState.Game:
                    break;
                case gameState.Options:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
