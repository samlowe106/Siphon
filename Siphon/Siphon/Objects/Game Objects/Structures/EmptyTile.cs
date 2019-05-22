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
	class EmptyTile : Structure
	{
		private bool clear;
		private bool hover;
		private int rows;
		private int cols;
		private Map map;
        private Bank bank;

		public EmptyTile(Vector2 position, Texture2D texture, Bank bank,
			Map map, int rows, int cols, int dimensions, bool clear) : 
			base(position, texture, dimensions)
		{
			this.rows = rows;
			this.cols = cols;
			this.map = map;
			this.clear = clear;
            this.bank = bank;
			hover = false;
		}

		
		public void Update(List<Enemy> enemies, MouseState mouse, MouseState lastFrame, bool active, TurretType type)
		{
			if (active)
			{
				if (rectangle.Contains(mouse.Position))
				{
					hover = true;
					if ((mouse.LeftButton == ButtonState.Pressed) && (lastFrame.LeftButton != ButtonState.Pressed))
					{
						map.placeTurret(rows, cols, type);
					}
				}
				else
					hover = false;
			}
			else
			{
				hover = false;
			}
		}

		public override void Draw(SpriteBatch sp)
		{
			if (hover)
				sp.Draw(texture, rectangle, Color.Gray);
			else
				base.Draw(sp);
		}
	}
}
