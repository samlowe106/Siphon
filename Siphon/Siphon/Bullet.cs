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
	class Bullet : IDisplayable
	{
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        bool active;
        int damage;

        public Bullet(int damage)
        {
            this.damage = damage;
        }

        /// <summary>
        /// The method that will draw this object to the screen
        /// </summary>
        /// <param name="sp">The spritebatch that will draw this object's texture</param>
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(texture, rectangle, Color.White);
        }

        public void Update()
        {
            // TODO
        }

        /// <summary>
        /// Deals this bullet's damage to a specified target
        /// </summary>
        /// <param name="target">Damageable target that</param>
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
        /// Boolean determining if this object's sprite should be drawn to the screen
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }
        }

        /// <summary>
        /// Vector2 representing this object's position
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
    }
}
