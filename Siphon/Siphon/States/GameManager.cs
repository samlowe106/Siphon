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
		private bool paused;
		private SpriteFont Arial12;

        // map
        private mapData[][] map;

        // constructor
		public GameManager(Texture2D playerTexture, Texture2D backButtonTexture, int screenWidth, int screenHeight, Stack<gameState> stack, SpriteFont Arial12)
		{
			// base values
			paused = false;
			this.Arial12 = Arial12;

			// player
			player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30, 30, 30, 30);

			// button
			backButton = new Button(backButtonTexture, new Rectangle(10, 10, 50, 30), gameState.Back, stack);
		}

        // methods
		public void Update(KeyboardState kbState, KeyboardState lastKbState, MouseState mouse)
		{
			// runs when not paused
			if (!paused)
			{
				player.PlayerMovement(kbState);
				
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
			backButton.Update(mouse);
		}

		public void Draw(SpriteBatch sp)
		{
			player.Draw(sp);
			backButton.Draw(sp);

			// draws when paused
			if (paused)
			{
				// TODO pause menu
				sp.DrawString(Arial12, "Paused", new Vector2(50, 500), Color.Black);
			}
		}
	}
}
