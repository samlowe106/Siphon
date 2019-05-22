using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siphon
{
    /// <summary>
    /// Interface for objects that will deal damage to other objects that implement the IDamageable interface
    /// </summary>
    interface IDealDamage
    {
        /// <summary>
        /// Deals a specified amount of damage to a damageable object
        /// </summary>
        /// <param name="target">Damageable object to deal damage to</param>
        void DealDamage(IDamageable target);

        /// <summary>
        /// The amount of damage this object will deal when it deals damage
        /// </summary>
        int Damage { get; }
    }
}
