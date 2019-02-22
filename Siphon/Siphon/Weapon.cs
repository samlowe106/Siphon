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
    /// Abstract weapon class from which other weapons will inherit
    /// </summary>
    abstract class Weapon : IDisplayable
    {
        #region Fields

        Vector2 position;
        Texture2D texture;
        Rectangle rectangle;

        int damage;
        float fireDelay; // delay (in seconds) between firing shots
        bool active;

        #endregion

        #region Constructor

        public Weapon()
        {
            active = true;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Method that spawns a bullet
        /// </summary>
        public void Shoot()
        {
            // TODO
        }

        /// <summary>
        /// The method that will draw this object to the screen
        /// </summary>
        /// <param name="sp">The spritebatch that will draw this object's texture</param>
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(texture, rectangle, Color.White);
        }

        /// <summary>
        /// Virtual update method to be called by the manager
        /// </summary>
        public virtual void Update() { }

        #endregion

        #region Properties

        /// <summary>
        /// Boolean determining if this object's sprite should be drawn to the screen
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }
        }

        /// <summary>
        /// The Fire Rate of the gun, in bullets per second
        /// DIFFERENT from fireDelay! Equal to 1/fireDelay
        /// </summary>
        public float FireRate
        {
            get
            {
                return 1 / fireDelay;
            }
        }

        /// <summary>
        /// The position of this weapon on screen
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        #endregion
    }
}
