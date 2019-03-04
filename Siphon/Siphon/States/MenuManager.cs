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
	class MenuManager
	{
		// fields
		private Button startButton;


		// constructor
		public MenuManager(Texture2D startButtonTexture, Stack<gameState> stack, int screenWidth, int screenHeight)
		{
			startButton = new Button(startButtonTexture,
										new Rectangle((int)(screenWidth * 0.2), 
										(int)(screenHeight * 0.1), 
										(int)(screenWidth * 0.6), 
										(int)(screenHeight * 0.2)), 
										gameState.Game, 
										stack);
		}

		// methods

		public void Update(MouseState mouse)
		{
			startButton.Update(mouse);
		}

		public void Draw(SpriteBatch sp)
		{
			startButton.Draw(sp);
		}
	}
}
