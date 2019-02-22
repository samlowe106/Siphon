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
    /// <summary>
    /// The GameObject player-character which the player will control
    /// </summary>
	class Player : GameObject
	{
        // fields
        
        public Player(Vector2 position, Texture2D texture, int x, int y, int width, int height)
            : base(position, texture, x, y, width, height)
        {


        }

        
	}
}
