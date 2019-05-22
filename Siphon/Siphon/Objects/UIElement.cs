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
    class UIElement
    {
        // fields
        Texture2D texture;
        Rectangle rectangle;

        // constructor
        public UIElement(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
        }

        // methods
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(texture, rectangle, Color.White);
        }
    }
}
