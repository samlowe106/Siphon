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
		private HealthBar healthBar;
        private int animationNum;

        public bool endGame;

		#region Constructor

		public MainStructure(Vector2 position, Texture2D texture, Texture2D groundTexture, Texture2D healthBarTexture, int dimension)
            : base(position, texture, dimension) // : base(new Vector2(X, Y), texture, NUMBER)
        {
            maxHealth = 100;
			currentHealth = maxHealth;
			this.groundTexture = groundTexture;

            endGame = false;
            animationNum = 0;

			healthBar = new HealthBar(new Rectangle((int)position.X - dimension / 2, (int)position.Y - dimension / 2, dimension, dimension / 8), healthBarTexture);
		}
		#endregion

		// This object's OnDeath event should trigger something to end the game

		#region Methods

		public override void Draw(SpriteBatch sp)
		{
            // ground tiles
			sp.Draw(groundTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width / 2, rectangle.Height / 2), Color.White);
			sp.Draw(groundTexture, new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y, rectangle.Width / 2, rectangle.Height / 2), Color.White);
			sp.Draw(groundTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height / 2, rectangle.Width / 2, rectangle.Height / 2), Color.White);
			sp.Draw(groundTexture, new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width / 2, rectangle.Height / 2), Color.White);

            if (active)
            {
                sp.Draw(texture, rectangle, new Rectangle(0, 0, 64, 64), Color.White);
                healthBar.Draw(sp, maxHealth, currentHealth);
            }
            else
            {
                if (animationNum < 10)
                {
                    sp.Draw(texture, rectangle, new Rectangle(64, 0, 64, 64), Color.White);
                }
                else if (animationNum < 20)
                {
                    sp.Draw(texture, rectangle, new Rectangle(128, 0, 64, 64), Color.White);
                }
                else if (animationNum < 30)
                {
                    sp.Draw(texture, rectangle, new Rectangle(0, 64, 64, 64), Color.White);
                }
                else if (animationNum < 40)
                {
                    sp.Draw(texture, rectangle, new Rectangle(64, 64, 64, 64), Color.White);
                }
                else if (animationNum < 50)
                {
                    sp.Draw(texture, rectangle, new Rectangle(128, 64, 64, 64), Color.White);
                }
                else if (animationNum < 60)
                {
                    sp.Draw(texture, rectangle, new Rectangle(0, 128, 64, 64), Color.White);
                }
                else if (animationNum < 70)
                {
                    sp.Draw(texture, rectangle, new Rectangle(64, 128, 64, 64), Color.White);
                }
                else if (animationNum < 80)
                {
                    sp.Draw(texture, rectangle, new Rectangle(128, 128, 64, 64), Color.White);
                }
                else if (animationNum < 90)
                {
                    sp.Draw(texture, rectangle, new Rectangle(192, 0, 64, 64), Color.White);
                }
                else if (animationNum < 100)
                {
                    endGame = true;
                }

                animationNum++;
            }
		}
        

		#endregion

	}
}
