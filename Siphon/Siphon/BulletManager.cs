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
    /// Bullet manager class, keeps track of and wraps all bullets
    /// </summary>
    class BulletManager
    {
        #region Fields
        const int NUM_BULLETS = 10;
        Queue<Bullet> inactiveBullets;
        List<Bullet> activeBullets;
        Texture2D bulletTexture;
        #endregion

        #region Constructor
        public BulletManager(Texture2D bulletTexture, int screenWidth, int screenHeight)
        {
            this.bulletTexture = bulletTexture;
            // Create a new queue
            inactiveBullets = new Queue<Bullet>(NUM_BULLETS);
            // Populate the queue with bullets
            for (int i = 0; i < NUM_BULLETS; ++i)
            {
                inactiveBullets.Enqueue(new Bullet(bulletTexture, screenWidth, screenHeight));
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Spawns in a bullet at the specified location, sets its damage, and sends it in the specified direction
        /// </summary>
        /// <param name="position"></param>
        /// <param name="damage"></param>
        /// <param name="angle"></param>
        public void SpawnBullet(Vector2 position, int damage, float angle)
        {
            Bullet newBullet = inactiveBullets.Dequeue();
            newBullet.Damage = damage;
            newBullet.Position = position;
            newBullet.Angle = angle;
        }

        /// <summary>
        /// Updates each active bullet
        /// </summary>
        public void Update()
        {
            // Loop over each bullet, updating them
            for (int i = 0; i < activeBullets.Count; ++i)
            {
                activeBullets[i].Update();
                // If the bullet isn't active (it's collided with something),
                //  remove it from this list and requeue it
                if (!activeBullets[i].Active)
                {
                    inactiveBullets.Enqueue(activeBullets[i]);
                    activeBullets.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Draws all the active bullets
        /// </summary>
        /// <param name="sp">The spritebatch that will draw the bullets</param>
        public void Draw(SpriteBatch sp)
        {
            foreach (Bullet b in activeBullets)
            {
                b.Draw(sp);
            }
        }
        #endregion

        #region Properties (empty)
        #endregion
    }
}
