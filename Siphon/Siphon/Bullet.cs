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
        #region Fields
        int damage;
        #endregion

        #region Constructor
        /// <summary>
        /// A 5x5 pixel bullet that deals damage to any enemies that it collides with
        /// Spawns at 0,0 and is inactive until shot by a gun
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        public Bullet(Texture2D texture, int screenWidth, int screenHeight)
            : base (new Vector2(0, 0), texture, 5, screenWidth, screenHeight)
        {
        }
        #endregion

        #region Methods
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
        #endregion

        #region Properties
        /// <summary>
        /// Amount of damage this bullet deals
        /// </summary>
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }
        #endregion
    }
}
