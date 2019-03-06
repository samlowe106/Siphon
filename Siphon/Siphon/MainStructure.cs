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
    /// The main structure that the player must protect; if its health drops to zero, the game ends
    /// </summary>
    class MainStructure : Structure
    {
        #region Constructor

        // Position vector should be predetermined so the main structure always spawns in the center of the screen

        public MainStructure(Vector2 position, Texture2D texture, int dimension)
            : base(position, texture, dimension) // : base(new Vector2(X, Y), texture, NUMBER)
        {
            
        }
        #endregion

        // This object's OnDeath event should trigger something to end the game

    }
}
