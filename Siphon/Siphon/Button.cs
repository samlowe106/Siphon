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
	class Button : GameObject
	{
        // fields
        gameState state;
        Stack<gameState> stack;

        /// <summary>
        /// When clicked, the button will change the game state
        /// </summary>
        /// <param name="position">The center of the object</param>
        /// <param name="texture">What the button looks like</param>
        /// <param name="rectangle">The area of the button</param>
        /// <param name="state">The game state that clicking the button will summon (Back will take them to the last game state they were in)</param>
        public Button(Vector2 position, Texture2D texture, Rectangle rectangle, gameState state, Stack<gameState> stack) : base(position, texture, rectangle)
        {
            this.state = state;
            this.stack = stack;
        }

        // methods

        public void Update(Vector2 mousePosition)
        {
            if ()
        }
	}
}
