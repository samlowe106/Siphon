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
        Weapon currentWeapon;
        
        public Player(Vector2 position, Texture2D texture, int dimensions, BulletManager manager)
            : base(position, texture, dimensions, new Vector2(3, 3))
        {
            // The player's starting weapon will just be a pistol
            this.currentWeapon = new Pistol(manager);
        }

        /// <summary>
        /// Player Movement Method that will be called in the update method
        /// </summary>
        /// <param name="current">Current keyboard state to be tested</param>
        public void PlayerMovement(KeyboardState current)
        {
            if (current.IsKeyDown(Keys.W))
            {
                position = new Vector2(position.X, position.Y - speed.Y);
            }
            if (current.IsKeyDown(Keys.A))
            {
                position = new Vector2(position.X - speed.X, position.Y);
            }
            if (current.IsKeyDown(Keys.S))
            {
                position = new Vector2(position.X, position.Y + speed.Y);
            }
            if (current.IsKeyDown(Keys.D))
            {
                position = new Vector2(position.X + speed.X, position.Y);
            }
        }
	}
}
