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
	class HealthBar
	{
		// fields
		private Rectangle rectangle;
		private Texture2D texture;
		private Color color;

		// constructor
		public HealthBar(Rectangle rectangle, Texture2D texture)
		{
			this.rectangle = rectangle;
			this.texture = texture;

		}

		// methods
		public void Draw(SpriteBatch sp, int maxHealth, int currentHealth)
		{
			if (currentHealth > 0)
			{
				int g = (int)(((float)currentHealth / maxHealth) * 255);
				int r = (255 - g);
				color = new Color(r, g, 0);
				sp.Draw(texture, rectangle, color);
			}
		}

		public void Draw(SpriteBatch sp, int maxHealth, int currentHealth, Rectangle rectangle)
		{
			if (currentHealth > 0)
			{
				int g = (int)(((float)currentHealth / maxHealth) * 255);
				int r = (255 - g);
				color = new Color(r, g, 0);
				sp.Draw(texture, rectangle, color);
			}
		}
	}
}
