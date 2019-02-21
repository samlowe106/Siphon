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
        void Draw(SpriteBatch sp);

        bool Active { get; }
    }
}
