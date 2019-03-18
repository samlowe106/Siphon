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
		public bool clear;
		public bool hover;

		public EmptyTile(Vector2 position, Texture2D texture, int dimensions, bool clear) : base(position, texture, dimensions)
		{
			this.clear = clear;
			hover = false;
		}

		
		public void Update(List<Enemy> enemies, MouseState mouse)
		{
			if (rectangle.Contains(mouse.Position))
			{
				hover = true;
			}
			hover = false;
		}

		public override void Draw(SpriteBatch sp)
		{

			base.Draw(sp);
		}
	}
}
