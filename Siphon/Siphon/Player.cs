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
        
        public Player(Vector2 position, Texture2D texture, int x, int y, int width, int height, int screenWidth, int screenHeight)
            : base(position, texture, x, y, width, height, screenWidth, screenHeight)
        {

            
        }

        //Player Movement Method that will be called in the update method
        public void PlayerMovement(KeyboardState current)
        {
            if (current.IsKeyDown(Keys.W))
            {
                position = new Vector2(position.X, position.Y - 3);

            }
            if (current.IsKeyDown(Keys.A))
            {
                position = new Vector2(position.X - 3, position.Y);

            }
            if (current.IsKeyDown(Keys.S))
            {
                position = new Vector2(position.X, position.Y + 3);
            }
            if (current.IsKeyDown(Keys.D))
            {
                position = new Vector2(position.X + 3, position.Y);

            }
        }

		public override void Draw(SpriteBatch sp)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectComparedTo"></param>
		/// <returns></returns>
		public float SetAngle(int objX, int objY)
		{
			direction.X = objX - this.Position.X;
			direction.Y = objY - this.Position.Y;

			angle = (float)Math.Atan2(direction.Y, direction.X);
			return angle;
		}


	}
}
