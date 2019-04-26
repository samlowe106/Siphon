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
        private UIElement instructions;
        int screenWidth;
        int screenHeight;


		// constructor
		public MenuManager(TextureManager textureManager,  Stack<gameState> stack, int screenWidth, int screenHeight)
		{
			startButton = new Button(textureManager.startButtonTexture,
										new Rectangle((int)(screenWidth * 0.2), 
										(int)(screenHeight * 0.8), 
										(int)(screenWidth * 0.2), 
										(int)(screenHeight * 0.1)), 
										gameState.Game, 
										stack);
            exitButton = new Button(textureManager.backButtonTexture,
                                        new Rectangle((int)(screenWidth * 0.6),
                                        (int)(screenHeight * 0.8),
                                        (int)(screenWidth * 0.2),
                                        (int)(screenHeight * 0.1)),
                                        gameState.Back,
                                        stack);

            instructions = new UIElement(textureManager.instructions, new Rectangle(
                                        (int)(screenWidth * 0.2),
                                        (int)(screenHeight * 0.4),
                                        (int)(screenWidth * 0.6),
                                        (int)(screenHeight * 0.3)));
            this.menuBackground = textureManager.menuBackground;
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

            instructions.Draw(sp);
            startButton.Draw(sp);
			exitButton.Draw(sp);
		}
	}
}
