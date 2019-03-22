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
    /// The main structure that the player must protect; if its health drops to zero, the game ends
    /// </summary>
    class MainStructure : Structure
    {
		private Texture2D groundTexture;



		#region Constructor

		public MainStructure(Vector2 position, Texture2D texture, Texture2D groundTexture, int dimension)
            : base(position, texture, dimension) // : base(new Vector2(X, Y), texture, NUMBER)
        {
            this.maxHealth = 2;
			this.groundTexture = groundTexture;
		}
		#endregion

		// This object's OnDeath event should trigger something to end the game

		#region Methods

		public override void Draw(SpriteBatch sp)
		{
			sp.Draw(groundTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width / 2, rectangle.Height / 2), Color.White);
			sp.Draw(groundTexture, new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y, rectangle.Width / 2, rectangle.Height / 2), Color.White);
			sp.Draw(groundTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height / 2, rectangle.Width / 2, rectangle.Height / 2), Color.White);
			sp.Draw(groundTexture, new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width / 2, rectangle.Height / 2), Color.White);


			sp.Draw(texture, rectangle, new Rectangle(0, 0, 64, 64), Color.White);
		}

		#endregion

	}
}
