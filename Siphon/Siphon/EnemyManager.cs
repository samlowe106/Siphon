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
        int screenWidth;
        int screenHeight;

        double timeUnitilNextWave;

        // Starter enemy's texture
        Texture2D startTexture;
        #endregion

        #region Constructor
        public EnemyManager(Texture2D startTexture, int screenWidth, int screenHeight, MainStructure mainStructure)
        {
            generator = new Random();
            this.startTexture = startTexture;
            this.mainStructure = mainStructure;
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
            Vector2 enemyCoords = new Vector2(generator.Next(), generator.Next()); // need to add bounds
            // Spawn in 3 additional enemies per wave
            for (int i = 0; i < waveNumber * ENEMIES_PER_WAVE; ++i)
            {
                activeEnemies.Add(new StarterEnemy(enemyCoords, startTexture, screenWidth, screenHeight, mainStructure));
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
