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

        Vector2 structureDistanceVector;

        public StarterEnemy(Vector2 position, Texture2D texture, int width, int height,
            int screenWidth, int screenHeight, MainStructure mainStructure)
            : base(position, texture, width, height, screenWidth, screenHeight, mainStructure)
        {
            this.armorRating = 0f; // we may decide to change this default value later
            // TODO: initialize maxHealth to a default value
            this.currentHealth = this.maxHealth;

            // Set this enemy to face the main structure
            this.SetAngle((int)mainStructure.Position.X, (int)mainStructure.Position.Y);

            // Keep track of the distance from this enemy to the main structure as a vector
            //  that way, we can decide where to move this enemy
            this.structureDistanceVector = GetDistanceVector(mainStructure);

            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            speed = structureDistanceVector;
            speed.Normalize();
            
        }        
    }
}
