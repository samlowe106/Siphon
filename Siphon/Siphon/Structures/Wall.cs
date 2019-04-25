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
	class Wall : Structure
	{
		// fields
		private HealthBar healthBar;
		private Bank bank;
		private Map map;
		private Texture2D groundTexture;

		private int row;
		private int col;

		// constructor
		public Wall(Vector2 position, Texture2D texture, Texture2D groundTexture, Texture2D healthBarTexture, Bank bank, Map map, int dimensions, int row, int col)
			: base(position, texture, dimensions)
		{
			this.bank = bank;
			this.map = map;

			this.row = row;
			this.col = col;

			maxHealth = 30;
			currentHealth = 30;
			healthBar = new HealthBar(new Rectangle((int)position.X - dimensions / 2, (int)position.Y - dimensions / 2, dimensions, dimensions / 4), healthBarTexture);
		}

		// methods

		public override void Draw(SpriteBatch sp)
		{
			sp.Draw(groundTexture, rectangle, Color.White);
			base.Draw(sp);
		}

		public void RepairOrDestroy(MouseState mouse, bool repair)
		{
			if (repair && (mouse.LeftButton == ButtonState.Pressed) && rectangle.Contains(mouse.Position))
			{
				if (bank.Purchase(25))
				{
					currentHealth = maxHealth;
					active = true;
				}
			}
			if (!repair && (mouse.LeftButton == ButtonState.Pressed) && rectangle.Contains(mouse.Position))
			{
				map.removeTurret(row, col);
				bank.Deposit(50);
			}
		}
	}
}
