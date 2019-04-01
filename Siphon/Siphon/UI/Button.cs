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
	class Button : IDisplayable
	{
		// fields
		private Texture2D texture;
        private gameState state;
        private Stack<gameState> stack;
		private Rectangle rectangle;
		private bool mouseHover;

		// properties
		public Vector2 Position
		{
			get { return new Vector2(rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2)); }
		}
		public bool Active { get { return mouseHover; } }

		/// <summary>
		/// When clicked, the button will change the game state
		/// </summary>
		/// <param name="texture">What the button looks like</param>
		/// <param name="rectangle">The area of the button</param>
		/// <param name="state">The game state that clicking the button will summon (Back will take them to the last game state they were in)</param>
		/// <param name="stack">The Game1 stach that is used in the finite state machine</param>
		public Button(Texture2D texture, Rectangle rectangle, gameState state, Stack<gameState> stack)
        {
			this.texture = texture;
            this.state = state;
            this.stack = stack;
			this.rectangle = rectangle;
			mouseHover = false;
        }

		// methods

		// Draws the button and checks for hover 
		public void Draw(SpriteBatch sp)
		{
			if (mouseHover)
				sp.Draw(texture, rectangle, Color.DimGray);

			else
				sp.Draw(texture, rectangle, Color.White);
		}

        // 

        /// <summary>
        /// Handles hover effect and changes the game state if clicked
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns>True when the button is clicked for the first time, false otherwise</returns>
        public bool Update(MouseState mouse)
        {
            if (rectangle.Contains(mouse.Position))
			{
				mouseHover = true;

				if (mouse.LeftButton == ButtonState.Pressed)
				{
					if (state == gameState.Back)
					{
						stack.Pop();
					}
					else
					{
						stack.Push(state);
                        return true;
					}
				}
			}
			else
			{
				mouseHover = false;
			}
            return false;
        }
	}
}
