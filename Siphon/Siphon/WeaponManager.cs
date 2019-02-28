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
	class WeaponManager
	{
		// fields
		private Weapon[] weapons;
		private int activeWeapon;

		public WeaponManager()
		{
			weapons = new Weapon[3];
			activeWeapon = 0;
		}

		// methods
		public void Shoot()
		{
			weapons[activeWeapon].Shoot();
		}

		public void Update(KeyboardState kbState)
		{
			if (kbState.IsKeyDown(Keys.D1))
				activeWeapon = 0;
			else if (kbState.IsKeyDown(Keys.D2))
				activeWeapon = 1;
			else if (kbState.IsKeyDown(Keys.D3))
				activeWeapon = 2;
			
			weapons[activeWeapon].Update();
		}

		public void Draw(SpriteBatch sp)
		{
			weapons[activeWeapon].Draw(sp);
		}
	}
}
