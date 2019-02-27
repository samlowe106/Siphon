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
	class GameManager
	{
		// fields
		private Player player;
		private Button backButton;

		public GameManager(Texture2D playerTexture, Texture2D backButtonTexture, int screenWidth, int screenHeight, Stack<gameState> stack)
		{
			// player
			player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30, 30, 30, 30);

			// button
			backButton = new Button(backButtonTexture, new Rectangle(10, 10, 50, 30), gameState.Back, stack);
		}

		public void Update(KeyboardState kbState, MouseState mouse)
		{
			backButton.Update(mouse);
			player.PlayerMovement(kbState);
		}

		public void Draw(SpriteBatch sp)
		{
			
			player.Draw(sp);
			
			backButton.Draw(sp);
		}
	}
}
