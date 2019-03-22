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
    /// Abstract class for immobile structures that the player builds
    /// </summary>
    abstract class Structure : GameObject, IDamageable
    {
        #region Fields
        protected int currentHealth;
        protected int maxHealth;
        #endregion

        #region Constructor
        /// <summary>
        /// A screenWidth and screenHeight of 0 will be sent to the base constructor
        ///  so all structures' speeds are always 0
        /// </summary>
        /// <param name="position"></param>
        /// <param name="texture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Structure(Vector2 position, Texture2D texture, int dimensions)
            : base(position, texture, dimensions, new Vector2(0, 0))
        {
            // TODO: initialize maxHealth to a default value
            this.currentHealth = this.maxHealth;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs a basic damage calculation
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public virtual float TakeDamage(int damage)
        {
            // Calculates % of damage that will still go through, and reduces current health by that amount
            currentHealth -= damage;
            // If this object has health less than or equal to zero, mark it as dead
            if (currentHealth <= 0)
            {
                active = false;
                
                // trigger the on-death event
            }
            return currentHealth - damage;
        }

        /// <summary>
        /// Draws this object
        /// </summary>
        /// <param name="sp">The SpriteBatch that will draw this object</param>
		public override void Draw(SpriteBatch sp)
		{
            if(active )
            {
                sp.Draw(texture, rectangle, Color.White);
            }
        }

		public virtual void Update(List<Enemy> enemies) { }

		#endregion

		#region Properties
		/// <summary>
		/// Amount of health that this object currently has
		/// </summary>
		public int CurrentHealth { get { return currentHealth; } }

		/// <summary>
		/// Maximum amount of health this object can have
		/// </summary>
		public int MaximumHealth { get { return maxHealth; } }

		float IDamageable.MaximumHealth => currentHealth;

		float IDamageable.CurrentHealth => maxHealth;



		#endregion
	}
}
