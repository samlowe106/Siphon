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

        // x and y values should be predetermined so the main structure always spawns in the same place

        public MainStructure(Vector2 position, Texture2D texture, int x, int y, int width, int height)
            : base(position, texture, x, y, width, height)
        {
            
        }
        #endregion

        // This object's OnDeath event should trigger something to end the game

    }
}
