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

        public StarterEnemy(Vector2 position, Texture2D texture, MainStructure mainStructure, List<Structure> structures, int screenHeight, int screenWidth)
            : base(position, texture, 32, new Vector2(1 , 1), mainStructure, 4f, structures)
        {
            // Set this enemy to do one damage per hit
            this.damage = 1;
            // Combine structure distance vector with speed in some way so we can decide
            //  where this enemy moves and how fast it moves there
            this.speed *= 3; //value for starter Enemy
            this.texture = texture;

        }


        

        #region Methods

        public override void Draw(SpriteBatch sp)
        {
            if(drawCounter <= .075f)
            {
                sp.Draw(texture, position, new Rectangle(0, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)),  new Vector2(16, 16), 1f, SpriteEffects.None, 1f);

            }
            else if(drawCounter > .075f && drawCounter <= .125f)
            {
                sp.Draw(texture, position, new Rectangle(32, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), new Vector2(16, 16), 1f, SpriteEffects.None, 1f);

            }
            else if (drawCounter > .125f && drawCounter <= .2f)
            {
                sp.Draw(texture, position, new Rectangle(0, 32, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), new Vector2(16, 16), 1f, SpriteEffects.None, 1f);

            }
            else
            {
                sp.Draw(texture, position, new Rectangle(32, 32, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), new Vector2(16, 16), 1f, SpriteEffects.None, 1f);

                drawCounter = 0f;
            }

        }
        #endregion
    }
}
