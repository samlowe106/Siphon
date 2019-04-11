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
        Vector2 trajectory;
        #endregion

        #region Constructor
        /// <summary>
        /// A pixel bullet that deals damage to any enemies that it collides with
        /// Spawns at 0,0 and is inactive until shot by a gun
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        public Bullet(Texture2D texture)
            : base (new Vector2(0, 0), texture, 6, new Vector2(6,6))
        {
            this.active = false;
        }
        #endregion

        #region Methods
        public void Activate(Vector2 start, Vector2 destination, float angle, int damage)
        {
            this.active = true;
            this.position = start;
            this.angle = angle;
            this.damage = damage;
            this.rectangle = new Rectangle((int)start.X, (int)start.Y, 6, 6);
            // Get the vector from this bullet's origin to the destination and normalize it
            trajectory = this.GetDistanceVector(destination);
            trajectory.Normalize();
            // These bullets gotta go fast - speed them up by a factor of 15
            trajectory *= 15;
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
        /// Simply moves this bullet across the screen.
        /// Enemy collision and out-of-bounds must be checked in the bullet manager
        /// </summary>
        public override void Update()
        {
            position += trajectory;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 6, 6);
            base.Update();
        }

        public override void Draw(SpriteBatch sp)
        {
            base.Draw(sp);
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

        /// <summary>
        /// Getter and setter for if this bullet is active
        /// </summary>
        new public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        #endregion
    }
}
