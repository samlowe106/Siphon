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
        public StarterEnemy(Vector2 position, Texture2D texture, MainStructure mainStructure)
            : base(position, texture, 32, new Vector2(1 , 1), mainStructure, 5f)
        {
            // Set this enemy to do one damage per hit
            this.damage = 1;
            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            this.speed *= 2; //value for starter Enemy
        }

        #region Methods
        #endregion
    }
}
