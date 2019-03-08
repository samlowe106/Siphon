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
		private Button exitButton;


		// constructor
		public MenuManager(Texture2D startButtonTexture, Texture2D exitButtonTexture, Stack<gameState> stack, int screenWidth, int screenHeight)
		{
			startButton = new Button(startButtonTexture,
										new Rectangle((int)(screenWidth * 0.2), 
										(int)(screenHeight * 0.1), 
										(int)(screenWidth * 0.6), 
										(int)(screenHeight * 0.2)), 
										gameState.Game, 
										stack);
            exitButton = new Button(exitButtonTexture,
                                        new Rectangle((int)(screenWidth * 0.2),
                                        (int)(screenHeight * 0.6),
                                        (int)(screenWidth * 0.6),
                                        (int)(screenHeight * 0.2)),
                                        gameState.Back,
                                        stack);
        }

		// methods

		public void Update(MouseState mouse)
		{
			startButton.Update(mouse);
            exitButton.Update(mouse);
		}

		public void Draw(SpriteBatch sp)
		{
			startButton.Draw(sp);
			exitButton.Draw(sp);
		}
	}
}
