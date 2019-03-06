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
            speed *= 4;
        }
        #region Methods
        /// <summary>
        /// Performs a basic damage calculation
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        


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
