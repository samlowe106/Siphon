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
		private Button backButton;
        private int waveCount = 1;
		private bool paused;
		private SpriteFont Arial12;
        private Map map;
        private EnemyManager enemyManager;        private List<Enemy> enemies= new List<Enemy>();
        private BulletManager bulletManager;
        private Texture2D plugEnemyModel;
		private EnemyManager enemyManager;
		
        #endregion

        #region Constructor
        public GameManager(Texture2D playerTexture, Texture2D backButtonTexture, Texture2D turretTexture, Texture2D Battery,
            Texture2D bulletTexture, Texture2D groundTexture, int screenWidth, int screenHeight, Stack<gameState> stack,
            SpriteFont Arial12)
		{
			// base values
			paused = false;
			this.Arial12 = Arial12;

            // map
            map = new Map(screenWidth, screenHeight, Battery, turretTexture, bulletTexture, groundTexture, stack);

            // Enemy manager
            enemyManager = new EnemyManager(playerTexture, map, screenWidth, screenHeight, plugEnemyModel);

            // Bullet manager
            bulletManager = new BulletManager(bulletTexture, screenWidth, screenHeight, enemyManager);

            // player
            player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30);
            // Player's pistol
            player.CurrentWeapon = new Pistol(bulletTexture, player, bulletManager);

			// button
			backButton = new Button(backButtonTexture, new Rectangle(10, 10, 50, 30), gameState.Back, stack);

            //Enemy Textures
            //Enemy test
            
            enemyManager.BeginNextWave();

		}
        #endregion

        #region Methods
        public void Update(KeyboardState kbState, KeyboardState lastKbState,
            MouseState previousMouseState, MouseState currentMouseState, GameTime gameTime)
		{
			// runs when not paused
			if (!paused)
			{
				// map update
                map.Update(enemies, currentMouseState, previousMouseState, true, gameTime); 

                //Player Updates
                player.Update(kbState, currentMouseState, previousMouseState);

                enemyManager.Update();

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

			// always runs
			backButton.Update(currentMouseState);
		}

		public void Draw(SpriteBatch sp)
		{
			map.Draw(sp);
			player.Draw(sp);
			backButton.Draw(sp);
            enemyManager.Draw(sp);
           

            //draws when paused
            if (paused)
			{
				// TODO pause menu
				sp.DrawString(Arial12, "Paused", new Vector2(50, 500), Color.Black);
			}
		}
        #endregion
    }
}
