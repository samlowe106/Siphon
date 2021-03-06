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
        EndGame,
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
		KeyboardState lastKbState;
		MouseState mState;
        MouseState lastMState;

		// states
		MenuManager menu;
		GameManager gameManager;

		// screen data
		int screenWidth;
		int screenHeight;

		// textures
		TextureManager textureManager;

		/*
		Texture2D startButtonTexture;
		Texture2D backButtonTexture;
        Texture2D arrow;
        Texture2D turret;
        Texture2D bullet;
        Texture2D playerModel;
        Texture2D plugEnemyModel;
        Texture2D groundTexture;
        Texture2D batteryTexture;
        Texture2D healthBar;
        Texture2D repairDestroy;
        Texture2D GameUI;
        Texture2D menuBackground;
        Texture2D gameBackground;
        Texture2D NextWave;
        Texture2D instructions;
		*/

        // sprite fonts 
        SpriteFont Arial12;
		
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
            //graphics.IsFullScreen = true; 
            graphics.ApplyChanges();
			IsMouseVisible = true;

			// screen elements
			screenHeight = GraphicsDevice.Viewport.Height;
			screenWidth = GraphicsDevice.Viewport.Width;
			
			// load fonts
			Arial12 = Content.Load<SpriteFont>("Arial12");

            // load textures content
            /*
			startButtonTexture = Content.Load<Texture2D>("start");
			backButtonTexture = Content.Load<Texture2D>("back");
			arrow = Content.Load<Texture2D>("Arrow"); //Test Player Model
            playerModel = Content.Load<Texture2D>("Player"); //Player Model
			turret = Content.Load<Texture2D>("Turret");
			bullet = Content.Load<Texture2D>("bullet");
            plugEnemyModel = Content.Load<Texture2D>("Plug Enemy");
			groundTexture = Content.Load<Texture2D>("ground");
			batteryTexture = Content.Load<Texture2D>("Battery");
			healthBar = Content.Load<Texture2D>("healthBar");
			repairDestroy = Content.Load<Texture2D>("repairdestroy");
			GameUI = Content.Load<Texture2D>("GameUI");
            menuBackground = Content.Load<Texture2D>("menuBackground");
            NextWave = Content.Load<Texture2D>("NextWave");
            instructions = Content.Load<Texture2D>("instructions");
            gameBackground = Content.Load < Texture2D>("gameBackground");
			*/

            textureManager = new TextureManager(
                Content.Load<Texture2D>("start"),
                Content.Load<Texture2D>("back"),
                Content.Load<Texture2D>("Arrow"),
                Content.Load<Texture2D>("Turret"),
                Content.Load<Texture2D>("bullet"),
                Content.Load<Texture2D>("Player"),
                Content.Load<Texture2D>("Plug Enemy"),
                Content.Load<Texture2D>("ground"),
                Content.Load<Texture2D>("Battery"),
                Content.Load<Texture2D>("healthBar"),
                Content.Load<Texture2D>("repairdestroyACTUAL"),
                Content.Load<Texture2D>("GameUI"),
                Content.Load<Texture2D>("menuBackground"),
                Content.Load<Texture2D>("gameBackground"),
                Content.Load<Texture2D>("NextWaveACTUAL"),
                Content.Load<Texture2D>("instructions"),               
                Content.Load<Texture2D>("pistol"),
                Content.Load<Texture2D>("Selection"),
                Content.Load<Texture2D>("Wall"));


			// states
			state = new Stack<gameState>();
			state.Push(gameState.Back);
			state.Push(gameState.Menu);
			menu = new MenuManager(textureManager, state, screenWidth, screenHeight);
			gameManager = new GameManager(textureManager, screenWidth, screenHeight, state, Arial12);
            
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();

			// TODO: Add your update logic here
			mState = Mouse.GetState();
			kbState = Keyboard.GetState();

            switch (state.Peek())
            {
                case gameState.Menu:
                    menu.Update(mState);
                    break;
                case gameState.Game:
					gameManager.Update(gameTime, kbState, lastKbState, lastMState, mState);
                    break;
                case gameState.EndGame:
                    {
						gameManager = new GameManager(textureManager, screenWidth, screenHeight, state, Arial12);
						state.Pop();
                        state.Pop();
                    }
                    break;
                case gameState.Options:
                    break;
                case gameState.Back:
                    this.Exit();
                    break;
            }

            base.Update(gameTime);

			lastKbState = kbState;
            lastMState = mState;
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
                default:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
