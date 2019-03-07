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
    /// Enumeration that determines if a gun will fire if the mouse button is held down or not
    /// </summary>
    enum FireType
    {
        Automatic,
        SemiAutomatic
    }

    /// <summary>
    /// Abstract weapon class from which other weapons will inherit
    /// </summary>
    abstract class Weapon : GameObject, IDisplayable
    {
        #region Fields
        protected BulletManager manager;
        protected int damage;
        protected float fireDelay; // delay (in seconds) between firing shots
        protected Player holder;
        protected FireType fireType;
        // time when the gun was most recently fired
        #endregion

        #region Constructor
        public Weapon(Texture2D texture, Player holder, BulletManager manager)
            : base(holder.Position, texture, 32, new Vector2(0, 0))
        {
            this.manager = manager;
            this.holder = holder;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that spawns a bullet. Semi-automatic weapons
        /// need to check against the previous state to determine
        /// if they should shoot or not
        /// </summary>
        public void Shoot(MouseState currentMouse, MouseState previousMouse)
        {
            // Only shoot if the gun's fire rate permits shooting
            // if (currentTime - lastTimeShot > fireRate)
            // {
                // Change the shooting logic if this gun is automatic or semiautomatic
                switch (fireType)
                {
                    // Automatic guns can fire if held down
                    case FireType.Automatic:
                        if (currentMouse.LeftButton == ButtonState.Pressed)
                        {
                            //manager.SpawnBullet(, damage, );
                        }
                        break;

                    // Semi-auto guns won't fire if held down
                    case FireType.SemiAutomatic:
                        if (currentMouse.LeftButton == ButtonState.Pressed &&
                            previousMouse.LeftButton == ButtonState.Released)
                        {
                            //manager.SpawnBullet(, damage, );
                        }
                        break;
                }
            // }
        }

        public override void Update()
        {
            this.angle = holder.Angle;
            this.position = holder.Position;
            base.Update();
        }
        #endregion

        #region Properties
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

        public Player Holder
        {
            get
            {
                return holder;
            }
            set
            {
                holder = value;
            }
        }
        #endregion
    }
}
