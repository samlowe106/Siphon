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
        private Texture2D menuBackground;
        int screenWidth;
        int screenHeight;


		// constructor
		public MenuManager(Texture2D startButtonTexture, Texture2D exitButtonTexture, Stack<gameState> stack, int screenWidth, int screenHeight, Texture2D menuBackground)
		{
			startButton = new Button(startButtonTexture,
										new Rectangle((int)(screenWidth * 0.2), 
										(int)(screenHeight * 0.6), 
										(int)(screenWidth * 0.2), 
										(int)(screenHeight * 0.1)), 
										gameState.Game, 
										stack);
            exitButton = new Button(exitButtonTexture,
                                        new Rectangle((int)(screenWidth * 0.2),
                                        (int)(screenHeight * 0.8),
                                        (int)(screenWidth * 0.2),
                                        (int)(screenHeight * 0.1)),
                                        gameState.Back,
                                        stack);
            this.menuBackground = menuBackground;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
        }

		// methods


        /// <returns>
        /// True if the startbutton has been clicked to start a new game
        /// </returns>
		public bool Update(MouseState mouse)
		{
            exitButton.Update(mouse);
            return startButton.Update(mouse);
        }

		public void Draw(SpriteBatch sp)
		{
            sp.Draw(menuBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            startButton.Draw(sp);
			exitButton.Draw(sp);
		}
	}
}
