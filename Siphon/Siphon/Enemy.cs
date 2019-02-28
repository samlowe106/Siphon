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
    /// Abstract class from which other enemies will inherit. Inherits from GameObject and implements IDamageable
    /// </summary>
	abstract class Enemy : GameObject, IDamageable, IDealDamage
	{
        #region Fields
        MainStructure mainStructure;
        protected float armorRating;
        protected int currentHealth;
        protected int maxHealth;
        protected int damage;
        double distanceToStructure;
        #endregion

        #region Constructor
        public Enemy(Vector2 position, Texture2D texture, int x, int y, int width, int height,
            DisplayMode screen, MainStructure mainStructure)
            : base(position, texture, x, y, width, height, screen)
        {
            this.armorRating = 0f; // we may decide to change this default value later
            // TODO: initialize maxHealth to a default value
            this.currentHealth = this.maxHealth;

            // Set this enemy to face the main structure
            this.SetAngle((int)mainStructure.Position.X, (int)mainStructure.Position.Y);

            // Keep track of the distance from this enemy to the main structure
            //  that way, we only need to call GetDistance once
            this.distanceToStructure = GetDistance(mainStructure);
        }                             
        #endregion

        #region Methods
        /// <summary>
        /// Performs a basic damage calculation
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public int TakeDamage(int damage)
        {
            // Calculates % of damage that will still go through, and reduces current health by that amount
            currentHealth = -(int)((float)damage * (100f - armorRating));
            // If this object has health less than or equal to zero, mark it as dead
            if (currentHealth <= 0)
            {
                active = false;
                // trigger the on-death event
            }
            return currentHealth - damage;
        }

        /// <summary>
        /// Deals this object's damage to a specified target
        /// </summary>
        /// <param name="target">Damageable target</param>
        public void DealDamage(IDamageable target)
        {
            // Deal damage to the specified enemy
            if (this.active)
            {
                target.TakeDamage(this.damage);
            }
        }

        /// <summary>
        /// Moves this enemy to the main structure; damages the main structure if already there
        /// </summary>
        public override void Update()
        {
            if (distanceToStructure > 0)
            {
                // Move this enemy closer to the main structure
                // Update distanceToStructure
            }
            // Otherwise, if this enemy is close enough to the main structure, do damage
            else
            {
                this.DealDamage(mainStructure);
            }

            base.Update();
        }
        #endregion

        #region Properties
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

        /// <summary>
        /// Amount of damage that this object deals per hit
        /// </summary>
        public int Damage
        {
            get
            {
                return damage;
            }
        }
        #endregion
    }
}
