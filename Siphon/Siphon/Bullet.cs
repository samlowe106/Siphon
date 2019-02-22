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
	class Bullet : GameObject
	{
		public Bullet(Vector2 position, Texture2D texture, int x, int y, int width, int height) : base(position, texture, x, y, width, height)
		{

		}
	}
}
