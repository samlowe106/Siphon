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

        public StarterEnemy(Vector2 position, Texture2D texture, Texture2D healthBarTexture, MainStructure mainStructure, List<Structure> structures)
            : base(position, texture, 32, new Vector2(1 , 1), mainStructure, 4f, structures)
        {
            // Set this enemy to do one damage per hit
            this.damage = 1;
            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            this.speed *= 2; //value for starter Enemy

			healthBar = new HealthBar(new Rectangle(), healthBarTexture);
        }

		#region Methods

		public override void Draw(SpriteBatch sp)
		{
			base.Draw(sp);
			int dimension = rectangle.Width;
			healthBar.Draw(sp, (int)maxHealth, (int)currentHealth, new Rectangle((int)position.X - dimension / 2, (int)position.Y - dimension / 2, dimension, dimension / 4));
		}

		#endregion
	}
}
