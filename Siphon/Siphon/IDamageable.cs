using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siphon
{
	interface IDamageable
	{
        /// <summary>
        /// Percentage of damage that will be ignored when this object takes damage
        /// </summary>
        float ArmorRating { get; }

        /// <summary>
        /// Maximum amount of health that this object can have
        /// </summary>
        int MaximumHealth { get; }

        /// <summary>
        /// Amount of health that this currently object has
        /// </summary>
        int CurrentHealth { get; }

        /// <summary>
        /// Function that causes this object to take damage
        /// </summary>
        /// <param name="damage">Amount of damage dealt</param>
        /// <returns>Amount of damage taken by this object after damage is calculated</returns>
        int TakeDamage(int damage);
	}
}
