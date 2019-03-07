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
    class EnemyManager
    {
        #region Constants
        const int ENEMIES_PER_WAVE = 3;
        #endregion

        #region Fields
        int waveNumber;
        List<Enemy> activeEnemies;
        Random generator;
        bool stageClear;
        MainStructure mainStructure;
        Texture2D plugEnemyModel;
        int screenWidth;
        int screenHeight;
        double timeUnitilNextWave;
        // Starter enemy's texture
        Texture2D startTexture;
        #endregion

        #region Constructor
        public EnemyManager(Texture2D startTexture, MainStructure mainStructure, int screenWidth, int screenHeight, Texture2D plugEnemyModel)
        {
            this.generator = new Random();
            this.startTexture = startTexture;
            this.mainStructure = mainStructure;
            this.activeEnemies = new List<Enemy>();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }
        #endregion

        #region Methods
        public void BeginNextWave()
        {
            // Increment the current wave
            ++waveNumber;
            // Set the amount of time until the next wave
            //timeUntilNextWave = SOMETHING;
            
            // Get coords for the next enemy to be spawned in
            int xCoord = generator.Next(0, 101);
            // 50% chance that the enemy will spawn on the right
            if (xCoord > 50)
            {
                // make the enemy spawn on the right
                xCoord = screenWidth - xCoord;
            }

            int yCoord = generator.Next(0, 101);
            // 50% chance that the enemy will spawn on the bottom of the screen
            if (xCoord > 50)
            {
                yCoord = screenWidth - yCoord;
            }

            Vector2 enemyCoords = new Vector2(xCoord, yCoord);
            // Spawn in 3 additional enemies per wave
            for (int i = 0; i < waveNumber * ENEMIES_PER_WAVE; ++i)
            {
                activeEnemies.Add(new StarterEnemy(enemyCoords, startTexture, mainStructure));
            }
        }

        /// <summary>
        /// Loops over enemies, updating each one
        /// </summary>
        public void Update()
        {
            // Loop over each enemy, updating them
            for (int i = activeEnemies.Count - 1; i > -1; --i)
            {
                activeEnemies[i].Update();
                // If the enemy isn't active (it's died), remove it from the list
                if (!activeEnemies[i].Active)
                {
                    activeEnemies.RemoveAt(i);
                }
            }
            // If all the enemies have died, mark the stage as clear
            stageClear = activeEnemies.Count == 0;
        }

        /// <summary>
        /// Loop over each enemy, drawing them
        /// </summary>
        /// <param name="sp">The spriteBatch that will draw each enemy</param>
        public void Draw(SpriteBatch sp)
        {
            foreach (Enemy enemy in activeEnemies)
            {
                enemy.Draw(sp);
            }
        }

        /// <summary>
        /// Checks a bullet against ALL active enemies
        /// </summary>
        /// <param name="b">Bullet to check</param>
        /// <returns>An enemy that the bullet is collding with, null if the bullet doesn't collide with anything</returns>
        public Enemy CheckCollision(Bullet b)
        {
            foreach (Enemy e in activeEnemies)
            {
                // If the enemy's hitbox overlaps with the bullet's, return true
                if (e.Rectangle.Intersects(b.Rectangle))
                {
                    return e;
                }
            }
            // If the bullet doesn't intersect with any rectangles, return false
            return null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int WaveNumber
        {
            get
            {
                return waveNumber;
            }
        }

        /// <summary>
        /// True if there are no enemies on the stage, false if there are still enemies on the stage
        /// </summary>
        public bool StageClear
        {
            get
            {
                return stageClear;
            }
        }

        /// <summary>
        /// Timer representing the amount of time until the next wave will spawn
        /// </summary>
        public double TimeUntilNextWave
        {
            get
            {
                return timeUnitilNextWave;
            }
        }
        #endregion
    }
}
