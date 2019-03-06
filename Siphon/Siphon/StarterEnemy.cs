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
    class StarterEnemy : Enemy
    {
        public StarterEnemy(Vector2 position, Texture2D texture,
            int screenWidth, int screenHeight, MainStructure mainStructure)
            : base(position, texture, screenWidth/20, screenWidth, screenHeight, mainStructure, 5f)
        {
            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            speed = structureDistanceVector;
            speed.Normalize();

        }
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
    }
}
