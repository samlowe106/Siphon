using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siphon
{
    /// <summary>
    /// Interface for objects which can take damage
    /// </summary>
	interface IDamageable
	{
        /// <summary>
        /// Maximum amount of health that this object can have
        /// </summary>
        float MaximumHealth { get; }

        /// <summary>
        /// Amount of health that this currently object has
        /// </summary>
        float CurrentHealth { get; }

        /// <summary>
        /// Function that causes this object to take damage
        /// </summary>
        /// <param name="damage">Amount of damage dealt</param>
        /// <returns>Amount of damage taken by this object after damage is calculated</returns>
        float TakeDamage(int damage);
	}
}
