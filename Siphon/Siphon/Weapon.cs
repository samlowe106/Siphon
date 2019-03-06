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
    abstract class Weapon : GameObject, IDisplayable
    {
        #region Fields
        protected BulletManager manager;
        protected int damage;
        protected float fireDelay; // delay (in seconds) between firing shots
        protected Player holder;
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
        /// Method that spawns a bullet
        /// </summary>
        public void Shoot()
        {
            // TODO
            //manager.SpawnBullet(, damage, );
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
