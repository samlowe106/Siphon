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
    /// GameObject from which the player and enemies will inherit
    /// </summary>
	abstract class GameObject : IDamageable
	{
        
        Vector2 position;
        Texture2D texture;
        Rectangle rectangle;

        float armorRating;
        int currentHealth;
        int maxHealth;
        bool active;

        /// <summary>
        /// Basic GameObject from which other objects will inherit
        /// </summary>
        /// <param name="position">The GameObject's position</param>
        /// <param name="texture">The GameObject's texture</param>
        /// <param name="rectangle">The GameObject's hitbox</param>
        public GameObject(Vector2 position, Texture2D texture, Rectangle rectangle)
        {
            this.position = position;
            this.texture = texture;
            this.rectangle = rectangle;
            this.currentHealth = this.maxHealth;
            active = true;
        }

        /// <summary>
        /// Draws this GameObject's texture (if this object is active)
        /// </summary>
        /// <param name="sp">The current spritebatch</param>
        public void Draw(SpriteBatch sp)
        {
            if (this.active)
            {
                sp.Draw(texture);
            }
        }

        /// <summary>
        /// Performs a basic damage calculation
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public int TakeDamage(int damage)
        {
            // Calculates % of damage that will still go through, and reduces current health by that amount
            currentHealth =- (int)((float)damage * (100f - armorRating));
            // If this object has health less than or equal to zero, mark it as dead
            if (currentHealth <= 0)
            {
                active = false;
                // trigger the on-death event
            }
            return currentHealth - damage;
        }

        /// <summary>
        /// Amount of health that this object currently has
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
        }

        /// <summary>
        /// Maximum amount of health this object can have
        /// </summary>
        public int MaximumHealth
        {
            get
            {
                return maxHealth;
            }
        }

        /// <summary>
        /// Percentage of damage mitigated by this object
        /// </summary>
        public float ArmorRating
        {
            get
            {
                return armorRating;
            }
        }
	}
}
