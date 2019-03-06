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
    /// Abstract class from which other enemies will inherit
    /// </summary>
	abstract class Enemy : GameObject, IDamageable, IDealDamage
	{
        #region Fields
        protected MainStructure mainStructure;
        protected float armorRating;
        protected float currentHealth;
        protected float maxHealth;
        protected int damage;
        protected Vector2 distanceToStructure;
        #endregion

        #region Constructor
        public Enemy(Vector2 position, Texture2D texture, int dimensions,
            Vector2 speed, MainStructure mainStructure, float maxHealth)
            : base(position, texture, dimensions, speed)
        {
            // Set this enemy to know where the main structure is
            this.mainStructure = mainStructure;
            // Set armor rating and health health
            this.armorRating = 0f;
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;

            // Set this enemy to face the main structure
            this.SetAngle((int)mainStructure.Position.X, (int)mainStructure.Position.Y);

            // Get the distance from this structure to the main one
            distanceToStructure = this.GetDistanceVector(mainStructure);

            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            this.speed = distanceToStructure;
            this.speed.Normalize();
        }                             
        #endregion

        #region Methods
        /// <summary>
        /// Performs a basic damage calculation
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public float TakeDamage(int damage)
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
            if (!mainStructure.rectangle.Contains(this.rectangle))
            {
                // Normalize the resultant vector: mainStructure.Position - this.Position;
                // Update: distanceToStructure -= 
                position += speed;
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
        public float CurrentHealth
        {
            get
            {
                return currentHealth;
            }
        }

        /// <summary>
        /// Maximum amount of health this object can have
        /// </summary>
        public float MaximumHealth
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
