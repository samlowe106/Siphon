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
        const int NUM_BULLETS = 100;
        Queue<Bullet> inactiveBullets;
        List<Bullet> activeBullets;
        Texture2D bulletTexture;
        EnemyManager enemyManager;
        Rectangle screen;
        #endregion

        #region Constructor
        public BulletManager(Texture2D bulletTexture, int screenWidth, int screenHeight, EnemyManager enemyManager)
        {
            this.bulletTexture = bulletTexture;
            this.enemyManager = enemyManager;
            this.screen = new Rectangle(0, 0, screenWidth, screenHeight);
            // Create the bullet list and queue
            activeBullets = new List<Bullet>(NUM_BULLETS);

            // Populate the queue with bullets
            /* inactiveBullets = new Queue<Bullet>(NUM_BULLETS);
            for (int i = 0; i < NUM_BULLETS; ++i)
            {
                inactiveBullets.Enqueue(new Bullet(bulletTexture));
            }
            */
        }
        #endregion

        #region Methods
        /// <summary>
        /// Spawns in a bullet at the specified location, sets its damage, and sends it in the specified direction
        /// </summary>
        /// <param name="position"></param>
        /// <param name="damage"></param>
        /// <param name="angle"></param>
        public void SpawnBullet(Vector2 position, Vector2 destination, float angle, int damage)
        {
            Bullet newBullet = new Bullet(bulletTexture, screen.Height / 75);
            newBullet.Activate(position, destination, angle, damage);
            activeBullets.Add(newBullet);
        }

        /// <summary>
        /// Updates each active bullet
        /// </summary>
        public void Update()
        {
            // Loop over each bullet, updating them
            for (int i = activeBullets.Count - 1; i > -1; --i)
            {
                activeBullets[i].Update();
                // Check collision with enemies
                Enemy enemyHit = enemyManager.CheckCollision(activeBullets[i]);
                if (enemyHit != null)
                {
                    activeBullets[i].DealDamage(enemyHit);
                }
                // Check if the bullet is out of bounds
                else if (!screen.Contains(activeBullets[i].Rectangle))
                {
                    activeBullets[i].Active = false;
                }

                // If the bullet isn't active (it's collided with something),
                //  remove it from this list and requeue it
                if (!activeBullets[i].Active)
                {
                    //inactiveBullets.Enqueue(activeBullets[i]);
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
