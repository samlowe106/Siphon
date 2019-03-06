using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siphon
{
    /// <summary>
    /// Basic starter pistol weapon
    /// </summary>
	class Pistol : Weapon
	{
        public Pistol(BulletManager manager)
            : base(manager)
        {
            this.damage = 1;
            this.fireDelay = 0.5f;
        }

        
	}
}
