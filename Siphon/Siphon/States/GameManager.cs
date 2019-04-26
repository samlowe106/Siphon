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
		private bool paused;
		private SpriteFont Arial12;
        private Map map;
        private Bank bank;
        private BulletManager bulletManager;
		private EnemyManager enemyManager;
        private Texture2D gameBackground;
		private ToggleButton DestroyOrRepairButton;
		private ToggleButton wallTurret;
		private ToggleButton NextWave;
        private Button backButton;
        private UIElement BaseHud;
        private int screenHeight;
        private int screenWidth;
        private TextureManager textureManager;
        #endregion

        #region Constructor
        public GameManager(TextureManager textureManager,int screenWidth, int screenHeight, Stack<gameState> stack, SpriteFont Arial12)
		{
            this.textureManager = textureManager;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
			// base values
			paused = false;
			this.Arial12 = Arial12;

            // bank
            bank = new Bank();

            // map
            map = new Map(screenWidth, screenHeight, textureManager, stack, bank);

            // player
            player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), textureManager.playerModel, screenHeight / 20, screenHeight, screenWidth);

            // Enemy manager
            enemyManager = new EnemyManager(map, screenWidth, screenHeight, textureManager.plugEnemyModel, textureManager.healthBar, player, bank);

            // Bullet manager
            bulletManager = new BulletManager(textureManager.playerModel, screenWidth, screenHeight, enemyManager);

            // Player's pistol

            player.CurrentWeapon = new Pistol(textureManager.pistol, player, bulletManager);


            // buttons
            backButton = new Button(textureManager.backButtonTexture, new Rectangle(screenWidth * 4 / 10, screenHeight / 2, screenWidth / 5, 150), gameState.Back, stack);
			DestroyOrRepairButton = new ToggleButton(textureManager.repairDestroy, new Rectangle(0, (int)(screenHeight * 0.92), (int)(screenWidth * 0.16), (int)(screenHeight * 0.08)));
			wallTurret = new ToggleButton(textureManager.repairDestroy, new Rectangle((int)(screenWidth * 0.4), (int)(screenHeight * 0.9), (int)(screenWidth * 0.2), (int)(screenHeight * 0.1)));
			NextWave = new ToggleButton(textureManager.NextWave, new Rectangle((int)(screenWidth * 0.8), (int)(screenHeight * 0.9), (int)(screenWidth * 0.2), (int)(screenHeight * 0.1)));

            // ui
            BaseHud = new UIElement(textureManager.GameUI, new Rectangle(0, 0, screenWidth, screenHeight));

            this.gameBackground = textureManager.gameBackground;
            //Enemy Textures
            //Enemy test

		}
        #endregion
		
        #region Methods
        public void Update(GameTime gameTime, KeyboardState kbState, KeyboardState lastKbState,
            MouseState previousMouseState, MouseState currentMouseState)
		{
			// always runs
			bool repair = DestroyOrRepairButton.Update(currentMouseState, previousMouseState);

            TurretType type;
            if (wallTurret.Update(currentMouseState, previousMouseState))
            {
                type = TurretType.Wall;
            }
            else
            {
                type = TurretType.Turret;
            }


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
                map.Update(enemyManager.ActiveEnemies, currentMouseState, previousMouseState, enemyManager.StageClear, gameTime, repair, type); 
                
                bulletManager.Update();

                if (map.mainStructure.Active)
                {
                    enemyManager.Update(gameTime);
                    player.Update(kbState, currentMouseState, previousMouseState, enemyManager.StageClear);
                }
                    

                if (kbState.IsKeyDown(Keys.Escape) && lastKbState.IsKeyUp(Keys.Escape))
                {
                    paused = !paused;
                }
			}
			// runs when paused
			else
			{
                // TODO pause menu

                backButton.Update(currentMouseState);

                if (kbState.IsKeyDown(Keys.Escape) && lastKbState.IsKeyUp(Keys.Escape))
					paused = !paused;
			}
			
		}

		public void Draw(SpriteBatch sp)
		{
            sp.Draw(gameBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
			map.Draw(sp);

            // Draw the UI
            BaseHud.Draw(sp);
            NextWave.Draw(sp);

            // Draw how much time until next wave spawns
            // If the next wave is close to spawning, make the text flash red
            if (enemyManager.TimeUntilNextWave < 6 && (int)enemyManager.TimeUntilNextWave % 2 == 1)
            {
                sp.DrawString(Arial12, enemyManager.TimeUntilNextWave.ToString(), new Vector2(screenWidth * 189 / 200, screenHeight / 10), Color.Red);
            }
            else
            {
                sp.DrawString(Arial12, enemyManager.TimeUntilNextWave.ToString(), new Vector2(screenWidth * 189 / 200, screenHeight / 10), Color.White);
            }

            // Draw the current wave number, ensuring that single-digit waves and double-digit numbers are disaplayed properly
            if (enemyManager.WaveNumber < 10)
            {
                sp.DrawString(Arial12, enemyManager.WaveNumber.ToString(), new Vector2(screenWidth / 27, (screenHeight / 11) + 5), Color.Red);
            }
            else
            {
                sp.DrawString(Arial12, enemyManager.WaveNumber.ToString(), new Vector2(screenWidth / 33, (screenHeight / 11) + 5), Color.Red);
            }


            // draw the bank balance
            sp.DrawString(Arial12, bank.money.ToString(), new Vector2(screenWidth / 2 + 20, screenHeight / 20), Color.Black);
            sp.DrawString(Arial12, "Balance: ", new Vector2(screenWidth / 2, screenHeight / 50), Color.Black);

            // Draw the battery's health
            // In green if it's above 50%
            if (map.mainStructure.CurrentHealth > 50)
            {
                sp.DrawString(Arial12, String.Format("{0}%", map.mainStructure.CurrentHealth), new Vector2(screenWidth / 2.2f, screenHeight / 20), Color.DarkGreen);
            }
            // In yellow if between 50 and 25
            else if (map.mainStructure.CurrentHealth > 25)
            {
                sp.DrawString(Arial12, String.Format("{0}%", map.mainStructure.CurrentHealth), new Vector2(screenWidth / 2.2f, screenHeight / 20), Color.Yellow);
            }
            // In red if below 25%
            else
            {
                sp.DrawString(Arial12, String.Format("{0}%", map.mainStructure.CurrentHealth), new Vector2(screenWidth / 2.2f, screenHeight / 20), Color.Red);
            }

            sp.DrawString(Arial12, enemyManager.WaveNumber.ToString(), new Vector2(screenWidth * 3 / 4 , screenHeight / 20), Color.Black);

            // Draw Player
            player.Draw(sp);

            // Draw Buttons
			DestroyOrRepairButton.DrawSwitch(sp);
            wallTurret.DrawSwitch(sp);
            enemyManager.Draw(sp);
            bulletManager.Draw(sp);

            // Draws the pause menu (but only when paused)
            if (paused)
			{
                // Background
                sp.Draw(textureManager.menuBackground, new Rectangle(screenWidth / 3, screenHeight / 3, screenWidth / 3, screenHeight / 3), Color.White);
                // Menu title
                sp.DrawString(Arial12, "Paused", new Vector2(screenWidth / 2 - 75, screenHeight / 2 - 40), Color.White);
                // Back button
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
