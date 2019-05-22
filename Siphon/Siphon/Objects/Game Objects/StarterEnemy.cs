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
    class StarterEnemy : Enemy
    {
		// health bar
		private HealthBar healthBar;

        public StarterEnemy(Vector2 position, Texture2D texture, Texture2D healthBarTexture, MainStructure mainStructure, List<Structure> structures, Player player, Bank bank, int screenHeight)
            : base(position, texture, screenHeight / 50, bank, new Vector2(1 , 1), mainStructure, 4f, structures, player)
        {
            // Set this enemy to do one damage per hit
            this.damage = 1;
            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            this.speed *= screenHeight / 250; //value for starter Enemy

			this.texture = texture;


			healthBar = new HealthBar(new Rectangle(), healthBarTexture);
        }


        

        #region Methods

        public override void Draw(SpriteBatch sp)
        {
            if(drawCounter <= .075f) //1st Frame
            {
                sp.Draw(texture, position, new Rectangle(0, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)),  new Vector2(16, 16), width / 32f, SpriteEffects.None, 1f);

            }
            else if(drawCounter > .075f && drawCounter <= .125f) //Second Frame 
            {
                sp.Draw(texture, position, new Rectangle(32, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), new Vector2(16, 16), width / 32f, SpriteEffects.None, 1f);

            }
            else if (drawCounter > .125f && drawCounter <= .2f) //Third Frame
            {
                sp.Draw(texture, position, new Rectangle(0, 32, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), new Vector2(16, 16), width / 32f, SpriteEffects.None, 1f);

            }
            else //4th and final frame. Reset done here
            {
                sp.Draw(texture, position, new Rectangle(32, 32, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), new Vector2(16, 16), width / 32f, SpriteEffects.None, 1f);

                drawCounter = 0f;
			}
            //Health Bars
			int dimension = rectangle.Width;
			healthBar.Draw(sp, (int)maxHealth, (int)currentHealth, new Rectangle((int)position.X - dimension / 2, (int)position.Y - dimension / 2, dimension, dimension / 4));
		}
        #endregion
    }
}
