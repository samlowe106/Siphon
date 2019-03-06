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
    /// Basic starter pistol weapon
    /// </summary>
	class Pistol : Weapon
	{
        public Pistol(Texture2D texture, Player holder, BulletManager manager)
            : base(texture, holder, manager)
        {
            this.damage = 1;
            this.fireDelay = 0.5f;
        }
	}
}
