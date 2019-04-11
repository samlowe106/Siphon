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



            // player
            player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30);

            // Enemy manager
            enemyManager = new EnemyManager(playerTexture, map, screenWidth, screenHeight, starterEnemyTexture, healthBar, player);

            // Bullet manager
            bulletManager = new BulletManager(playerTexture, screenWidth, screenHeight, enemyManager);

            // Player's pistol

            player.CurrentWeapon = new Pistol(playerTexture, player, bulletManager);


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
                player.Update(kbState, currentMouseState, previousMouseState, enemyManager.StageClear);

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

            // Draw the UI
            BaseHud.Draw(sp);
            NextWave.Draw(sp);

            // Draw how much time until next wave spawns
            // If the next wave is close to spawning, make the text flash red
            if (enemyManager.TimeUntilNextWave < 6 && (int)enemyManager.TimeUntilNextWave % 2 == 1)
            {
                sp.DrawString(Arial12, enemyManager.TimeUntilNextWave.ToString(), new Vector2(115, 50), Color.Red);
            }
            else
            {
                sp.DrawString(Arial12, enemyManager.TimeUntilNextWave.ToString(), new Vector2(115, 50), Color.Black);
            }

            // Draw the current wave number
            sp.DrawString(Arial12, enemyManager.WaveNumber.ToString(), new Vector2(350, 50), Color.Black);

            // Draw the battery's health
            // In green if it's above 50%
            if (map.mainStructure.CurrentHealth > 50)
            {
                sp.DrawString(Arial12, String.Format("{0}%", map.mainStructure.CurrentHealth), new Vector2(515, 50), Color.DarkGreen);
            }
            // In yellow if between 50 and 25
            else if (map.mainStructure.CurrentHealth > 25)
            {
                sp.DrawString(Arial12, String.Format("{0}%", map.mainStructure.CurrentHealth), new Vector2(515, 50), Color.Yellow);
            }
            // In red if below 25%
            else
            {
                sp.DrawString(Arial12, String.Format("{0}%", map.mainStructure.CurrentHealth), new Vector2(515, 50), Color.Red);
            }
            
            // Draw Player
            player.Draw(sp);

            // Draw Buttons
			DestroyOrRepairButton.DrawSwitch(sp);
            enemyManager.Draw(sp);
            bulletManager.Draw(sp);

            // Draws the pause menu (but only when paused)
            if (paused)
			{
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
