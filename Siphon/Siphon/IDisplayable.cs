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
    /// Interface for objects that can be drawn to the screen
    /// </summary>
    interface IDisplayable
    {
        /// <summary>
        /// The method that will draw this object to the screen
        /// </summary>
        /// <param name="sp">The spritebatch that will draw this object's texture</param>
        void Draw(SpriteBatch sp);

        /// <summary>
        /// Boolean determining if this object's sprite should be drawn to the screen
        /// </summary>
        bool Active { get; }

        /// <summary>
        /// Vector2 representing this object's position
        /// </summary>
        Vector2 Position { get; }
    }
}
