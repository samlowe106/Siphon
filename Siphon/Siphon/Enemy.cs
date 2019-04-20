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
        protected List<Structure> structures;
        protected float damageRate = 0;
        protected float deltaTime = 0f;
        public float drawCounter = 0f;
        protected Player player;
        private Bank bank;
        #endregion

        #region Constructor
        public Enemy(Vector2 position, Texture2D texture, int dimensions, Bank bank,
            Vector2 speed, MainStructure mainStructure, float maxHealth, List<Structure> structures, Player player)
            : base(position, texture, dimensions, speed)
        {
            // bank
            this.bank = bank;

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
            //Array For structures set
            this.structures = structures;
            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            this.speed = distanceToStructure;
            this.speed.Normalize();
            this.speed *= 1;
            this.player = player;
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
            currentHealth -= damage;
            // If this object has health less than or equal to zero, mark it as dead
            if (currentHealth <= 0)
            {
                active = false;
                // trigger the on-death event
                Random random = new Random();
                bank.Deposit(random.Next(5, 10));
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
        /// Checks if this enemy is intersecting with any structures
        /// </summary>
        /// <returns>
        /// The structure that this enemy is intersecting with
        /// Null if the enemy isn't intersecting anything
        /// </returns>
        private Structure CheckTurretIntersect()
        {
            foreach (Structure s in structures)
            {   
                if (s != null && s.Rectangle.Intersects(this.rectangle))
                {
                    return s;
                }
            }
            return null;
        }


        /// <summary>
        /// Moves this enemy to the main structure; damages the main structure if already there
        /// </summary>
        public void Update(GameTime gameTime, List<Structure> structures)
        {
			this.structures = structures;
            Structure structureIntersect = CheckTurretIntersect();
            deltaTime = (float)(gameTime.ElapsedGameTime.TotalSeconds);
            drawCounter += deltaTime;
            // Move the enemy towards another structure
            if (structureIntersect == null)
            {
                position += speed;
                // Update this enemy's rectangle
                this.rectangle = new Rectangle((int)position.X, (int)position.Y, rectangle.Width, rectangle.Height);
            }
            // Otherwise, if this enemy is close enough to the main structure, do damage every second
            else // if (GameTime % SOMETHING == 0)
            {
                damageRate += deltaTime;
                if (damageRate >= .5)
                {
                    damageRate = 0;
                    this.DealDamage(structureIntersect);
                }
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
