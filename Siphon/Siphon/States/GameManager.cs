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
		// fields
		private Player player;
		private Button backButton;
        private int waveCount = 1;
		private bool paused;
		private SpriteFont Arial12;
        private Map map;
        private List<Enemy> enemies= new List<Enemy>();
        private BulletManager bulletManager;
        private Texture2D plugEnemyModel;
        // constructor
		public GameManager(Texture2D playerTexture, Texture2D backButtonTexture, Texture2D turretTexture,
            Texture2D bulletTexture, int screenWidth, int screenHeight, Stack<gameState> stack,
            SpriteFont Arial12)
		{
			// base values
			paused = false;
			this.Arial12 = Arial12;

            // map
            map = new Map(screenWidth, screenHeight, backButtonTexture, turretTexture, bulletTexture, stack);

            // Enemy manager
            EnemyManager enemyManager = new EnemyManager(playerTexture, map.mainStructure, screenWidth, screenHeight, plugEnemyModel);

            // Bullet manager
            bulletManager = new BulletManager(bulletTexture, screenWidth, screenHeight, enemyManager);

            // player
            player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30);
            // Player's pistol
            //player.CurrentWeapon = new Pistol(pistolTexture, player, bulletManager);

			// button
			backButton = new Button(backButtonTexture, new Rectangle(10, 10, 50, 30), gameState.Back, stack);

            //Enemy Textures
            //Enemy test
            enemies.Add(new StarterEnemy(new Vector2(0, 0), playerTexture, map.mainStructure));
            enemies.Add(new StarterEnemy(new Vector2(screenWidth / 2, 0), playerTexture, map.mainStructure));
            enemies.Add(new StarterEnemy(new Vector2(screenWidth, 0), playerTexture, map.mainStructure));
            enemies.Add(new StarterEnemy(new Vector2(0, screenHeight), playerTexture, map.mainStructure));
            enemies.Add(new StarterEnemy(new Vector2(screenWidth / 2, screenHeight), playerTexture, map.mainStructure));
            enemies.Add(new StarterEnemy(new Vector2(screenWidth, screenHeight), playerTexture, map.mainStructure));


		}

        // methods
		public void Update(KeyboardState kbState, KeyboardState lastKbState,
            MouseState previousMouseState, MouseState currentMouseState)
		{
			// runs when not paused
			if (!paused)
			{
                map.Update(enemies); 

                //Player Updates
                player.Update(kbState, currentMouseState, previousMouseState);
                

                //Enemey update
                for(int i = 0; i < enemies.Count; i++)
                {
                    if(enemies[i].Active == false)
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        enemies[i].Update();

                    }
                }

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
            
            
			//Enemeies Draw
            foreach (Enemy e in enemies)
            {
				e.Draw(sp);
            }

            //draws when paused
            if (paused)
			{
				// TODO pause menu
				sp.DrawString(Arial12, "Paused", new Vector2(50, 500), Color.Black);
			}
		}
	}
}
