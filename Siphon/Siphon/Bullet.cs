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
    /// Standard bullet class
    /// Object is produced when a gun is fired
    /// Managed by the BulletManager class
    /// </summary>
	class Bullet : GameObject, IDealDamage
	{
        int damage;

        public Bullet(Vector2 position, Texture2D texture, int x, int y, int width, int height, DisplayMode screen)
            : base (position, texture, x, y, width, height, screen)
        {

        }

        /// <summary>
        /// Deals this bullet's damage to a specified target
        /// </summary>
        /// <param name="target">Damageable target</param>
        public void DealDamage(IDamageable target)
        {
            // Deal damage to the specified enemy
            if (this.active)
            {
                target.TakeDamage(this.damage);
            }
            // Deactivate this bullet
            this.active = false;
        }

        /// <summary>
        /// Amount of damage this bullet deals
        /// </summary>
        public int Damage
        {
            get
            {
                return damage;
            }
        }
    }
}
