using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Siphon
{
    enum mapData
    {
        empty,
        turret,
        mainBase
    }

	class GameManager
	{
        #region Fields
        private Player player;
        private int waveCount = 1;
		private bool paused;
		private SpriteFont Arial12;
        private Map map;
        private BulletManager bulletManager;
		private EnemyManager enemyManager;

		private ToggleButton DestroyOrRepairButton;
		private ToggleButton NextWave;
        private Button backButton;
        private UIElement BaseHud;
        #endregion

        #region Constructor
        public GameManager(Texture2D playerTexture, Texture2D backButtonTexture, Texture2D turretTexture, Texture2D Battery,
            Texture2D bulletTexture, Texture2D groundTexture, Texture2D healthBar, int screenWidth, int screenHeight, Stack<gameState> stack,
            SpriteFont Arial12, Texture2D starterEnemyTexture, Texture2D repairdestroy, Texture2D GameUI)
		{
			// base values
			paused = false;
			this.Arial12 = Arial12;

            // map
            map = new Map(screenWidth, screenHeight, Battery, turretTexture, bulletTexture, groundTexture, healthBar, stack);

            // Enemy manager
            enemyManager = new EnemyManager(playerTexture, map, screenWidth, screenHeight, starterEnemyTexture, healthBar);

            // Bullet manager
            bulletManager = new BulletManager(bulletTexture, screenWidth, screenHeight, enemyManager);

            // player
            player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30);
            // Player's pistol
            player.CurrentWeapon = new Pistol(bulletTexture, player, bulletManager);

			// button
			backButton = new Button(backButtonTexture, new Rectangle(screenWidth / 2 - 50, screenHeight / 3, 100, 50), gameState.Back, stack);
			DestroyOrRepairButton = new ToggleButton(repairdestroy, new Rectangle((int)(screenWidth * 0.6), 10, (int)(screenWidth * 0.2), (int)(screenHeight * 0.09)));
			NextWave = new ToggleButton(repairdestroy, new Rectangle((int)(screenWidth * 0.8), 10, (int)(screenWidth * 0.2), (int)(screenHeight * 0.09)));

            // ui
            BaseHud = new UIElement(GameUI, new Rectangle(0, 0, screenWidth, screenHeight));

            //Enemy Textures
            //Enemy test

		}
        #endregion

        #region Methods
        public void Update(GameTime gameTime, KeyboardState kbState, KeyboardState lastKbState,
            MouseState previousMouseState, MouseState currentMouseState)
		{
			// always runs
			backButton.Update(currentMouseState);
			bool repair = DestroyOrRepairButton.Update(currentMouseState, previousMouseState);

            // next wave logic
            if (NextWave.Update(currentMouseState, previousMouseState))
            {
                NextWave.active = false;
                enemyManager.BeginNextWave();
            }

			// Time that the first wave begins
			if (gameTime.ElapsedGameTime == TimeSpan.Zero)
            {
                enemyManager.BeginNextWave();
            }

            // runs when not paused
            if (!paused)
			{
				// map update
                map.Update(enemyManager.ActiveEnemies, currentMouseState, previousMouseState, true, gameTime, repair); 

                //Player Updates
                player.Update(kbState, currentMouseState, previousMouseState);

                bulletManager.Update();

                enemyManager.Update(gameTime);

                if (kbState.IsKeyDown(Keys.Escape) && lastKbState.IsKeyUp(Keys.Escape))
					paused = !paused;
			}
			// runs when paused
			else
			{
				// TODO pause menu

				if (kbState.IsKeyDown(Keys.Escape) && lastKbState.IsKeyUp(Keys.Escape))
					paused = !paused;
			}
			
		}

		public void Draw(SpriteBatch sp)
		{
			map.Draw(sp);

            // ui
            BaseHud.Draw(sp);
            NextWave.Draw(sp);

            //player.Draw(sp);
            player.Draw(sp);

            // buttons
			DestroyOrRepairButton.DrawSwitch(sp);
            enemyManager.Draw(sp);
            bulletManager.Draw(sp);

            //draws when paused
            if (paused)
			{
				// TODO pause menu
				sp.DrawString(Arial12, "Paused", new Vector2(50, 500), Color.Black);
                backButton.Draw(sp);
            }
		}

        public void Reset()
        {
            
        }
        #endregion

        #region Properties

        /// <summary>
        /// Manages enemies and waves
        /// </summary>
        public EnemyManager EnemyManager
        {
            get
            {
                return enemyManager;
            }
        }

        #endregion
    }
}
