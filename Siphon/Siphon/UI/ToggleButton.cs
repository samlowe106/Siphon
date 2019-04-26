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
	class ToggleButton
	{
		// fields
		private Texture2D texture;
		public bool active;
		private Rectangle rectangle;
		private bool mouseHover;

		private int texWidth;
		private int texHeight;

		/// <summary>
		/// When clicked, the button will change the game state
		/// </summary>
		/// <param name="texture">What the button looks like</param>
		/// <param name="rectangle">The area of the button</param>
		/// <param name="state">The game state that clicking the button will summon (Back will take them to the last game state they were in)</param>
		/// <param name="stack">The Game1 stach that is used in the finite state machine</param>
		public ToggleButton(Texture2D texture, Rectangle rectangle)
		{
			this.texture = texture;
			this.rectangle = rectangle;
			mouseHover = false;
            active = false;

			texHeight = texture.Height;
			texWidth = texture.Width;
		}

		// methods

		// Draws the button and checks for hover 
		public void DrawSwitch(SpriteBatch sp)
		{
			if (!active)
			{
				if (mouseHover)
					sp.Draw(texture, rectangle, new Rectangle(0, 0, texWidth / 2, texHeight), Color.DimGray);
				else
					sp.Draw(texture, rectangle, new Rectangle(0, 0, texWidth / 2, texHeight), Color.White);
			}
			else
			{
				if (mouseHover)
					sp.Draw(texture, rectangle, new Rectangle(texWidth / 2, 0, texWidth / 2, texHeight), Color.DimGray);
				else
					sp.Draw(texture, rectangle, new Rectangle(texWidth / 2, 0, texWidth / 2, texHeight), Color.White);
			}
        }

        public void Draw(SpriteBatch sp)
        {
            if (mouseHover)
                sp.Draw(texture, rectangle, Color.DimGray);
            else
               sp.Draw(texture, rectangle, Color.White);
            
        }

        /// <summary>
        /// Handles hover effect and changes the game state if clicked
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns>True when the button is clicked for the first time, false otherwise</returns>
        public bool Update(MouseState mouse, MouseState last)
		{
			if (rectangle.Contains(mouse.Position))
			{
				mouseHover = true;

				if (mouse.LeftButton == ButtonState.Pressed && last.LeftButton != ButtonState.Pressed)
				{
					active = !active;
				}
			}
			else
			{
				mouseHover = false;
			}
			return active;
		}
	}
}
