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

		public GameManager(Texture2D playerTexture, int screenWidth, int screenHeight)
		{
			//player
			
			player = new Player(new Vector2(screenWidth * 0.5f, screenHeight * 0.5f), playerTexture, 30, 30, 30, 30);
		}

		public void Update(KeyboardState kbState, MouseState mouse)
		{
			player.PlayerMovement(kbState);
            player.SetAngle(mouse.X, mouse.Y);
		}

		public void Draw(SpriteBatch sp)
		{
			player.Draw(sp);
		}
	}
}
