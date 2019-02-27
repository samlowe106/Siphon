﻿using Microsoft.Xna.Framework;
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
        Options,
        Back
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Stack<gameState> state;

		// inputs
		KeyboardState kbState;
		MouseState mState;

		// states
		MenuManager menu;
		GameManager gameManager;

		// screen data
		int screenWidth;
		int screenHeight;

		// textures
		Texture2D startButtonTexture;
		Texture2D backButtonTexture;
        Texture2D arrow;

        //Player
        Player player;
        Vector2 playerPos;
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
            //graphics.IsFullScreen = true; This line toggles if its full screen or not.
            graphics.ApplyChanges();
			IsMouseVisible = true;

			// screen elements
			screenHeight = GraphicsDevice.Viewport.Height;
			screenWidth = GraphicsDevice.Viewport.Width;
			
			// load menu content
			startButtonTexture = Content.Load<Texture2D>("start");
			backButtonTexture = Content.Load<Texture2D>("back");
			arrow = Content.Load<Texture2D>("Arrow");

			// states
			state = new Stack<gameState>();
			state.Push(gameState.Menu);
			menu = new MenuManager(startButtonTexture, state, screenWidth, screenHeight);
			gameManager = new GameManager(arrow, backButtonTexture, screenWidth, screenHeight, state);
			
            
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
			mState = Mouse.GetState();
			kbState = Keyboard.GetState();

            switch (state.Peek())
            {
                case gameState.Menu:
					menu.Update(mState);
                    break;
                case gameState.Game:
					gameManager.Update(kbState, mState);
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
					menu.Draw(spriteBatch);
                    break;
                case gameState.Game:
					gameManager.Draw(spriteBatch);
                    break;
                case gameState.Options:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
