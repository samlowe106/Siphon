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
    /// Basic starter pistol weapon
    /// </summary>
	class Pistol : Weapon
	{
        public Pistol(Texture2D texture, Player holder, BulletManager manager)
            : base(texture, holder, manager)
        {
            this.fireType = FireType.SemiAutomatic;
            this.damage = 1;
            this.fireDelay = 0.5f;
        }

        /// <summary>
        /// Spawns a bullet and sends it moving towards the mouse's position at the time of shooting
        /// </summary>
        /// <param name="currentMouseState"></param>
        protected override void Shoot(MouseState currentMouseState)
        {
            manager.SpawnBullet(this.Position,
                new Vector2(currentMouseState.Position.X, currentMouseState.Position.Y),
                this.angle, 
                this.damage);
            base.Shoot(currentMouseState);
        }
    }
}
